Console.Write("BackCount:");
BackCount(5);

var item = 8;
Console.WriteLine($"\nFacterial !{item} = {Facterial(item)}");

var array = new List<int>() { 2, 4, 6, 1, 5, 10, 12};
Console.WriteLine("Sum rec: " + Sum(array));

void BackCount(int val)
{
    Console.Write($"{val}... ");
    if (val == 1) return;
    BackCount(val - 1);
}

int Facterial(int val)
{
    if(val == 0)
    {
        return 1;
    }

    return val * Facterial(val - 1);
}

int Sum(List<int> array)
{
    if (array.Any() == false)
    {
        return 0;
    }

    var temp = array.First();
    array.Remove(temp);

    return temp + Sum(array);
}