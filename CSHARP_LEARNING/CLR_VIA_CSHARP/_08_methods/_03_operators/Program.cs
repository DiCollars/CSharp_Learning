var text = "hello world!";
var sprStr = new SuperString("99");

var res = sprStr + text;
var res2 = text + sprStr;

Console.WriteLine(res);
Console.WriteLine(res2);
Console.WriteLine(text > sprStr);

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

    public static SuperString operator +(SuperString op1, string op2)
    {
        return new SuperString(op1.Str + op2);
    }

    public static SuperString operator +(string op1, SuperString op2)
    {
        return new SuperString(op1 + op2.Str);
    }

    public static bool operator >(SuperString op1, SuperString op2)
    {
        return op1.Str.Length > op2.Str.Length;
    }

    public static bool operator <(SuperString op1, SuperString op2)
    {
        return op1.Str.Length < op2.Str.Length;
    }

    public static bool operator >(string op1, SuperString op2)
    {
        return op1.Length > op2.Str.Length;
    }

    public static bool operator <(string op1, SuperString op2)
    {
        return op1.Length < op2.Str.Length;
    }

    public static bool operator >(SuperString op1, string op2)
    {
        return op1.Str.Length > op2.Length;
    }

    public static bool operator <(SuperString op1, string op2)
    {
        return op1.Str.Length < op2.Length;
    }
}