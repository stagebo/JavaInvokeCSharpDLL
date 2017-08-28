/**********************************
main.cpp文件
2017-8-23 16:44:06
实现头文件内的函数，实现对c#动态链接库的调用。
方法名保持和java接口内部方法名一致。
变量类型对应关系访问：http://blog.csdn.net/lovesomnus/article/details/45073343
**********************************************/
#include "stdio.h"    
#include <string>
using namespace Common;
using namespace std;
using namespace System;
#define MYLIBAPI  extern   "C"     __declspec( dllexport )      

#include "main.h"  

int add(int a, int b) {
	CommonFunction ^common = gcnew CommonFunction();
	int result = common->Add(a, b);
	return result;
}
char* getString(char* str)
{
	CommonFunction^com = gcnew CommonFunction();
	System::String^ p1 = gcnew System::String(str);
	String ^re= com->getString(p1);

	char * resu = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(re);
	return resu;
}
int reverse(int b)
{
	if (b == 0)return 1;
	return 0;
}
int stringArrayTest(char* str[])
{
	str[0] = "first";
	str[1] = "second";

	return 1;
}
int outTest() 
{
	CommonFunction ^common = gcnew CommonFunction();
	int x;
	int re = common->outTest(x);
	printf_s("c++ pro: get out param x=%d\r\n",x);
	return re;
}
