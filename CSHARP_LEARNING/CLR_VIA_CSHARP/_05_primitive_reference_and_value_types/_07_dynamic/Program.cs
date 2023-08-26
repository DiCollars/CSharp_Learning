dynamic int32 = 0;
int number = int32;
Console.WriteLine(number);

dynamic value;

for (int i = 0; i < 2; i++)
{
    value = (i == 0) ? 5 : "A";
    value += value;
    Display(value);
}

try
{
    dynamic d = 123;
    var result = Display(d);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static public partial class Program
{
    static void Display(int value) { Console.WriteLine(value); }
    static void Display(string value) { Console.WriteLine(value); }
}
