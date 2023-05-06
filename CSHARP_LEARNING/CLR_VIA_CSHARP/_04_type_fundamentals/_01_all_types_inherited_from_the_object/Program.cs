var method = () =>
{
    var el = new Element();
    var elCopy = el.ShallowCopy();

    Console.WriteLine($"Original:{el.Number} Copy:{elCopy.Number}");

    Console.WriteLine($".ToString() -> {el.ToString()}");
    Console.WriteLine($".GetType().FullName -> {el.GetType().FullName}");

    Console.WriteLine($"el.Equals(elCopy); //{el.Equals(elCopy)}");

    try
    {
        Console.WriteLine($"el.Equals(77); //{el.Equals(77)}");
    }
    catch (ArgumentException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message + "\n Can't do: el.Equals(77);");
        Console.ResetColor();
    }
};

method();

//Only for launch Finaliser
var counter = 1;
while (true)
{
    var link = new Element() { Number = counter };
    ++counter;
}

Console.ReadKey(false);

public class Element // : object
{
    ~Element()
    {
        Console.WriteLine($"Number:{Number} Finalizator!");
    }

    //Object state
    public int Number { get; set; } = 1;

    public decimal Harder = 0.485M;

    public override string ToString()
    {
        //same as this.GetType().FullName
        return base.ToString()!;
    }

    public new Type GetType()
    {
        return new Int32().GetType();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Element)
        {
            throw new ArgumentException("Argument should be Element type!");
        }

        return ((Element)obj).Number == this.Number;
    }

    public override int GetHashCode()
    {
        return Number * 66;
    }

    public Element ShallowCopy()
    {
        return (this.MemberwiseClone() as Element)!;
    }
}