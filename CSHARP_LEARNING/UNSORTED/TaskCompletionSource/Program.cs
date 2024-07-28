var fd = new TaskCompletionSource<int>(5);

var action1 = new Action(async () =>
{
    await Task.Delay(5000);
    fd.SetResult(1);
});

var action2 = new Action(async () => 
{
    await fd.Task;

    await Console.Out.WriteLineAsync("Finished!");
});

action2();
action1();

Console.Read();
