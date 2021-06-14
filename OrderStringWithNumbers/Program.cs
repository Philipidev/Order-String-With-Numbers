using System;
using System.Linq;

namespace OrderStringWithNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] arrExample = { "Street 2A", "Street 3", "Street 4", "Street 3C", "Street 12", "Street 1B", "Street 1B1", "Street 1B2", "Street 1B2a", "Street 1B23", "Street 1", "Street 2", "Street 31", "Street 3BC", "Street 3478562387471298321", "Street 3378562387471298321", "1829678954691234610345341", "Street 3A", "Street 22C" };

            //Use OrderBy by Linq and call the custom Comparer class
            arrExample = arrExample.OrderBy(ex => ex, new OrderStringNumber()).ToArray();

            foreach (var ex in arrExample)
                Console.WriteLine(ex);

            Console.ReadLine();
        }
    }
}

