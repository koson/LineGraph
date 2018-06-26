// gprsdll.cpp : Defines the initialization routines for the DLL.
//

#include "stdafx.h"
#include "gprsdll.h"
#include "Gprs.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//
//	Note!
//
//		If this DLL is dynamically linked against the MFC
//		DLLs, any functions exported from this DLL which
//		call into MFC must have the AFX_MANAGE_STATE macro
//		added at the very beginning of the function.
//
//		For example:
//
//		extern "C" BOOL PASCAL EXPORT ExportedFunction()
//		{
//			AFX_MANAGE_STATE(AfxGetStaticModuleState());
//			// normal function body here
//		}
//
//		It is very important that this macro appear in each
//		function, prior to any calls into MFC.  This means that
//		it must appear as the first statement within the 
//		function, even before any object variable declarations
//		as their constructors may generate calls into the MFC
//		DLL.
//
//		Please see MFC Technical Notes 33 and 58 for additional
//		details.
//

/////////////////////////////////////////////////////////////////////////////
// CGprsdllApp

BEGIN_MESSAGE_MAP(CGprsdllApp, CWinApp)
	//{{AFX_MSG_MAP(CGprsdllApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CGprsdllApp construction

CGprsdllApp::CGprsdllApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CGprsdllApp object

CGprsdllApp theApp;
CGprs theGprs;

/////////////////////////////////////////////////////////////////////////////
// CGprsdllApp initialization

BOOL CGprsdllApp::InitInstance()
{
	if (!AfxSocketInit())
	{
		AfxMessageBox(IDP_SOCKETS_INIT_FAILED);
		return FALSE;
	}

	return TRUE;
}


////////////////////////////////////////////////////////////////////////////
// 名称: DLLStartService
// 描述: 启动服务器的数据服务
// 参数: [in]  port   服务的侦听端口
//       [out] 无
// 返回: TRUE表示成功，FALSE表示失败,可以调用DLLGetLastError()函数查看错误原因
BOOL _stdcall DLLStartService(u16t port)
{
    return theGprs.StartService(port);
}

// 名称: DLLStopService
// 描述: 停止服务器的数据服务
// 参数: [in]  无
//       [out] 无
// 返回: TRUE表示成功，FALSE表示失败,可以调用DLLGetLastError()函数查看错误原因
BOOL _stdcall DLLStopService(void)
{
    return theGprs.StopService();
}


// 名称: DLLGetNextData
// 描述: 读取下一条DTU送上来的信息
// 参数: [out] pDataStruct  存放DTU所送上来的信息和数据的结构，读函数执行成功后，返回的数据存放到该参数指向的结构中
//       [in]  waitseconds  本函数读到数据后立即返回；如果没有数据到达，则等待最长waitseconds（时间单位：秒）的时间，直到有数据到达,取值范围从0~65535，如果取值为0表明本函数将立即返回
// 返回: TRUE表示收到数据，FALSE没有收到数据
BOOL _stdcall DLLGetNextData(DTUDataStruct* pDataStruct, u16t waitseconds)
{
	return theGprs.GetNextData(pDataStruct, waitseconds);
}


// 名称: DLLSendData
// 描述: 向指定ID号的的DTU发送数据
// 参数: [in]  modemId   DTU的ID号，用以标识一个DTU
//       [in]  len       待发送的数据长度（字节数），数据长度必须小于或等于1450个字节
//       [in]  buf       待发送的数据
//       [out] 无
// 返回: TRUE表示成功，FALSE表示失败,可以调用DLLGetLastError()函数查看错误原因
BOOL _stdcall DLLSendData(u32t modemId, u16t len, u8t* buf)
{
    return theGprs.SendData(modemId, len, buf);
}


// 名称: DLLGetModemCount
// 描述: 取得当前在线的所有的DTU的总数
// 参数: [in]  无
//       [out] 无
// 返回: 在线DTU总数
u32t _stdcall DLLGetModemCount(void)
{
    return theGprs.GetModemCount();
}

// 名称: DLLGetModemByPosition
// 描述: 取得指定位置的DTU的数据
// 参数: [in]  pos			 DTU列表中的位置信息,0代表第一个DTU位置
//       [out] pModemInfo	 指向用以保存DTU信息的数据结构;
// 返回: TRUE表示成功，FALSE表示失败
BOOL _stdcall DLLGetModemByPosition(u32t pos, DTUInfoStruct* pModemInfo)
{
    return theGprs.GetModemByPosition(pos, pModemInfo);
}


// 名称: DLLSendControl
// 描述: 向指定ID号的的DTU发送控制命令
// 参数: [in]  modemId		 DTU的ID号，用以标识一个DTU
//		 [in]  len           待发送的控制命令长度（字节数），数据长度必须小于或等于1000个字节
//       [in]  buf           待发送的控制命令帧
//       [out] 无
// 返回: TRUE表示成功，FALSE表示失败，可以调用DLLGetLastError()函数查看错误原因
BOOL _stdcall DLLSendControl(u32t modemId, u16t len, u8t* buf)
{
    return theGprs.SendControl(modemId, len, buf);
}

// 名称: DLLGetLastError
// 描述: 获得先前API执行时发生的错误
// 参数: [out] str			 用来存放错误信息的缓冲区
//		 [in]  nMaxBufSize   缓冲区的最大长度，如果错误信息的大小超过了这个值，则此函数将把错误信息的尾部截除
// 返回: 无
void _stdcall DLLGetLastError(char* str, int nMaxBufSize)
{
    theGprs.GetLastError(str, nMaxBufSize);
}

// 名称: DLLCloseModemById
// 描述: 关闭DTU连接
// 参数: [in]  modemId		 DTU的ID号，用以标识一个DTU
//		 [out] 无
// 返回: TRUE表示成功，FALSE表示失败，可以调用DLLGetLastError()函数查看错误原因
BOOL _stdcall DLLCloseModemById(u32t modemId)
{
	return theGprs.StopServiceById(modemId);
}

