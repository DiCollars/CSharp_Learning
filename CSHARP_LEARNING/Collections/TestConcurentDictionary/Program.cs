using System.Collections.Concurrent;

ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();

Task t1 = Task.Factory.StartNew(() =>
{
    for (int i = 0; i < 20; ++i)
    {
        var result = dictionary.TryAdd(i.ToString(), i.ToString());
        Console.WriteLine($"result: {result}");
        Thread.Sleep(100);
    }
});

Task t2 = Task.Factory.StartNew(() =>
{
    Thread.Sleep(300);
    foreach (var item in dictionary)
    {
        Console.WriteLine(item.Key + "-" + item.Value);
        Thread.Sleep(150);
    }
});

try
{
    Task.WaitAll(t1, t2);
    Console.ReadKey();
}
catch (AggregateException ex) // No exception
{
    Console.WriteLine(ex.Flatten().Message);
}