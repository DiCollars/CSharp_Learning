var list = new List<int>() { 4, 95, 1, 45, 34, 11, 88, 905, 500};

//O(n*n) - not best one...
var result = SelectionSerch(list);

foreach (var item in result)
{
    Console.WriteLine($"{item}\t");
}

List<int> SelectionSerch(List<int> lis)
{
    var newList = new List<int>(lis.Count);

    while (lis.Any())
    {
        var smallest = FindSmallest(lis);

        list.Remove(smallest);

        newList.Add(smallest);
    }

    return newList;
}

int FindSmallest(List<int> list)
{
    var min = list[0];
    for (int i = 1; i < list.Count; i++)
    {
        if (list[i] < min)
        {
            min = list[i];
        }
    }

    return min;
}