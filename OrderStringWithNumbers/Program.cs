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
            string[] arrExample = { "Barragem da Vertende do Santo Antônio", "Dique 1", "Dique 10B1", "Dique 11", "Dique 12", "Dique 13", "Dique 14A", "Dique 14B", "Dique 18", "Dique 19", "Dique 19A", "Dique 1A", "Dique 1B", "Dique 1C", "Dique 6A", "Dique 27", "Dique 28", "Dique 29", "Dique 6C", "Sítio Belo Monte", };

            //Use OrderBy by Linq and call the custom Comparer class
            arrExample = arrExample.OrderBy(ex => ex, new OrderStringNumber()).ToArray();

            foreach(var ex in arrExample)
                Console.WriteLine(ex);

            Console.ReadLine();
		}
    }
}

