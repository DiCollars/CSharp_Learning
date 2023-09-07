using System.Text;

var str1 = "Good";
Console.WriteLine(Concat(str1, null, "-is-", "the", "-good", "-", "lol"));

var now = DateTime.Now;
Console.WriteLine(Concat(now.AddHours(-10), now, now.AddHours(+10)));
Console.WriteLine(Concat(1, 2, 3, 4, 5, 6));

//string Concat(params string[] substrings)
//{
//    return string.Join(string.Empty, substrings);
//}

//string Concat(string[] substrings)
//{
//    return string.Join(string.Empty, substrings);
//}

string Concat<T>(params T[] parameters)
{
    var result = new StringBuilder();
    for (int i = 0; i < parameters.Length; i++)
    {
        result.Append(parameters[i]?.ToString());
    }

    return result.ToString();
}
