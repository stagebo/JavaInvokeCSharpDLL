/**********************************
mian.h文件
2017-8-23 16:44:19
声明需要被java调用的方法，该方法和java接口内部方法保持一致
预处理语句目的是暴露函数供外部调用。
************************/
#ifdef MYLIBAPI  
#else  
#define  MYLIBAPI  extern "C" __declspec(dllimport)      
#endif  


MYLIBAPI int add(int a, int b); //添加函数声明 
MYLIBAPI char* Do(char* connStr, char* dept, char* gchid); //添加函数声明 #pragma once

/**********************************
main.cpp文件
2017-8-23 16:44:06
实现头文件内的函数，实现对c#动态链接库的调用。
方法名保持和java接口内部方法名一致。
变量类型对应关系访问：http://blog.csdn.net/lovesomnus/article/details/45073343
**********************************************/
#include "stdio.h" 
#include <string>
#include <iostream>
using namespace std;
using namespace Common;
using namespace ComLib;
using namespace std;
using namespace System;
using namespace TDYH;

int add(int a, int b) {
	CommonFunction ^common = gcnew CommonFunction();
	int result = common->Add(a, b);
	return result;
}

char* Do(char* connStr, char* dept, char* gchid)
{
	cout << "this is c++ program\r\n";
	TDYHDecorator ^ tdyhDecorator = gcnew TDYHDecorator();
	String ^resultString = tdyhDecorator->Do();
	char* resultChar = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(resultString);
	return resultChar;
}