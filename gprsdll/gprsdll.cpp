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
// ����: DLLStartService
// ����: ���������������ݷ���
// ����: [in]  port   ����������˿�
//       [out] ��
// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��,���Ե���DLLGetLastError()�����鿴����ԭ��
BOOL _stdcall DLLStartService(u16t port)
{
    return theGprs.StartService(port);
}

// ����: DLLStopService
// ����: ֹͣ�����������ݷ���
// ����: [in]  ��
//       [out] ��
// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��,���Ե���DLLGetLastError()�����鿴����ԭ��
BOOL _stdcall DLLStopService(void)
{
    return theGprs.StopService();
}


// ����: DLLGetNextData
// ����: ��ȡ��һ��DTU����������Ϣ
// ����: [out] pDataStruct  ���DTU������������Ϣ�����ݵĽṹ��������ִ�гɹ��󣬷��ص����ݴ�ŵ��ò���ָ��Ľṹ��
//       [in]  waitseconds  �������������ݺ��������أ����û�����ݵ����ȴ��waitseconds��ʱ�䵥λ���룩��ʱ�䣬ֱ�������ݵ���,ȡֵ��Χ��0~65535�����ȡֵΪ0��������������������
// ����: TRUE��ʾ�յ����ݣ�FALSEû���յ�����
BOOL _stdcall DLLGetNextData(DTUDataStruct* pDataStruct, u16t waitseconds)
{
	return theGprs.GetNextData(pDataStruct, waitseconds);
}


// ����: DLLSendData
// ����: ��ָ��ID�ŵĵ�DTU��������
// ����: [in]  modemId   DTU��ID�ţ����Ա�ʶһ��DTU
//       [in]  len       �����͵����ݳ��ȣ��ֽ����������ݳ��ȱ���С�ڻ����1450���ֽ�
//       [in]  buf       �����͵�����
//       [out] ��
// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��,���Ե���DLLGetLastError()�����鿴����ԭ��
BOOL _stdcall DLLSendData(u32t modemId, u16t len, u8t* buf)
{
    return theGprs.SendData(modemId, len, buf);
}


// ����: DLLGetModemCount
// ����: ȡ�õ�ǰ���ߵ����е�DTU������
// ����: [in]  ��
//       [out] ��
// ����: ����DTU����
u32t _stdcall DLLGetModemCount(void)
{
    return theGprs.GetModemCount();
}

// ����: DLLGetModemByPosition
// ����: ȡ��ָ��λ�õ�DTU������
// ����: [in]  pos			 DTU�б��е�λ����Ϣ,0�����һ��DTUλ��
//       [out] pModemInfo	 ָ�����Ա���DTU��Ϣ�����ݽṹ;
// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��
BOOL _stdcall DLLGetModemByPosition(u32t pos, DTUInfoStruct* pModemInfo)
{
    return theGprs.GetModemByPosition(pos, pModemInfo);
}


// ����: DLLSendControl
// ����: ��ָ��ID�ŵĵ�DTU���Ϳ�������
// ����: [in]  modemId		 DTU��ID�ţ����Ա�ʶһ��DTU
//		 [in]  len           �����͵Ŀ�������ȣ��ֽ����������ݳ��ȱ���С�ڻ����1000���ֽ�
//       [in]  buf           �����͵Ŀ�������֡
//       [out] ��
// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ�ܣ����Ե���DLLGetLastError()�����鿴����ԭ��
BOOL _stdcall DLLSendControl(u32t modemId, u16t len, u8t* buf)
{
    return theGprs.SendControl(modemId, len, buf);
}

// ����: DLLGetLastError
// ����: �����ǰAPIִ��ʱ�����Ĵ���
// ����: [out] str			 ������Ŵ�����Ϣ�Ļ�����
//		 [in]  nMaxBufSize   ����������󳤶ȣ����������Ϣ�Ĵ�С���������ֵ����˺������Ѵ�����Ϣ��β���س�
// ����: ��
void _stdcall DLLGetLastError(char* str, int nMaxBufSize)
{
    theGprs.GetLastError(str, nMaxBufSize);
}

// ����: DLLCloseModemById
// ����: �ر�DTU����
// ����: [in]  modemId		 DTU��ID�ţ����Ա�ʶһ��DTU
//		 [out] ��
// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ�ܣ����Ե���DLLGetLastError()�����鿴����ԭ��
BOOL _stdcall DLLCloseModemById(u32t modemId)
{
	return theGprs.StopServiceById(modemId);
}

