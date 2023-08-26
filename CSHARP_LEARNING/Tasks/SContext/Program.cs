await Task.Run(() => 
{
    var ctx = SynchronizationContext.Current;

    Console.WriteLine($"{Task.CurrentId} {Thread.CurrentThread.ManagedThreadId}");

    var fd = 1;
}); await SomeWork();

async Task SomeWork()
{
    await Task.Delay(2000);

    var currentSContext = SynchronizationContext.Current;

    Console.WriteLine($"{Task.CurrentId} {Thread.CurrentThread.ManagedThreadId}");

    await AnotherWork(currentSContext);
}

async Task AnotherWork(SynchronizationContext ctx)
{
    SynchronizationContext.SetSynchronizationContext(ctx);

    await Task.Delay(2000);

    Console.WriteLine($"{Task.CurrentId} {Thread.CurrentThread.ManagedThreadId}");
}