for (int i = 0; i < 15; i++)
{
    var myClass = new MyClass() { A = i, B = i };
    Console.WriteLine(myClass.GetHashCode());
    Thread.Sleep(1000);
}

internal class MyClass
{
    public int A, B;

    public override int GetHashCode()
    {
        return A + B;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        return base.Equals(obj);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}