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

//数据结构：
//1．用以区分标识各台DTU的数据结构：
typedef UINT    u32t; 
typedef UCHAR   u8t;
typedef USHORT  u16t;
typedef ULONG   u64t; 

typedef struct _dtu_info_t_
{
	u32t	m_modemId;   	  //DTU模块的ID号
	u8t		m_phoneNo[12];	  //DTU的11位电话号码，必须以'\0'字符结尾
	u8t		m_dynIp[4];		  //DTU的4位动态ip地址
	u64t	m_connTime; 	  //DTU模块最后一次建立TCP连接的时间
	u64t	m_refreshTime;    //DTU模块最后一次收发数据的时间
} DTUInfoStruct;

#define MAX_RECEIVE_BUF 1450				// TCP数据包最大长度
#define REG_PACKET_SIZE 21					// 注册包长度

typedef struct _dtu_data_t {
    u32t       m_modemId;		     		// DTU模块的ID号
    u64t       m_recvTime;					//接收到数据包的时间
    u8t        m_data[MAX_RECEIVE_BUF+1];	//存储接收到的数据
    u16t       m_dataLen;					//接收到的数据包长度
    u8t        m_dataType;	          		//接收到的数据包类型,0表示不认识类型，1表示用户数据包，2表示对控制命令帧的回应
}DTUDataStruct;

//2．Api说明：
extern "C" { 
	// 名称: DLLStartService
	// 描述: 启动服务器的数据服务
	// 参数: [in]  port   服务的侦听端口
	//       [out] 无
	// 返回: TRUE表示成功，FALSE表示失败,可以调用DLLGetLastError()函数查看错误原因
	BOOL _stdcall DLLStartService(u16t port);
	
	// 名称: DLLStopService
	// 描述: 停止服务器的数据服务
	// 参数: [in]  无
	//       [out] 无
	// 返回: TRUE表示成功，FALSE表示失败,可以调用DLLGetLastError()函数查看错误原因
	BOOL _stdcall DLLStopService(void);	
	
	// 名称: DLLGetNextData
	// 描述: 读取下一条DTU送上来的信息
	// 参数: [out] pDataStruct  存放DTU所送上来的信息和数据的结构，读函数执行成功后，返回的数据存放到该参数指向的结构中
	//       [in]  waitseconds  本函数读到数据后立即返回；如果没有数据到达，则等待最长waitseconds（时间单位：秒）的时间，直到有数据到达,取值范围从0~65535，如果取值为0表明本函数将立即返回
	// 返回: TRUE表示收到数据，FALSE没有收到数据
	BOOL _stdcall DLLGetNextData(DTUDataStruct* pDataStruct,u16t waitseconds);
	
	// 名称: DLLSendData
	// 描述: 向指定ID号的的DTU发送数据
	// 参数: [in]  modemId   DTU的ID号，用以标识一个DTU
	//       [in]  len       待发送的数据长度（字节数），数据长度必须小于或等于1450个字节
	//       [in]  buf       待发送的数据
	//       [out] 无
	// 返回: TRUE表示成功，FALSE表示失败,可以调用DLLGetLastError()函数查看错误原因
	BOOL _stdcall DLLSendData(u32t modemId,u16t len,u8t * buf);	
	
	// 名称: DLLGetModemCount
	// 描述: 取得当前在线的所有的DTU的总数
	// 参数: [in]  无
	//       [out] 无
	// 返回: 在线DTU总数
	u32t _stdcall DLLGetModemCount(void);
	
	// 名称: DLLGetModemByPosition
	// 描述: 取得指定位置的DTU的数据
	// 参数: [in]  pos			 DTU列表中的位置信息,0代表第一个DTU位置
	//       [out] pModemInfo	 指向用以保存DTU信息的数据结构;
	// 返回: TRUE表示成功，FALSE表示失败
	BOOL _stdcall DLLGetModemByPosition(u32t pos, DTUInfoStruct *pModemInfo);	
	
	// 名称: DLLSendControl
	// 描述: 向指定ID号的的DTU发送控制命令
	// 参数: [in]  modemId		 DTU的ID号，用以标识一个DTU
	//		 [in]  len           待发送的控制命令长度（字节数），数据长度必须小于或等于1000个字节
	//       [in]  buf           待发送的控制命令帧
	//       [out] 无
	// 返回: TRUE表示成功，FALSE表示失败，可以调用DLLGetLastError()函数查看错误原因
	BOOL _stdcall DLLSendControl(u32t modemId,u16t len,u8t * buf);
	
	// 名称: DLLGetLastError
	// 描述: 获得先前API执行时发生的错误
	// 参数: [out] str			 用来存放错误信息的缓冲区
	//		 [in]  nMaxBufSize   缓冲区的最大长度，如果错误信息的大小超过了这个值，则此函数将把错误信息的尾部截除
	// 返回: 无
	void _stdcall DLLGetLastError(char *str,int nMaxBufSize);	

	// 名称: DLLCloseModemById
	// 描述: 关闭DTU连接
	// 参数: [in]  modemId		 DTU的ID号，用以标识一个DTU
	//		 [out] 无
	// 返回: TRUE表示成功，FALSE表示失败，可以调用DLLGetLastError()函数查看错误原因
	BOOL _stdcall DLLCloseModemById(u32t modemId);
}
/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_GPRSDLL_H__0BF79118_9C7A_4359_8150_D0A2304E47AF__INCLUDED_)
