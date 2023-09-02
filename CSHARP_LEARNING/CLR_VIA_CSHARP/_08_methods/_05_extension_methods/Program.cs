string str = "lol-kek";
string newStr = str.Add('☺');

//string tester = null;
//tester.Add('1');
//tester.ToCharArray();

Console.WriteLine(str);
Console.WriteLine(newStr);
Console.WriteLine(ReferenceEquals(newStr, str));

Func<char, string> add = str.Add;

Console.WriteLine(add('5'));

public static class StringExtension
{
    public static string Add(this string str, char symbol)
    {
        //if(str is null) throw new ArgumentNullException(nameof(str));
        //if(str.Length <= 0) throw new ArgumentNullException(nameof(str));

        var arrayLength = str.Length;
        var newArray = new char[arrayLength + 1];

        for ( int i = 0; i < str.Length; i++ )
        {
            newArray[i] = str[i];
        }

        newArray[arrayLength] = symbol;

        return string.Join(string.Empty, newArray)!;
    }
}

