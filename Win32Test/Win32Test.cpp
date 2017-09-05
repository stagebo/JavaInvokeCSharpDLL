// Win32Test.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>
using namespace std;
using namespace TDYH;
using namespace System;

int main()
{
	TDYHDecorator ^ t = gcnew TDYHDecorator();
	String^ re = t->Do(gcnew String(""), gcnew String(""), gcnew String(""));
	char * result = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToCoTaskMemAnsi(re);
	cout << endl;
	printf_s("the result is :%s",result);
	while (1);
}

