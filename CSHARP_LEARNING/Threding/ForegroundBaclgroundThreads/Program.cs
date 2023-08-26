Thread th = new Thread(() => 
{
    Thread.Sleep(3000);
    Console.WriteLine("Only if thread is active!");
});

th.IsBackground = false;

th.Start();
Console.WriteLine("Return");