// To find index of el 33 if array wiil be sorted
// So you can find all elements less than 33
using System.Collections;

var array = new int[] { 988, 666, 1050, 12, 1, 4, 6, 9, 755, 33, 67, 109, 586, 700 };

var searchedEl = 33;
var count = 0;

foreach (var item in array)
{
    if (item < searchedEl)
    {
        count++;
    }
}

Console.WriteLine(count);

Array.Sort(array);
foreach (var item in array)
{
    Console.Write($"[{item}] ");
}