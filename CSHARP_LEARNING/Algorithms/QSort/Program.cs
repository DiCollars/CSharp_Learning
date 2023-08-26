var array = new List<int>() { 2, 0, 2, 1, 1, 0 };
var newArray = QSort(array);

foreach (var item in newArray)
{
    Console.Write($"{item} ");
}

List<int> QSort(List<int> arr)
{
    if (arr.Count < 2)
    {
        return arr;
    }

    var supportEl = arr[arr.Count/2];
    var less = arr.Where(x => x < supportEl).ToList();
    var greater = arr.Where(x => x > supportEl).ToList();

    return QSort(less).Union(new List<int> { supportEl })
                    .Union(QSort(greater)).ToList();
}
