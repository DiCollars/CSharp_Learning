int val = 0;
var mutex = new Semaphore(3, 4);

for (int i = 0; i < 11; i++)
{
    var temp = new Thread(Cal);
    temp.Name = $"Thread: {i}";
    temp.Start();
}

void Cal()
{
    mutex.WaitOne();

    Console.WriteLine($"Thread {Thread.CurrentThread.Name} enter the library!");
    Thread.Sleep(500);
    Console.WriteLine($"Thread {Thread.CurrentThread.Name} leave the library!");

    mutex.Release();
}