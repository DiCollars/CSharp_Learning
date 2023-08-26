using System;

// Point is a value type.
internal struct Point
{
    private Int32 m_x, m_y;

    public Point(Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }

    public void Change(Int32 x, Int32 y)
    {
        m_x = x; m_y = y;
    }

    public override String ToString()
    {
        return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
    }
}

public sealed class Program
{
    public static void Main()
    {
        Point p = new Point(1, 1); //1, 1
        Console.WriteLine(p); //boxing

        p.Change(2, 2); //2, 2
        Console.WriteLine(p); //boxing

        Object o = p; //boxing
        Console.WriteLine(o); //2, 2

        // at this moment - Point unboxed in temporary value in the stack
        ((Point)o).Change(3, 3); //unboxing
        Console.WriteLine(o);

        var temp = ((Point)o);
        temp.Change(4, 4);
        Console.WriteLine(temp);

        //  .method public hidebysig static void Main() cil managed
        //    {
        //  .entrypoint // Code size       74 (0x4a)
        //  .maxstack  4
        //  .locals init (valuetype Point V_0, valuetype Point V_1)
        //  IL_0000:  ldloca.s V_0
        //  IL_0002:  ldc.i4.1
        //  IL_0003:  ldc.i4.1
        //  IL_0004:  call instance void Point::.ctor(int32, int32)
        //  IL_0009:  ldloc.0
        //  IL_000a:  box Point
        //  IL_000f:  call void [System.Console] System.Console::WriteLine(object)
        //  IL_0014:  ldloca.s V_0
        //  IL_0016:  ldc.i4.2
        //  IL_0017:  ldc.i4.2
        //  IL_0018:  call instance void Point::Change(int32, int32)
        //  IL_001d:  ldloc.0
        //  IL_001e:  box Point
        //  IL_0023:  call void [System.Console] System.Console::WriteLine(object)
        //  IL_0028:  ldloc.0
        //  IL_0029:  box Point
        //  IL_002e:  dup
        //  IL_002f:  call void [System.Console] System.Console::WriteLine(object)
        //  IL_0034:  dup
        //  IL_0035:  unbox.any Point
        //  IL_003a:  stloc.1
        //  IL_003b:  ldloca.s V_1
        //  IL_003d:  ldc.i4.3
        //  IL_003e:  ldc.i4.3
        //  IL_003f:  call instance void Point::Change(int32, int32)
        //  IL_0044:  call void [System.Console] System.Console::WriteLine(object)
        //  IL_0049:  ret
        //} 
        // end of method Program::Main
    }
}