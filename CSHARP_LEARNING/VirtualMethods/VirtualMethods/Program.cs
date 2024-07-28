using System;

namespace VirtualMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var third = new Third();
            third.Method4();
        }
    }

    internal class First
    {
        public virtual void Method() => Console.WriteLine("first");

        public void Method2() => Method();
    }

    internal class Second : First
    {
        public override void Method() => Console.WriteLine("second");

        public void Method3()
        {
            Method();
            base.Method();
        }
    }

    internal class Third : Second
    {
        public override void Method() => Console.WriteLine("third");

        public void Method4()
        {
            Method();
            base.Method();

            Method3();
            Method2();
        }
    }
}
