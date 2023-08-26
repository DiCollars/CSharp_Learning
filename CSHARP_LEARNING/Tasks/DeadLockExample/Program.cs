var locker1 = new object();
var locker2 = new object();

var a = new A();
var b = new B();

Task.Run(() => a.PerformOperation(locker1, locker2));
Task.Run(() => b.PerformOperation(locker1, locker2));

Console.ReadKey();

class A
{
    public void PerformOperation(object syncObject1, object syncObject2)
    {
        Console.WriteLine("A loc 1 BEFORE");

        lock (syncObject1)
        {
            Console.WriteLine("A loc 1 IN");

            Thread.Sleep(1000);

            Console.WriteLine("A loc 2 BEFORE");

            lock (syncObject2)
            {
                Console.WriteLine("A loc 2 IN");

                Thread.Sleep(1000);
            }
            Console.WriteLine("A loc 2 EXIT");
        }
        Console.WriteLine("A loc 1 EXIT");
    }
}

class B
{
    public void PerformOperation(object syncObject1, object syncObject2)
    {
        Console.WriteLine("B loc 2 BEFORE");

        lock (syncObject2)
        {
            Console.WriteLine("B loc 2 IN");

            Thread.Sleep(1000);
            Console.WriteLine("B loc 1 BEFORE");

            lock (syncObject1)
            {
                Console.WriteLine("B loc 1 IN");
                Thread.Sleep(1000);
            }
            Console.WriteLine("B loc 1 EXIT");
        }
        Console.WriteLine("B loc 2 EXIT");
    }
}