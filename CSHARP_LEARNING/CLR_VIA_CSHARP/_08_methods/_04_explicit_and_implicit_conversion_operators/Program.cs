var intValue = 5;
var rational = new Rational(10);

Rational rationaledInt = (Rational)intValue;
int intedRational = rational;

Console.WriteLine($"Rational {rationaledInt}");
Console.WriteLine($"int {intedRational}");

public sealed class Rational
{
    public int Value { get; private set; }

    public Rational(int value)
    {
        Value = value;
    }

    public static explicit operator Rational(int value)
    {
        return new Rational(value);
    }

    public static implicit operator int(Rational rational)
    {
        return rational.Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
