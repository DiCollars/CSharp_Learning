int x = 0;
var locker = new string("lol");

for (int i = 0; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Thread {i}";
    myThread.Start();
}

void Print()
{
    lock(locker)
    {
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
    }
}