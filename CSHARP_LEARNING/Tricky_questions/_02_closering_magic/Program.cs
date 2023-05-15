//What I will see in console?
var funcs = new List<Action>();

for (int i = 0; i < 5; i++)
{
    funcs.Add(() => Console.WriteLine(i));
}

foreach (var func in funcs)
{
    func();
}
