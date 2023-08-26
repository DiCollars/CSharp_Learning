var array = new int[] { 1, 8, 19, 33, 4, 7, 10, 90 };

for (int i = 0; i < array.Length; i++)
{
    var currentEl = array[i];
    for (int j = 0; j < array.Length; j++)
    {
        if (currentEl < array[j])
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

foreach (var item in array)
{
    Console.WriteLine($"{item}\t");
}

//O(n*n) so-so...