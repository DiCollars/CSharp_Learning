int val = 0;
var locker = new object();

for (int i = 0; i < 6; i++)
{
    var temp = new Thread(Cal);
    temp.Name = $"Thread: {i}";
    temp.Start();
}

void Cal()
{
    bool acquiredLock = false;
    try
    {
        Monitor.Enter(locker, ref acquiredLock);

        val = 1;
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {val}");
            val++;
            Thread.Sleep(500);
        }
    }
    finally
    {
        if (acquiredLock)
        {
            Monitor.Exit(locker);
        }
    }
}