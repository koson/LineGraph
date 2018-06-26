// Gprs.h: interface for the CGprs class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_GPRS_H__8083C86D_B901_4CB4_B14D_D22555AA94F7__INCLUDED_)
#define AFX_GPRS_H__8083C86D_B901_4CB4_B14D_D22555AA94F7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <list>
#include <queue>
#include <algorithm>

//////////////////////////////////////////////////////////////////////////
struct TThreadInfo {
    HANDLE              hEventOver;
    HANDLE              hEventRecvWait;
    HANDLE              hEventSendWait;
    
    CRITICAL_SECTION    csClient;
    CRITICAL_SECTION    csRecv;
    CRITICAL_SECTION    csSend;
};

struct TClient {
    SOCKET              socketClient;
	BOOL				bConnected;
    DTUInfoStruct     modem_info;
    

    TClient(SOCKET socketClient) {
        ZeroMemory(this, sizeof(TClient));
        this->socketClient  = socketClient;
    }

    TClient(const TClient& client) {
        ZeroMemory(this, sizeof(TClient));        
        *this = client;
    }    

    TClient& operator = (const TClient& client) {
        this->socketClient      = client.socketClient;
		this->bConnected		= client.bConnected;
        this->modem_info        = client.modem_info;

        return *this;
    }

    ~TClient() {
    }
};
typedef std::list<TClient> TClientList;

struct OpClientSocketEqual {
    explicit OpClientSocketEqual(SOCKET s) : m_s(s) {}
    bool operator()(const TClient &client ) const {
        //TRACE("OpClientSocketEqual: m_s=%d, client.s=%d\n", m_s, client.socketClient);
        return client.socketClient == m_s ? true : false;
    }
private:
    SOCKET  m_s;
};

struct OpClientModemIdEqual {
    explicit OpClientModemIdEqual(u32t id) : m_id(id) {}
    bool operator()(const TClient &client ) const {
        //TRACE("OpClientModemIdEqual: m_id=%d, client.id=%d\n", m_id, client.modem_info.m_modemId);
        return (client.bConnected && client.modem_info.m_modemId == m_id) ? true : false;
    }
private:
    u32t  m_id;
};

struct TSendData {
    SOCKET  socketClient;               // Modem������SOCKET
    u32t    uModemId;		     	    // Modemģ���ID��
    u8t     szData[MAX_RECEIVE_BUF+1];  // �洢Ҫ���͵�����
    u16t    uLen;				        // ���͵����ݰ�����
    BOOL    iLenSended;                 // �ѷ����ֽ���
};

typedef std::list<TSendData> TSendDataList; 
typedef std::queue<DTUDataStruct> TModemDataList; 

struct OpSendDataOver {
    bool operator()(const TSendData &data ) const {
        //TRACE("OpSendDataOver: data.iLenSended=%d\n", data.iLenSended);
        return data.iLenSended > 0 ? true : false;
    }
};

class CGprs
{
public:
	CGprs();
	virtual ~CGprs();

public:
    BOOL StartService(u16t port);
    BOOL StopService(void);
    BOOL GetNextData(DTUDataStruct* pDataStruct, u16t waitseconds);
    BOOL SendData(u32t modemId, u16t len, u8t* buf);
    u32t GetModemCount(void);
    BOOL GetModemByPosition(u32t pos, DTUInfoStruct* pModemInfo);
    BOOL SendControl(u32t modemId, u16t len, u8t* buf);
    void GetLastError(char* str, int nMaxBufSize);
	BOOL StopServiceById(u32t modemId);
private:
    BOOL SendData(TSendData& sd);
    BOOL ConnectSelfForExit();
	bool exit ;
	bool exits;
	bool exitr;
private:
	SOCKET				m_socketServer; //�����׽���
	SOCKET				m_socketConnectForExit;
	SOCKET				m_socketForExit;
	sockaddr_in			m_SockAddrSelf;
    BOOL				m_bRunning; //��������״̬
	u_short				m_uiListenPort; //����˿�
	TThreadInfo			m_ti;
    int					m_iLastError;
    CString				m_strLastError;
    TClientList			m_clients;     //�������Ŀͻ����б�
	int					m_iModemCount;
    TModemDataList		m_RecvData; // �������ݶ���
    TSendDataList		m_SendData; //���������б�
	
	CWinThread*			m_pServerThread; //�����߳�
	CWinThread*			m_pRecvThread; //�����߳�
	CWinThread*			m_pSendThread; //�����߳�

    static UINT ServerThreadProc( LPVOID pParam );
    static UINT ReceivingThreadProc( LPVOID pParam );
    static UINT SendingThreadProc( LPVOID pParam );

	void TermThread();
	BOOL RecvFromClient(TClientList::iterator it, TClientList::iterator* pitNext);
	void RemoveSendDataOf(SOCKET s);
    u16t CopyRecvData(u8t szBuf[], u8t szRecv[], int iBytes);
    u16t CopySendData(u8t szBuf[], u8t szSend[], int iBytes);
};

#endif // !defined(AFX_GPRS_H__8083C86D_B901_4CB4_B14D_D22555AA94F7__INCLUDED_)
