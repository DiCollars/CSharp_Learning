CreateReader();

//GC.Collect();

Console.Read();

void CreateReader()
{
    using (var r = new Reader())
    {
        r.Read();
    }

    //Reader? r = null;
    //try 
    //{
    //    var r = new Reader();
    //    r.Read();
    //}
    //finally 
    //{
    //    r?.Dispose();
    //}
}

class Reader : IDisposable
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Page = 0;
        Console.WriteLine("Closing some unmanage resource...");
    }

    public void Read()
    {
        Page++;
        Console.WriteLine("Reading some unmanage resource...");
    }
}