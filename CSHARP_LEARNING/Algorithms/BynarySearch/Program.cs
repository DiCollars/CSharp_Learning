var tesCases = new List<int[]> 
{
    new int[] { 755, 988, 1050, 1, 4, 6, 9, 12, 33, 67, 109, 586, 666, 700 },
    new int[] { 586, 666, 700, 755, 988, 1050, 1, 4, 6, 9, 12, 33, 67, 109 },
    new int[] { 33, 67, 109, 586, 666, 700, 755, 988, 1050, 1, 4, 6, 9, 12, }
};

foreach (var tesCase in tesCases)
{
    var rotateNumber = GetRotationPoint(tesCase);
    Console.WriteLine(rotateNumber);
}

int GetRotationPoint(int[] nums)
{
    // your code
}

//var array = new int[] { 1, 4, 6, 9, 12, 33, 67, 109, 586 };
//var elementForSearch = 1;

//int startIndex = 0;
//int endIndex = array.Length - 1;

//int result = int.MinValue;

//var iteration = 1;

//while (startIndex <= endIndex)
//{
//    Console.WriteLine($"Iteration: {iteration}");
//    iteration++;

//    var arrayHalfIndex = (endIndex + startIndex) / 2;
//    var middle = array[arrayHalfIndex];

//    if (middle == elementForSearch)
//    {
//        startIndex = arrayHalfIndex;
//        endIndex = arrayHalfIndex;

//        result = arrayHalfIndex;
//        break;
//    }

//    if (middle > elementForSearch)
//    {
//        endIndex = arrayHalfIndex - 1;
//    }

//    if (middle < elementForSearch)
//    {
//        startIndex = arrayHalfIndex + 1;
//    }
//}

//Console.WriteLine(result);