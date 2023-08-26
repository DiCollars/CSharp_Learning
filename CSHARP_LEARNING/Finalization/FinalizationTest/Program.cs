CreateReader();

GC.Collect();

Console.Read();

void CreateReader()
{
    var r = new Reader();
}

class Reader
{
    ~Reader()
    {
        Page = 0;
        Console.WriteLine("Closing some unmanage resource...");
    }

    //protected override void Finalize()
    //{
    //    try
    //    {
    //        Page = 0;
    //        Console.WriteLine("Closing some unmanage resource...");
    //    }
    //    finally
    //    {
    //        base.Finalize();
    //    }
    //}

    public int Page { get; set; } = 0;

    public void Read()
    {
        Page++;
        Console.WriteLine("Reading some unmanage resource...");
    }
}