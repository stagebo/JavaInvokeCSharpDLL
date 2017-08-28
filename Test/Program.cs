using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {


            var tdyh = new TDYH.TDYHDecorator();
            var result = tdyh.Do();
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
