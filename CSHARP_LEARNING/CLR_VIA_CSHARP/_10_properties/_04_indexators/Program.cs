var array = new BitArray(new byte[] { 1, 8, 3, 6, 0, 13 });
Console.WriteLine(array[3]);

public sealed class BitArray
{
    public BitArray(byte[] byteArray)
    {
        this.byteArray = byteArray;
    }

    private readonly byte[] byteArray;

    public byte this[int index]
    {
        get 
        { 
            return byteArray[index]; 
        }
    }
}