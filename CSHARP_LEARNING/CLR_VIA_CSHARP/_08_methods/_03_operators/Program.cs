var text = "hello world!";
var sprStr = new SuperString("99");

var res = sprStr + text;

Console.WriteLine(res);

class SuperString
{
    public SuperString(string val)
    {
        Str = val;
    }

    public string Str { get; private set; }

    public override string ToString()
    {
        return Str + "_lol";
    }

    public static SuperString operator + (SuperString op1, string op2)
    {
        return new SuperString(op1.Str + op2);
    }
}