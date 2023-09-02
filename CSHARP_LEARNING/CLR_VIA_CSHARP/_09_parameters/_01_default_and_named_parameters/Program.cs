MyClass myClass = new MyClass();
string res = string.Empty;

myClass.MyMethod(result: ref res);
//System.Runtime.InteropServices.OptionalAttribute
//System.Runtime.InteropServices.DefaultParameterValueAttribute
myClass.MyMethod(result: ref res, arg1: 50);
myClass.MyMethod(result: ref res, arg3: Guid.NewGuid());
myClass.MyMethod(result: ref res, arg1: 1, arg2: "kek", arg3: Guid.NewGuid());

#region Test
//lol
#endregion

Console.WriteLine(res);

Console.WriteLine(myClass.ClassName);

/// <summary>
/// lol
/// </summary>
public class MyClass
{
    public string ClassName { get; private set; }

    public MyClass(string className = nameof(MyClass))
    {
        ClassName = className;
    }

    public void MyMethod(ref string result, int arg1 = 0, string? arg2 = null, Guid arg3 = default)
    {
        result = $"{arg1} {arg2} {arg3}";
        Console.WriteLine(result);
    }
}