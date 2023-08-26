var testGraph = new MyGraph
{
    Value = 1,
    Left = new MyGraph
    {
        Value = 2,
        Left = new MyGraph
        {
            Value = 3,
            Left = null,
            Right = null
        },
        Right = new MyGraph
        {
            Value = 4,
            Left = null,
            Right = null
        }
    },
    Right = new MyGraph
    {
        Value = 5,
        Left = new MyGraph
        {
            Value = 6,
            Left = null,
            Right = null
        },
        Right = new MyGraph
        {
            Value = 7,
            Left = null,
            Right = null
        }
    }
};

int i = 0;
RecursiveG(testGraph, ref i);
Console.WriteLine($"Sum - {i}");
Console.WriteLine($"Result (rec by parameter) - {Enumerable.Range(1, 7).Sum()}");

var res = RecursiveGByReturn(testGraph);
Console.WriteLine($"Result (re by return) - {res}");

void RecursiveG(MyGraph testGraph, ref int sum)
{
    if(testGraph != null)
    {
        sum = sum + testGraph.Value;
        Console.WriteLine(testGraph.Value);
        RecursiveG(testGraph.Left, ref sum);
        RecursiveG(testGraph.Right, ref sum);
    }
    else 
    {
        return;
    }
}

int RecursiveGByReturn(MyGraph testGraph)
{
    if (testGraph != null)
    {
        return testGraph.Value + RecursiveGByReturn(testGraph.Right) + RecursiveGByReturn(testGraph.Left);
    }
    else
    {
        return 0;
    }
}

class MyGraph
{
    public int Value { get; set; }

    public MyGraph? Left { get; set; }

    public MyGraph? Right { get; set; }
}