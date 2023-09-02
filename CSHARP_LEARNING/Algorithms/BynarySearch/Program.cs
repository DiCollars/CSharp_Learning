//Find the broken index in array using binary search

var tesCases = new List<int[]> 
{
    new int[] { 755, 988, 1050, 1, 4, 6, 9, 12, 33, 67, 109, 586, 666, 700 },
    new int[] { 586, 666, 700, 755, 988, 1050, 1, 4, 6, 9, 12, 33, 67, 109 },
    new int[] { 33, 67, 109, 586, 666, 700, 755, 988, 1050, 1, 4, 6, 9, 12, },
    new int[] { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
    new int[] { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
    new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
    new int[] { 9, 1, 2, 3, 4, 5, 6, 7, 8 },
    new int[] { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
    new int[] { 478, 577, 578, 600, 800, 1000, 150, 220, 300 },
    new int[] { -2, -1, 0, 1, 2, 3, 4, -5, -4, -3 },
    new int[] { 5, 7, 9, 11, -7, 0, 2, 4 },

    new int[] { 5, 1, 2, 3, 4 },
    //          0     x  <  0 == true - go left

    new int[] { 3, 4, 5, 1, 2 }
    //          0     x  <  0 == false - go right
};

foreach (var tesCase in tesCases)
{
    //var index = BinarySearchIndex(tesCase, tesCase[0], 0, tesCase.Length - 1);
    var index = GetRotationPointBinary(tesCase);
    Console.WriteLine(index);
    //var value = tesCase[index];
    //Console.WriteLine($"array[{index}] == {value}");
}

int GetRotationPointBinary(int[] nums)
{
    var li = 0; var ri = nums.Length - 1;
    while (li < ri)
    {
        var center = li + (ri - li) / 2;
        if (nums[center] > nums[ri])
            li = center + 1;
        else
            ri = center;
    }

    return nums[li];
}

int BinarySearchIndex(int[] nums, int leftValue, int first, int last)
{
    var midIndex = (first + last) / 2;
    var midEl = nums[midIndex];

    if (IsBroken(nums, midIndex))
    {
        return midIndex;
    }
    else
    {
        if (leftValue > midEl)
        {
            return BinarySearchIndex(nums, midEl, first, midIndex - 1);
        }
        else
        {
            return BinarySearchIndex(nums, midEl, midIndex + 1, last);
        }
    }
}

bool IsBroken(int[] nums, int elIndex)
{
    var leftNeighbrIndex = elIndex - 1;

    if(leftNeighbrIndex >= 0)
    {
        return nums[elIndex] < nums[leftNeighbrIndex];
    }
    else
    {
        return false;
    }
}
