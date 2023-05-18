using System;

namespace CalculatorWcfClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            var result = client.Add(5.5, 1.0);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
