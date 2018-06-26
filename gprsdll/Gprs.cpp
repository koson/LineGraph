// Gprs.cpp: implementation of the CGprs class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "gprsdll.h"
#include "Gprs.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////////
const int BACKLOG_NUM                   = 5;
const int MILLISECOND_PER_SECOND        = 1000;
const int MICROSECOND_PER_MILLISECOND   = 1000;
#define MILLI2TV(milli, tv) \
    tv.tv_sec = (milli) / MILLISECOND_PER_SECOND; \
    tv.tv_usec = (milli) % MILLISECOND_PER_SECOND * MICROSECOND_PER_MILLISECOND;

const int THREAD_SLEEP_TIME             = 1;	// millisecond
const int ACCEPT_WAIT_TIME              = 1000; // millisecond
const int READ_WAIT_TIME                = 1000; // millisecond
const int WRITE_WAIT_TIME               = 1000; // millisecond

const char* MSG_PACKET_FOR_EXIT			= "__NOW EXIT THE THREADING__";
//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CGprs::CGprs() : m_bRunning(FALSE), m_socketServer(INVALID_SOCKET), 
	m_socketConnectForExit(INVALID_SOCKET), m_socketForExit(INVALID_SOCKET),
	m_uiListenPort(0), m_iLastError(0), 
	m_strLastError(_T("")),	m_pServerThread(NULL), m_pRecvThread(NULL), 
	m_pSendThread(NULL), m_iModemCount(0)
{  
	ZeroMemory(&m_ti, sizeof(TThreadInfo));
	ZeroMemory(&m_SockAddrSelf, sizeof(sockaddr_in));
	m_ti.hEventOver				= CreateEvent(NULL, TRUE, FALSE, _T("SocketOver"));
    m_ti.hEventRecvWait         = CreateEvent(NULL, TRUE, FALSE, _T("ReceivingWait")); 
    m_ti.hEventSendWait         = CreateEvent(NULL, TRUE, FALSE, _T("SendingWait")); 
    InitializeCriticalSection(&m_ti.csClient);
    InitializeCriticalSection(&m_ti.csRecv);
    InitializeCriticalSection(&m_ti.csSend);
	exit = false;
	exits= false;
	exitr=false;
}

CGprs::~CGprs()
{

}

//////////////////////////////////////////////////////////////////////////

BOOL CGprs::StartService(u16t port)
{
	exit = true;
	exits=true;
	exitr=true;
	if (m_bRunning) {
        m_strLastError = _T("服务已经启动！");
        return FALSE;
    }
	m_uiListenPort			= (u_short)port;

    sockaddr_in local;    
    local.sin_family        = AF_INET;
    local.sin_addr.s_addr   = INADDR_ANY;
    local.sin_port          = htons(m_uiListenPort);
    
    m_socketServer = socket(AF_INET, SOCK_STREAM, 0);//服务套接字
    if(m_socketServer == INVALID_SOCKET)
    {
        m_iLastError = WSAGetLastError();
        m_strLastError = _T("创建socket失败！");
        return FALSE;
    }
	TRACE("SOCKET SERVER IS %ld\n", m_socketServer);

    if(bind(m_socketServer, (sockaddr*)&local, sizeof(local)) != 0)
    {
        m_iLastError = WSAGetLastError();
        m_strLastError = _T("绑定socket失败！");
        return FALSE;
    }

    if(listen(m_socketServer, BACKLOG_NUM) != 0)
    {
        m_iLastError = WSAGetLastError();
        m_strLastError = _T("无法在指定socket上监听！");
        return FALSE;
    }

	TRACE("fd_set size: %d\n", sizeof(fd_set));
    TRACE("Modem Count before:%d\n", m_iModemCount);
	m_iModemCount = 0;
	TRACE("Modem Count after:%d\n", m_iModemCount);
	m_clients.clear();
	while(!m_RecvData.empty()) m_RecvData.pop();	
	m_SendData.clear(); //呆发送数据队列清空
    m_pServerThread = AfxBeginThread(ServerThreadProc, (LPVOID)this);    
    m_pRecvThread = AfxBeginThread(ReceivingThreadProc, (LPVOID)this);
    m_pSendThread = AfxBeginThread(SendingThreadProc, (LPVOID)this);
	m_bRunning = TRUE;

    return TRUE;
}

BOOL CGprs::StopService(void)
{
	exit = false;
	
	SetEvent(m_ti.hEventOver); //退出

	if(! ConnectSelfForExit()) 
	{
		ResetEvent(m_ti.hEventOver); 
		return FALSE;
	}

    if(WaitForSingleObject(m_pServerThread->m_hThread, INFINITE) != WAIT_OBJECT_0) 
    {
        m_iLastError = WSAGetLastError();
		if(m_iLastError != ERROR_INVALID_HANDLE)
		{
			TRACE("WaitForThread Error:%ld\n", m_iLastError);
			m_strLastError = _T("监听线程异常终止！");
			return FALSE;
		}
    }

	if (m_socketForExit != INVALID_SOCKET)
	{
		closesocket(m_socketForExit);
		m_socketForExit = INVALID_SOCKET;
	}
	if (m_socketConnectForExit != INVALID_SOCKET)
	{
		ZeroMemory(&m_SockAddrSelf, sizeof(sockaddr_in));
		closesocket(m_socketConnectForExit);
		m_socketConnectForExit = INVALID_SOCKET;
	}
	else
	{
		ASSERT(0);
	}

	ResetEvent(m_ti.hEventOver);
	m_bRunning = FALSE;	
	TClientList::iterator it;
    for(it = m_clients.begin();it!=m_clients.end();++it) 
	{
		if (it->socketClient!=INVALID_SOCKET)
		{
			closesocket((*it).socketClient);
		//	(*it).socketClient = INVALID_SOCKET;
		}
	}
    return TRUE;
}

BOOL CGprs::GetNextData(DTUDataStruct* pDataStruct, u16t waitseconds)
{
   EnterCriticalSection(&m_ti.csRecv);
	if (!m_RecvData.empty()) 
	{
		*pDataStruct = m_RecvData.front();
		//TRACE("%ld at line: %ld\n", pDataStruct->m_dataLen, __LINE__);
		m_RecvData.pop();
	}
	else
	{
		LeaveCriticalSection(&m_ti.csRecv);
		return FALSE;
	}

    LeaveCriticalSection(&m_ti.csRecv);
    return TRUE;
}

BOOL CGprs::SendControl(u32t modemId, u16t len, u8t* buf)
{
    TSendData sd;
	int i;
    ZeroMemory(&sd, sizeof(TSendData));
    sd.uModemId             = modemId;
	//sd.uLen					= len;
    sd.uLen                 = CopySendData(sd.szData, buf, len);
	//memcpy((char*)sd.szData, (const char*)buf, len);
    sd.szData[sd.uLen]      = '\0';
    sd.iLenSended           = 0;

    if (sd.uLen > MAX_RECEIVE_BUF - 2) {
        m_strLastError = _T("缓冲区溢出！");
        return FALSE;
    }
    for(i = sd.uLen + 2; i >= 2; i--) {
        sd.szData[i] = sd.szData[i - 2];
    }
    sd.szData[i--] = 0XFD;
    sd.szData[i] = 0XFD;
    ASSERT(i == 0);
    
    return SendData(sd);
}

BOOL CGprs::SendData(u32t modemId, u16t len, u8t* buf)
{
    TSendData sd;
    ZeroMemory(&sd, sizeof(TSendData));
    sd.uModemId             = modemId;
	//sd.uLen					= len;
    sd.uLen                 = CopySendData(sd.szData, buf, len);
	//memcpy((char*)sd.szData, (const char*)buf, len);
    sd.szData[sd.uLen]      = '\0';
    sd.iLenSended           = 0;

    return SendData(sd);
}

BOOL CGprs::SendData(TSendData& sd)
{
    EnterCriticalSection(&m_ti.csClient); //modem保护
    for(TClientList::iterator it = m_clients.begin(); it != m_clients.end(); ++it) 
	{
        if (it->modem_info.m_modemId == sd.uModemId)
		{
            sd.socketClient = it->socketClient;
        }
    }
    LeaveCriticalSection(&m_ti.csClient);

    if (sd.socketClient == 0)
	{ // 未找到对应的socket
        m_strLastError = _T("与该Modem模块的连接已中断！");
        return FALSE;
    }

    EnterCriticalSection(&m_ti.csSend);
    m_SendData.push_back(sd);
    LeaveCriticalSection(&m_ti.csSend);

    ResetEvent(m_ti.hEventSendWait); //无信号
    if(WaitForSingleObject(m_ti.hEventSendWait, INFINITE) != WAIT_OBJECT_0) {
        m_iLastError = WSAGetLastError();
        m_strLastError = _T("发送线程异常终止！");
        return FALSE;
    }

    EnterCriticalSection(&m_ti.csSend);
    sd.iLenSended = m_SendData.back().iLenSended;

    // remove all sent elements.
    do {
        TSendDataList::iterator it = std::find_if(m_SendData.begin(), m_SendData.end(), OpSendDataOver()); 
        if (it == m_SendData.end())
            break;
        m_SendData.erase(it);
    } while(TRUE); 

    LeaveCriticalSection(&m_ti.csSend);

    if (sd.iLenSended < sd.uLen) {
        m_strLastError = _T("发送超时！");
        return FALSE;
    }

    return TRUE;
}

u32t CGprs::GetModemCount(void)
{
    EnterCriticalSection(&m_ti.csClient);
    int iCount = m_clients.size();
	ASSERT(iCount >=  m_iModemCount);
	iCount = m_iModemCount;
    LeaveCriticalSection(&m_ti.csClient);
	//TRACE("Count:%d\n", uCount);

    return (u32t)iCount;
}

BOOL CGprs::GetModemByPosition(u32t pos, DTUInfoStruct* pModemInfo)
{
    BOOL bRet = FALSE;
    u32t i = 0;

    EnterCriticalSection(&m_ti.csClient);
    TClientList::iterator it = m_clients.begin();
    if (pos >= 0 && pos < GetModemCount()) {
        for(; i < pos; ++i, ++it) {
			if (!it->bConnected)
			{
				++it;
			}
		}

        *pModemInfo = it->modem_info;
		//if (pModemInfo->m_modemId == 0)
		{
			//TRACE("pos=%d, modem_id=%08X\n", pos, pModemInfo->m_modemId);
		}		
        bRet = TRUE;
    }
    LeaveCriticalSection(&m_ti.csClient);

    return bRet;
}

void CGprs::GetLastError(char* str, int nMaxBufSize)
{
    strncpy_s(str, nMaxBufSize, m_strLastError.GetBuffer(nMaxBufSize), nMaxBufSize - 1);
    str[nMaxBufSize-1] = '\0';
    m_strLastError.ReleaseBuffer();
    return;
}

//////////////////////////////////////////////////////////////////////////

UINT CGprs::ServerThreadProc(LPVOID pParam)
{	
	CGprs* pGprs = (CGprs*)pParam;
	ASSERT(pGprs);
    TThreadInfo* pTi = &pGprs->m_ti;

    fd_set fd;
//  TIMEVAL tv;
//  MILLI2TV(ACCEPT_WAIT_TIME, tv);

    SOCKET socketClient;
    sockaddr_in from;
    int fromlen = sizeof(from);
    
   // while(WaitForSingleObject(pTi->hEventOver, 0) != WAIT_OBJECT_0) //有信号返回
	while(pGprs->exit)
    {
        FD_ZERO(&fd);
        FD_SET(pGprs->m_socketServer, &fd);

        int iNumReady = select(0, &fd, NULL, NULL, NULL);

        if (iNumReady == 0) // Time expired
            continue;

        if(iNumReady == SOCKET_ERROR) 
        {
            pGprs->m_iLastError = WSAGetLastError();
            if (pGprs->m_iLastError == WSAENETDOWN) {
                AfxMessageBox(IDP_SOCKETS_NETWORK_BREAKDOWN);
            }
            pGprs->TermThread();
            TRACE("%ld SOCKET_ERROR AT ServerThreadProc, ErrorCode: %ld, Line: %d", 
				pGprs->m_socketServer, pGprs->m_iLastError, __LINE__);
            break;
        }

        if (FD_ISSET(pGprs->m_socketServer, &fd) && pGprs->m_clients.size() < FD_SETSIZE) {
            socketClient = accept(pGprs->m_socketServer, (struct sockaddr*)&from, &fromlen);
#ifdef _DEBUG1
			static int iSocketNum = 0;
			TRACE("Socket Num: %ld, Current Socket ID:%lu\n", ++iSocketNum, socketClient);
			if (iSocketNum % 500 == 0)
			{
				TRACE("500 ok\n");
			}
#endif
			// if not a connection for exiting service, add it to the connection list.
			if (pGprs->m_socketConnectForExit == INVALID_SOCKET
				|| !(from.sin_addr.S_un.S_addr == pGprs->m_SockAddrSelf.sin_addr.S_un.S_addr && from.sin_port == pGprs->m_SockAddrSelf.sin_port))
			{
				TClient client(socketClient);
				
				EnterCriticalSection(&pTi->csClient);
				pGprs->m_clients.push_back(client);
				//TRACE("count just after recv: %d\n", pGprs->m_clients.size());
				LeaveCriticalSection(&pTi->csClient);
			}  
			else
			{
				TRACE("The socket for exiting service got.\n");
				pGprs->m_socketForExit = socketClient;
				send(pGprs->m_socketConnectForExit, MSG_PACKET_FOR_EXIT, sizeof(MSG_PACKET_FOR_EXIT), 0);
			}
        }
    }

//	::MessageBox(NULL, "1", NULL, MB_OK);

	while(pGprs->exits)
	{
		Sleep(100);
	}

	/*if(WaitForSingleObject(pGprs->m_pRecvThread->m_hThread, INFINITE) != WAIT_OBJECT_0) 
    
	{
        pGprs->m_iLastError = WSAGetLastError();
		if(pGprs->m_iLastError != ERROR_INVALID_HANDLE)
			pGprs->m_strLastError = _T("Socket收发线程异常终止！");
    }*/
//	::MessageBox(NULL, "2", NULL, MB_OK);

	while(pGprs->exitr)
	{
		Sleep(100);
	}

	/*if( WaitForSingleObject(pGprs->m_pSendThread->m_hThread, INFINITE) != WAIT_OBJECT_0)
	{ 
		pGprs->m_iLastError = WSAGetLastError();
		if(pGprs->m_iLastError != ERROR_INVALID_HANDLE)
			pGprs->m_strLastError = _T("Socket收发线程异常终止！");
	}*/

	shutdown(pGprs->m_socketServer, SD_BOTH);
    closesocket(pGprs->m_socketServer);
    return 0;
}

UINT CGprs::ReceivingThreadProc(LPVOID pParam)
{
    CGprs* pGprs = (CGprs*)pParam;
	ASSERT(pGprs);
    TThreadInfo* pTi = &pGprs->m_ti;

    fd_set fdRead;
    TIMEVAL tv;
    MILLI2TV(READ_WAIT_TIME, tv);
    pGprs->exitr=true;
   while(WaitForSingleObject(pTi->hEventOver, THREAD_SLEEP_TIME) != WAIT_OBJECT_0)
//	while(pGprs->exit)
    {
		// receive data
		
        EnterCriticalSection(&pTi->csClient);
        int iNum = pGprs->m_clients.size();
        LeaveCriticalSection(&pTi->csClient);
        if (iNum == 0) 
            continue;

        FD_ZERO(&fdRead);
		if (pGprs->m_socketForExit != INVALID_SOCKET)
		{
			FD_SET(pGprs->m_socketForExit, &fdRead);
		}
        EnterCriticalSection(&pTi->csClient);
        TClientList::iterator it, itNext;
        for(it = pGprs->m_clients.begin(); it != pGprs->m_clients.end(); ++it) {
			//TRACE("SOCKET ID:%d\n", it->socketClient);
            FD_SET(it->socketClient, &fdRead);
        }
        LeaveCriticalSection(&pTi->csClient);

        int iNumReady = select(0, &fdRead, NULL, NULL, &tv);
        
        if (iNumReady == 0) // Time expired
            continue;

        if(iNumReady == SOCKET_ERROR) 
        {
            pGprs->m_iLastError = WSAGetLastError();
            if (pGprs->m_iLastError == WSAENETDOWN) {
                AfxMessageBox(IDP_SOCKETS_NETWORK_BREAKDOWN);
            } 
            //TRACE("SOCKET_ERROR FOUND AT ReceivingThreadProc, Line: %d\n", __LINE__);
            continue;
        }
        
        EnterCriticalSection(&pTi->csClient);
        for(it = pGprs->m_clients.begin(); it != pGprs->m_clients.end(); ) {
            if (FD_ISSET(it->socketClient, &fdRead))
            {
                if(! pGprs->RecvFromClient(it, &itNext))
					it = itNext;
				else 
					it++;
            }// if (FD_ISSET(...
            else {
                it++;
            }
        }// for
        LeaveCriticalSection(&pTi->csClient);
    }// while
    pGprs->exitr=false;
    return 0;
}

UINT CGprs::SendingThreadProc(LPVOID pParam)
{
    CGprs* pGprs = (CGprs*)pParam;
	ASSERT(pGprs);
    TThreadInfo* pTi = &pGprs->m_ti;

    fd_set fdWrite;
    TIMEVAL tv;
    MILLI2TV(WRITE_WAIT_TIME, tv);
    pGprs->exits=true;
    while(WaitForSingleObject(pTi->hEventOver, THREAD_SLEEP_TIME) != WAIT_OBJECT_0)
//	while(pGprs->exit)
    {
		if(pGprs->m_SendData.empty()) continue;

		EnterCriticalSection(&pTi->csSend);
        for(TSendDataList::iterator it = pGprs->m_SendData.begin(); it != pGprs->m_SendData.end(); ++it) 
		{
            if(it->iLenSended > 0)
			{
                continue;
			}

            FD_ZERO(&fdWrite);
            FD_SET(it->socketClient, &fdWrite);
            int iNumReady = select(0, NULL, &fdWrite, NULL, &tv);
            
            if (iNumReady == 0) // Time expired
            {
				
                continue;
			}
            
            if(iNumReady == SOCKET_ERROR) 
            {
                pGprs->m_iLastError = WSAGetLastError();
                if (pGprs->m_iLastError == WSAENETDOWN) {
                    AfxMessageBox(IDP_SOCKETS_NETWORK_BREAKDOWN);
                }                    
                //TRACE("SOCKET_ERROR on %ld FOUND AT SendingThreadProc, ErrorCode:%ld, Line: %d\n", 
				//	it->socketClient, pGprs->m_iLastError, __LINE__);
		
                continue;
            }

            int iBytes = send(it->socketClient, (char*)it->szData, it->uLen, 0);
#ifdef _DEBUG
            //TRACE("%ld bytes sent out at: %ld\n", iBytes, __LINE__);
			/*for(int i = 0; i < it->uLen; i++) {
				TRACE("%2X ", it->szData[i]);
				if(i % 16 == 0) 
					TRACE("\n");
			}
			TRACE("\n");*/
#endif                    
            if(iBytes == SOCKET_ERROR) {
                pGprs->m_iLastError = WSAGetLastError();
                pGprs->m_strLastError = _T("发送失败");
            }
            else {
                it->iLenSended = iBytes;
            }
        }// for

        SetEvent(pTi->hEventSendWait);
        LeaveCriticalSection(&pTi->csSend);
    }// while
    pGprs->exits=false;
    return 0;
}
//////////////////////////////////////////////////////////////////////////

void CGprs::TermThread()
{
	SetEvent(m_ti.hEventOver);
	//m_bRunning = FALSE;
}

BOOL CGprs::ConnectSelfForExit()
{
	m_socketConnectForExit = socket(AF_INET, SOCK_STREAM, 0);
    if(m_socketConnectForExit == INVALID_SOCKET)
    {
        m_iLastError = WSAGetLastError();
		return FALSE;
    }

	sockaddr_in local;    
    local.sin_family        =   AF_INET;
    local.sin_addr.s_addr   =   inet_addr("127.0.0.1");
    local.sin_port          =   htons(m_uiListenPort);

	// try five times to exit
	for(int i =0; i < 5; i++)
	{
		if(connect(m_socketConnectForExit, (struct sockaddr *)&local, sizeof(sockaddr_in)) != SOCKET_ERROR)
		{
			int iLen = sizeof(sockaddr_in);
			getsockname(m_socketConnectForExit, (struct sockaddr *)&m_SockAddrSelf, &iLen);
			ASSERT(iLen == sizeof(sockaddr_in));
			TRACE("SOCKET ID for Exit is:%ld\n", m_socketConnectForExit);
			return TRUE;
		}
	}

	return FALSE;
}

// return FALSE if some error occur; otherwise return TRUE.
BOOL CGprs::RecvFromClient(TClientList::iterator it, TClientList::iterator* pitNext)
{
	char szBuf[MAX_RECEIVE_BUF+1];
	char* pszData = szBuf; // point to the valid packet data except the registering 21 bytes

	int iBytes = recv(it->socketClient, szBuf, MAX_RECEIVE_BUF, 0);
	int iErrorCode = WSAGetLastError();
	
	char hertByte = 0xfe;

	//TRACE("%d bytes got at %ld\n", iBytes, __LINE__);
    if (iBytes == 0 || (iBytes == SOCKET_ERROR/* && WSAGetLastError() == WSAECONNRESET*/))
    {
		// Client socket closed
		shutdown(it->socketClient, SD_BOTH);
        closesocket(it->socketClient);
        //TRACE("Socket %lu is closed at line:%ld, Error Code: %ld.\n", it->socketClient, __LINE__, iErrorCode);
        RemoveSendDataOf(it->socketClient);
		// remove the socket
		//TRACE("Modem Count before minus:%d\n", m_iModemCount);
		m_iModemCount--;
		TRACE("Modem Count after minus:%d\n", m_iModemCount);
		*pitNext = m_clients.erase(it);
		return FALSE;
    }

    // We received a message from client
	BOOL bResult = TRUE;
    szBuf[iBytes] = '\0';
#ifdef _DEBUG
    //TRACE("\nHEX:   ");
    //for(int i = 0; i < iBytes && i < MAX_RECEIVE_BUF; ++i)
        //TRACE1("%02X ", szBuf[i]);
    //TRACE("\n");
#endif
    DTUInfoStruct* pMi = &it->modem_info;
    if (! it->bConnected) {			// 注册包
        //ASSERT(iBytes == 21);       // 注册包共21字节
#ifdef _DEBUG
		if (szBuf[20] != 0X00)
		{
			TRACE("error modem_id: %ld, socket id:%lu\n", it->modem_info.m_modemId, it->socketClient);
		}
        ASSERT(szBuf[20] == 0X00);  // 结束符
#endif
        
		//TRACE("Before Register: %02X %02X %02X %02X\n", szBuf[3], szBuf[2], szBuf[1], (BYTE)szBuf[0]);
        u32t uModemId = ((u8t)szBuf[3] << 24) + ((u8t)szBuf[2] << 16) + ((u8t)szBuf[1] << 8) + (u8t)szBuf[0];
		//TRACE("After Register: %08X, PreFourBytes is: %X%X%X%X\n", uModemId, szBuf[3], szBuf[2], szBuf[1], szBuf[0]);
        TClientList::iterator itDup = std::find_if(m_clients.begin(), m_clients.end(), OpClientModemIdEqual(uModemId)); 
        if (itDup != m_clients.end()) {
            // Client socket closed
			shutdown(itDup->socketClient, SD_BOTH);
            closesocket(itDup->socketClient); 
			TRACE("Socket %lu is closed at line %ld, Modem ID:%ld.\n", itDup->socketClient, __LINE__, itDup->modem_info.m_modemId);
			RemoveSendDataOf(itDup->socketClient);
    
			// remove the socket			
			//TRACE("Modem Count before minus:%d\n", m_iModemCount);
			if(itDup->bConnected)
			{
				m_iModemCount--;
			}
			//TRACE("Modem Count after minus:%d\n", m_iModemCount);
			itDup->socketClient = 0;
			m_clients.erase(itDup);
			*pitNext = it;
			(*pitNext)++;
			bResult = FALSE;
        }

		EnterCriticalSection(&m_ti.csRecv);

		it->bConnected = TRUE;
		if (uModemId == 1)
			TRACE("Modem Count before add:%d, Modem ID:%d, Socket ID:%lu\n", m_iModemCount, uModemId, it->socketClient);
		m_iModemCount++;
		//TRACE("Modem Count after add:%d\n", m_iModemCount);
		pMi->m_modemId = uModemId;
		memcpy(pMi->m_phoneNo, &szBuf[4], 11);
		pMi->m_phoneNo[11] = '\0';
		memcpy(pMi->m_dynIp, &szBuf[16], 4);
		pMi->m_connTime = pMi->m_refreshTime = (u64t)time(NULL);		
		LeaveCriticalSection(&m_ti.csRecv);
		
// 		TRACE("%8X %s %d.%d.%d.%d, %s\n", 
// 			pMi->m_modemId, pMi->m_phoneNo, 
// 			pMi->m_dynIp[0], pMi->m_dynIp[1], pMi->m_dynIp[2], pMi->m_dynIp[3], 
// 			ctime((time_t *)&pMi->m_connTime));

		if (iBytes > REG_PACKET_SIZE) {
			pszData = szBuf + REG_PACKET_SIZE;
			iBytes -= REG_PACKET_SIZE;
			goto LBL_GET_DATA;
		}
    }
    else 
	{  // 数据包
LBL_GET_DATA:
		pMi->m_refreshTime = (u64t)time(NULL);

        DTUDataStruct md;
        md.m_modemId    = pMi->m_modemId;
        md.m_recvTime  = pMi->m_refreshTime;
        md.m_dataType  = 0X01;
        
		if (iBytes == 1 && szBuf[0] == hertByte) 
		{
			md.m_dataLen = 0;
		}
		else
		{
			md.m_dataLen   = CopyRecvData(md.m_data, (u8t*)pszData, iBytes);
		}
		//md.m_dataLen	= iBytes < MAX_RECEIVE_BUF ? iBytes : MAX_RECEIVE_BUF;
		//md.m_dataLen	= iBytes;
		//memcpy(md.m_data, szBuf, iBytes);
		//memcpy(md.m_data, pszData, iBytes);
        md.m_data[md.m_dataLen] = '\0';
		if(m_RecvData.size()>65000)
			return TRUE;
        EnterCriticalSection(&m_ti.csRecv);                        
        m_RecvData.push(md);                        
        LeaveCriticalSection(&m_ti.csRecv);
        
        SetEvent(m_ti.hEventRecvWait);
    }

	return bResult;
}

void CGprs::RemoveSendDataOf(SOCKET s)
{
	TSendDataList::iterator itSDL;
	EnterCriticalSection(&m_ti.csSend);
	for(itSDL = m_SendData.begin(); itSDL != m_SendData.end();) {
		if (itSDL->socketClient == s) {
			itSDL = m_SendData.erase(itSDL);                            
		}
		else {
			itSDL++;
		}
	}
    LeaveCriticalSection(&m_ti.csSend);
}

// 将数据包内的0xfd 0xed转为0xfd, 0xfd 0xee转为0xfe
u16t CGprs::CopyRecvData(u8t szBuf[], u8t szRecv[], int iBytes)
{
	int i;
	u16t j;

    ASSERT(iBytes > 0);

    for(i = 0, j = 0; i < iBytes - 1; ++i, ++j) {
        if (szRecv[i] == 0xfd) {
            if (szRecv[i+1] == 0xed) {
                szBuf[j] = 0xfd;
                ++i;
            }
            else if (szRecv[i+1] == 0xee) {
                szBuf[j] = 0xfe;
                ++i;
            }
            else {
                szBuf[j] = szRecv[i];
            }
        }
        else {
            szBuf[j] = szRecv[i];
        }
    }// for
    if (i == iBytes - 1) {
        szBuf[j++] = szRecv[i];
    }

    return j;
}

// 将数据包内的0xfd转为0xfd  0xed, 0xfe转为0xfd 0xee
u16t CGprs::CopySendData(u8t szBuf[], u8t szSend[], int iBytes)
{
	int i;
	u16t j;

    ASSERT(iBytes > 0);

    for(i = 0, j = 0; i < iBytes; ++i, ++j) {
        if (szSend[i] == 0xfd) {
            szBuf[j]    = 0xfd;
            szBuf[++j]  = 0xed;
        }
        else if (szSend[i] == 0xfe) {
            szBuf[j]    = 0xfd;
            szBuf[++j]  = 0xee;
        }
        else {
            szBuf[j] = szSend[i];
        }

        if (j >= MAX_RECEIVE_BUF) 
            break;
    }// for

    return j;
}


BOOL CGprs::StopServiceById(u32t modemId)
{
	TClientList::iterator it;
	for(it = m_clients.begin();it!=m_clients.end();++it) 
	{
		if ((it->socketClient!=INVALID_SOCKET) && (it->modem_info.m_modemId == modemId))
		{
			shutdown(it->socketClient, SD_BOTH);
			closesocket(it->socketClient); 
			TRACE("Socket %lu is closed at line %ld, Modem ID:%ld.\n", it->socketClient, __LINE__, it->modem_info.m_modemId);
			RemoveSendDataOf(it->socketClient);

			if(it->bConnected)
			{
				m_iModemCount--;
			}
			//TRACE("Modem Count after minus:%d\n", m_iModemCount);
			it->socketClient = 0;
			m_clients.erase(it);

			// remove the socket			
			//TRACE("Modem Count before minus:%d\n", m_iModemCount);
			//	(*it).socketClient = INVALID_SOCKET;
			return TRUE;
		}
	}

	return FALSE;
}