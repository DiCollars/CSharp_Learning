public enum Option
{
    [Description("You can use it")]
    Safe = 1001,

    [Description("We didn't test it")]
    Untested = 1002,

    [Description("It is useless")]
    Evil = 1003
}

public static class OptionExtensions
{
    public static string GetDescription(this Option option)
    {
        try
        {
            var customAttr = option.GetType()
                .GetMember(option.ToString())
                .First()
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .First();

            return ((DescriptionAttribute)customAttr).Text;
        }
        catch (Exception ex)
        {
            return "Without description";
        }
    }
}

public class DescriptionAttribute : Attribute
{
    public DescriptionAttribute(string text)
    {
        Text = text;
    }

    public string Text { get; private set; }
}

class DemoClass
{
    static void Main(string[] args)
    {
        Option option = Option.Safe;
        Console.WriteLine(option.GetDescription());
    }
}