int val = 0;
var mutex = new Mutex();

for (int i = 0; i < 6; i++)
{
    var temp = new Thread(Cal);
    temp.Name = $"Thread: {i}";
    temp.Start();
}

void Cal()
{
    mutex.WaitOne();

    val = 1;
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {val}");
        val++;
        Thread.Sleep(500);
    }

    mutex.ReleaseMutex();
}