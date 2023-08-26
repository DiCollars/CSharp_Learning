var productList = new int[] { 1, 1, 1, 2, 2, 5, 4, 7, 7, 7, 9, 3, 9, 18, 9};
var dict = new Dictionary<int, int>();

//Builds hash table to know how many items in the product list
for (int i = 0; i < productList.Length; i++)
{
    if (dict.ContainsKey(productList[i]))
    {
        dict[productList[i]] = dict[productList[i]] + 1;
    }
    else
    {
        dict.Add(productList[i], 1);
    }
}

var costResult = 0;

//Getting sum with condition of '3 for 2 price'
foreach(var item in dict)
{
    if (item.Value == 3)
    {
        costResult += item.Key * 2;
    }
    else
    {
        costResult += item.Key * item.Value;
    }
}

Console.WriteLine(costResult);
