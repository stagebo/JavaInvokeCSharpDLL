/**********************************
main.cpp文件
2017-8-23 16:44:06
实现头文件内的函数，实现对c#动态链接库的调用。
方法名保持和java接口内部方法名一致。
变量类型对应关系访问：http://blog.csdn.net/lovesomnus/article/details/45073343
**********************************************/
#include "stdio.h"   
using namespace TDYH;
using namespace System;
char* Do(char* connStr, char* dept, char* gchid)
{
	TDYHDecorator ^ tdyhDecorator = gcnew TDYHDecorator();
	String ^resultString = tdyhDecorator->Do();
	char* resultChar = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(resultString);
	return resultChar;
}