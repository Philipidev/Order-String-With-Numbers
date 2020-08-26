using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderStringWithNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] arrExample = { "Street 2A", "Street 3", "Street 4", "Street 3C", "Street 12", "Street 1B", "Street 1", "Street 2", "Street 3A1", "Street 3BC", "Street 3A","Street 22C" };

            //Use OrderBy by Linq and call the custom Comparer class
            arrExample = arrExample.OrderBy(ex => ex, new OrderStringNumber()).ToArray();

            foreach(var ex in arrExample)
                Console.WriteLine(ex);

            Console.ReadLine();
		}
    }
}

