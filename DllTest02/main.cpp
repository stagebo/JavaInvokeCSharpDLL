//-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
//	mian.h文件
//	2017-8-23 16:44:19
//	声明需要被java调用的方法，该方法和java接口内部方法保持一致
//	预处理语句目的是暴露函数供外部调用。
//-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
/***********************函数声明************************************************/
#ifdef MYLIBAPI  
#else  
#define  MYLIBAPI  extern "C" __declspec(dllimport)      
#endif 


MYLIBAPI char* Do(char* connStr, char* dept, char* gchid);







MYLIBAPI char* Get(char* str);

MYLIBAPI int OutTest();
//-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
//	main.cpp文件
//	2017-8-23 16:44:06
//	实现头文件内的函数，实现对c#动态链接库的调用。
//	方法名保持和java接口内部方法名一致。
//	变量类型对应关系访问：http://blog.csdn.net/lovesomnus/article/details/45073343
//-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
#include "stdio.h" 
#include <string>
#include <iostream>
using namespace std;
using namespace System;
using namespace TDYH;
/*****************************************函数体Start******************************************************************/

char* Do(char* connStr, char* dept, char* gchid)
{
	return "this is c++ tip.";
	cout << "this is c++ program" << endl;

	TDYHDecorator ^tdyh;
	tdyh =gcnew TDYHDecorator();
	String ^connString = gcnew String(connStr);
	String ^deptString = gcnew String(dept);
	String ^gchidString = gcnew String(gchid);
	String ^ result = tdyh->Do(connString,deptString,gchidString);
	char* out = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(result);

	//String ^resultString = tdyhDecorator->Do();
	//char* resultChar = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(resultString);
	//char * resultChar = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(connString);
	return out;//"this is win32 c++ test result.\r\n";
}

/*****************************************函数体End******************************************************************/
