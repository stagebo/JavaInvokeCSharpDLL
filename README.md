# JavaToCs
##时间：2017-8-23 16:38:16
##目的：java调用c#动态链接库
##工具：JNA
##简要流程：
	JAVA---->JNA---->C++  ---->C#


##项目结构
	Common//c#
		CommonFunction//业务逻辑类
		Invoke.java//java示例文件
	DllTest01//c++
		头文件
			main.h
		源文件
			main.cpp
			


##实现跨语言调用的两种方式：
	1、JNI 简陋，古老  java<--->c双向调用
	2、JNA 强大，集成  java---->c单方面调用，其基础是JNI
 
##jna中间件开源项目：
	https://github.com/java-native-access/jna
##示例说明blog：
	http://blog.csdn.net/lovesomnus/article/details/45073343
##c++调用c#：
	1、将c++项目改成clr公共运行时
	2、using namespace 命名空间名
	3、使用gcnew获得对象，对象名前面需要加^，开始访问


##注意事项：
	1、jdk版本要与dll版本一致，不然会报加载dll失败异常（找不到dll）
	2、引用文件要拷贝到jdk的bin目录下。(无效内存访问异常)
	3、类型转换要参考jna api开发规范
	4、无效内存访问异常还可能由类型异常引发，比如java里面的String对应c++里面的char*
	5、c# 动态链接库项目需要强制签名、com可见、注册。

