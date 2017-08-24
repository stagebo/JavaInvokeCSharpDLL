import com.sun.jna.Library;
import com.sun.jna.Native;
/**
 * 需要引入jna-4.4.0.jar 和 jna-platform-4.4.0
 * 包下载地址：https://github.com/java-native-access/jna
 * @author WANYONGBO
 *
 */
public class HelloWorld {
	/**
	 * 调用示例
	 * @param args
	 * @throws Exception
	 */
	public static void main(String[] args) throws Exception {
		CLibrary1 cc = CLibrary1.INSTANCE;
		System.out.println("传递与返回int测试："+cc.add(5, 3));
		System.out.println("传递bool测试："+cc.reverse(true));
		//System.out.println("传递返回stringByUsingString测试"+cc.usingString("java params"));
		System.out.println("传递返回stringByChar*测试："+cc.getString("java params"));
		String[] s=new String[2];
		System.out.println("数组对象测试："+cc.stringArrayTest(s));
		System.out.println("数组返回结果测试："+s[0]+"---"+s[1]);
		System.out.println("out参数测试："+cc.outTest());
	}
}
/**
 * 必要接口，必须包含INSTANCE实例和需要调用的方法声明。
 * @author WANYONGBO
 *
 */
interface CLibrary1 extends Library {
	CLibrary1 INSTANCE = (CLibrary1) Native.loadLibrary("G:\\vs workplace\\JavaToCs\\x64\\Debug\\DllTest01",
			CLibrary1.class);

	/*需要调用的方法*/
	public int add(int a, int b);
	public String getString(String str);
	public boolean reverse(boolean b);
	//public String usingString(String str);
	public boolean stringArrayTest(String[] str);
	public boolean outTest();
	
}
