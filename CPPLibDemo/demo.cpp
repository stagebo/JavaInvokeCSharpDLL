#ifdef MYLIBAPI  
#else  
#define  MYLIBAPI  extern "C" __declspec(dllimport)      
#endif 
MYLIBAPI char* getString(char* str);
MYLIBAPI char* noneInvokeDLL(char* str);
MYLIBAPI int intTest(int id);
#include <stdio.h>

//using namespace LibDemo;
using namespace LibDemo;
using namespace System;
char* getString(char* str)
{
	Function ^ fun = gcnew Function();
	String ^params = gcnew String(str);
	String ^result = fun->getString(params);
	return (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(result);

	//return str;
}
char* noneInvokeDLL(char* str)
{
	return str;
}
int intTest(int id)
{
	printf_s("c++ begin");
	Function ^ fun = gcnew Function();
	/*int result = fun->intTest(id);
	printf_s("cs result %d",result);*/
	return 15232;
	//return result;
}