var test = new Test(999);
test.SetState(1);
Console.WriteLine(test);

public partial class Test
{
    public Test(int state)
    {
        this.state = state;
    }

    private int state;

    partial void Show();

    public void SetState(int newState)
    {
        Show();
        state = newState;
    }

    public override string ToString()
    {
        return state.ToString();
    }
}

public partial class Test
{
    partial void Show()
    {
        Console.WriteLine("Old state is - " + state);
    }
}