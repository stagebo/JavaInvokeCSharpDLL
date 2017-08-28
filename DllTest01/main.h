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


MYLIBAPI int add(int a,int b); //添加函数声明 
MYLIBAPI char* getString(char* str); //添加函数声明 
MYLIBAPI int reverse(int b);
MYLIBAPI int stringArrayTest(char** str);
MYLIBAPI int outTest();