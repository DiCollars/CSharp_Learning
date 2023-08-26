Console.WriteLine("Start bound oper!");
ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);

Console.WriteLine("Main doing some goods!");
Thread.Sleep(5000);


static void ComputeBoundOp(object state)
{
    Console.WriteLine(state);
    Thread.Sleep(3000);
}

