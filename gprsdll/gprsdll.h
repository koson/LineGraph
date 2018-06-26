// gprsdll.h : main header file for the GPRSDLL DLL
//

#if !defined(AFX_GPRSDLL_H__0BF79118_9C7A_4359_8150_D0A2304E47AF__INCLUDED_)
#define AFX_GPRSDLL_H__0BF79118_9C7A_4359_8150_D0A2304E47AF__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CGprsdllApp
// See gprsdll.cpp for the implementation of this class
//

class CGprsdllApp : public CWinApp
{
public:
	CGprsdllApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CGprsdllApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

	//{{AFX_MSG(CGprsdllApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//���ݽṹ��
//1���������ֱ�ʶ��̨DTU�����ݽṹ��
typedef UINT    u32t; 
typedef UCHAR   u8t;
typedef USHORT  u16t;
typedef ULONG   u64t; 

typedef struct _dtu_info_t_
{
	u32t	m_modemId;   	  //DTUģ���ID��
	u8t		m_phoneNo[12];	  //DTU��11λ�绰���룬������'\0'�ַ���β
	u8t		m_dynIp[4];		  //DTU��4λ��̬ip��ַ
	u64t	m_connTime; 	  //DTUģ�����һ�ν���TCP���ӵ�ʱ��
	u64t	m_refreshTime;    //DTUģ�����һ���շ����ݵ�ʱ��
} DTUInfoStruct;

#define MAX_RECEIVE_BUF 1450				// TCP���ݰ���󳤶�
#define REG_PACKET_SIZE 21					// ע�������

typedef struct _dtu_data_t {
    u32t       m_modemId;		     		// DTUģ���ID��
    u64t       m_recvTime;					//���յ����ݰ���ʱ��
    u8t        m_data[MAX_RECEIVE_BUF+1];	//�洢���յ�������
    u16t       m_dataLen;					//���յ������ݰ�����
    u8t        m_dataType;	          		//���յ������ݰ�����,0��ʾ����ʶ���ͣ�1��ʾ�û����ݰ���2��ʾ�Կ�������֡�Ļ�Ӧ
}DTUDataStruct;

//2��Api˵����
extern "C" { 
	// ����: DLLStartService
	// ����: ���������������ݷ���
	// ����: [in]  port   ����������˿�
	//       [out] ��
	// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��,���Ե���DLLGetLastError()�����鿴����ԭ��
	BOOL _stdcall DLLStartService(u16t port);
	
	// ����: DLLStopService
	// ����: ֹͣ�����������ݷ���
	// ����: [in]  ��
	//       [out] ��
	// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��,���Ե���DLLGetLastError()�����鿴����ԭ��
	BOOL _stdcall DLLStopService(void);	
	
	// ����: DLLGetNextData
	// ����: ��ȡ��һ��DTU����������Ϣ
	// ����: [out] pDataStruct  ���DTU������������Ϣ�����ݵĽṹ��������ִ�гɹ��󣬷��ص����ݴ�ŵ��ò���ָ��Ľṹ��
	//       [in]  waitseconds  �������������ݺ��������أ����û�����ݵ����ȴ��waitseconds��ʱ�䵥λ���룩��ʱ�䣬ֱ�������ݵ���,ȡֵ��Χ��0~65535�����ȡֵΪ0��������������������
	// ����: TRUE��ʾ�յ����ݣ�FALSEû���յ�����
	BOOL _stdcall DLLGetNextData(DTUDataStruct* pDataStruct,u16t waitseconds);
	
	// ����: DLLSendData
	// ����: ��ָ��ID�ŵĵ�DTU��������
	// ����: [in]  modemId   DTU��ID�ţ����Ա�ʶһ��DTU
	//       [in]  len       �����͵����ݳ��ȣ��ֽ����������ݳ��ȱ���С�ڻ����1450���ֽ�
	//       [in]  buf       �����͵�����
	//       [out] ��
	// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��,���Ե���DLLGetLastError()�����鿴����ԭ��
	BOOL _stdcall DLLSendData(u32t modemId,u16t len,u8t * buf);	
	
	// ����: DLLGetModemCount
	// ����: ȡ�õ�ǰ���ߵ����е�DTU������
	// ����: [in]  ��
	//       [out] ��
	// ����: ����DTU����
	u32t _stdcall DLLGetModemCount(void);
	
	// ����: DLLGetModemByPosition
	// ����: ȡ��ָ��λ�õ�DTU������
	// ����: [in]  pos			 DTU�б��е�λ����Ϣ,0�����һ��DTUλ��
	//       [out] pModemInfo	 ָ�����Ա���DTU��Ϣ�����ݽṹ;
	// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ��
	BOOL _stdcall DLLGetModemByPosition(u32t pos, DTUInfoStruct *pModemInfo);	
	
	// ����: DLLSendControl
	// ����: ��ָ��ID�ŵĵ�DTU���Ϳ�������
	// ����: [in]  modemId		 DTU��ID�ţ����Ա�ʶһ��DTU
	//		 [in]  len           �����͵Ŀ�������ȣ��ֽ����������ݳ��ȱ���С�ڻ����1000���ֽ�
	//       [in]  buf           �����͵Ŀ�������֡
	//       [out] ��
	// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ�ܣ����Ե���DLLGetLastError()�����鿴����ԭ��
	BOOL _stdcall DLLSendControl(u32t modemId,u16t len,u8t * buf);
	
	// ����: DLLGetLastError
	// ����: �����ǰAPIִ��ʱ�����Ĵ���
	// ����: [out] str			 ������Ŵ�����Ϣ�Ļ�����
	//		 [in]  nMaxBufSize   ����������󳤶ȣ����������Ϣ�Ĵ�С���������ֵ����˺������Ѵ�����Ϣ��β���س�
	// ����: ��
	void _stdcall DLLGetLastError(char *str,int nMaxBufSize);	

	// ����: DLLCloseModemById
	// ����: �ر�DTU����
	// ����: [in]  modemId		 DTU��ID�ţ����Ա�ʶһ��DTU
	//		 [out] ��
	// ����: TRUE��ʾ�ɹ���FALSE��ʾʧ�ܣ����Ե���DLLGetLastError()�����鿴����ԭ��
	BOOL _stdcall DLLCloseModemById(u32t modemId);
}
/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_GPRSDLL_H__0BF79118_9C7A_4359_8150_D0A2304E47AF__INCLUDED_)
