//What we will see in the console?
var tasks = Enumerable.Range(1, 30).Select(_ => GetUserId(_));//.ToList();

Console.ReadKey();

async Task<int> GetUserId(int age)
{
    await Task.Delay(age * 200);
    Console.WriteLine($"User id: {age}");

    return await Task.FromResult(age);
}
