//C# always truncates the result int val = (int) 5.5 //5
int seven0 = (int)7.9;
int seven1 = (int)7.5;
int seven2 = (int)7.1;
Console.WriteLine(
    $"int seven0 = (int)7.9; //{seven0}\n" +
    $"int seven1 = (int)7.5; //{seven1}\n" +
    $"int seven2 = (int)7.1; //{seven2}\n");

//Literals are instances
Console.WriteLine(128.ToString() + 555.ToString() + '\n');

//if you have an expression consisting of literals, the compiler is able to evaluate the expression
//at compile time, improving the application’s performance.
bool found = false; // Generated code sets found to 0
int value = 100 + 20 + 3; // Generated code sets value to 123
string str = "hell" + "o world"; // Generated code sets str to "hello world"

//overflow
byte byt = 100;
Console.WriteLine("Byte value = " + byt);
//to make compiler check it - add <CheckForOverflowUnderflow>true</CheckForOverflowUnderflow> in PropertyGroup
try
{
    byt = (byte)(byt + 156);
}
catch (Exception ex)
{
    Console.WriteLine("Byte + 156");
    Console.WriteLine("Byte value = " + byt + " cos byte capacity is 0 - 255 (256)");
}

//If you want to - you can change the overflow check option by unchecked\checked
int overflovedInt32 = unchecked((int)2_147_483_648);
Console.WriteLine($"int overflovedInt32 = unchecked((int)2_147_483_648); //{overflovedInt32}");
//or like this
unchecked
{
    overflovedInt32 += (int)(2_147_483_648 + 2_147_483_648);
    Console.WriteLine($"overflovedInt32 = unchecked((int)(overflovedInt32 + 2_147_483_648 + 2_147_483_648)); //{overflovedInt32}");
}

try
{
    overflovedInt32 = checked((int)(overflovedInt32 + 2_147_483_648 + 2_147_483_648));
}
catch (Exception)
{
    Console.WriteLine($"overflovedInt32 = checked(overflovedInt32 + 2_147_483_647); //{overflovedInt32}");
}
//or
try
{
    checked
    {
        overflovedInt32 = (int)(overflovedInt32 + 2_147_483_648 + 2_147_483_648);
    }
}
catch (Exception)
{
}

//So, Jheffry tips about checked\unchecked
// 1. don't use unsigned types (sbyte, uint, ulong, etc.)
// 2. use checked when you need to get clients data and do something whith this data (which actually - can be wrong and it's out of your control definitely)
// 3. use unchecked if overflow doesn't matter (like calculating a checksum)
// 4. in code without any checked\unchecked operators should been throwed the overflow exception

//decimal is special type - not primitive, so checked\unchecked doesn't matter - every time it will checked in any case
//±1.0 x 10^-28 to ±7.9228 x 10^28
decimal money = 79228000000000000000000000000M;
try
{
    unchecked
    {
        Console.WriteLine(money + 1000000000000000000000000M); //OverflowException
    }
}
catch (Exception)
{
    Console.WriteLine("decimal OverflowException!");
}

