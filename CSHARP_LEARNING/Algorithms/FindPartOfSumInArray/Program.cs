var array1 = new int[] { -1, -2, -3, -4, -5 };

var result = TwoSum(array1, -8);
Console.ReadLine();


int[] TwoSum(int[] nums, int target)
{
    for (var i = 0; i < nums.Length; i++)
    {
        var answer = target - nums[i];
        for (var j = 0; j < nums.Length; j++)
        {
            if (nums[j] == answer && i != j)
            {
                return new int[] { i, j };
            }
        }
    }

    return null;
}