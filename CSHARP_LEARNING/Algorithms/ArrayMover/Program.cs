var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };

Rotate(array, 3);

foreach (var item in array)
{
    Console.Write($"{item} - ");
}

void Rotate(int[] nums, int k)
{
    while (k > 0)
    {
        Mover(nums);

        k--;
    }
}

void Mover(int[] nums)
{
    var lst = nums[nums.Length - 1];
    var saver = nums[0];
    var nexter = 0;
    for (int i = 0; i < nums.Length - 1; i++)
    {
        nexter = nums[i + 1];

        nums[i + 1] = saver;

        saver = nexter;
    }

    nums[0] = lst;
}