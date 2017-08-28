// Win32Test.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
using namespace TDYH;
using namespace System;

int main()
{
	TDYHDecorator ^tdyh = gcnew TDYHDecorator();
	String ^ result = tdyh->Do("","","");
	char* out = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(result);
	printf_s("result:%s",out);
	while (1);
}

