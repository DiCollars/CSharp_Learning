using System.Collections;

public class Test
{
    public Test(int val)
    {
        a = val;
    }

    public int a;
}

struct Point
{
    public Int32 x, y;
    public override int GetHashCode()
    {
        //return 5;
        return base.GetHashCode();
    }

    public object Clone()
    {
        return base.MemberwiseClone();
    }
}

internal struct Point2 : IComparable
{
    private readonly Int32 m_x, m_y;

    // Constructor to easily initialize the fields
    public Point2(Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }

    // Override ToString method inherited from System.ValueType
    public override String ToString()
    {
        // Return the point as a string. Note: calling ToString prevents boxing
        return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString()); //In last .net thing with base.ToString() doest't work - I tried, no boxing...
    }

    // Implementation of type-safe CompareTo method
    public Int32 CompareTo(Point2 other)
    {
        // Use the Pythagorean Theorem to calculate
        // which point is farther from the origin (0, 0)
        return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
        - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
    }

    // Implementation of IComparable's CompareTo method
    public Int32 CompareTo(Object o)
    {
        if (GetType() != o.GetType())
        {
            throw new ArgumentException("o is not a Point");
        }
        // Call type-safe CompareTo method
        return CompareTo((Point2)o);
    }
}

public sealed class Program
{
    public static void Main()
    {
        Console.WriteLine("Boxing!");
        // 1.Memory is allocated from the managed heap.The amount of memory allocated is the size
        // required by the value type’s fields plus the two additional overhead members(the type object
        // pointer and the sync block index) required by all objects on the managed heap.

        // 2.The value type’s fields are copied to the newly allocated heap memory.

        // 3.The address of the object is returned.This address is now a reference to an object; the value
        // type is now a reference type

        ArrayList a = new ArrayList();
        Point p; // Allocate a Point (not in the heap).

        for (Int32 i = 0; i < 10; i++)
        {
            p.x = p.y = i; // Initialize the members in the value type.
            a.Add(p);      // Box the value type and add the reference to the Arraylist.
        }

        foreach (var item in a)
        {
            Console.WriteLine($"x:{((Point)item).x} y:{((Point)item).y}");
        }

        //1.If the variable containing the reference to the boxed value type instance is null, a
        //NullReferenceException is thrown.

        //2.If the reference doesn’t refer to an object that is a boxed instance of the  , an
        //InvalidCastException is thrown.

        Point p2 = (Point)a[0];
        Console.WriteLine($"\nUnboxing! x:{p2.x} y:{p2.y}");

        Console.WriteLine($"\nTry to unbox value from Int32 to Int16!");
        Int32 x = 5;
        Object o = x; // Box x; o refers to the boxed object
        try
        {
            Int16 y = (Int16)o; // Throws an InvalidCastException
            Console.WriteLine($"y:{y}"); // Never fulfilled
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n");
        Point p3; // 0:0
        p3.x = p3.y = 1; //1:1
        Object o2 = p3; // Boxes p3; o2 refers to the boxed instance. 
        p3 = (Point)o2; // Unboxes o AND copies fields from boxed instance to stack variable
        p3.x = 2; // Change Point's x field to 2. Changes the state of the stack variable
        o2 = p3; // Boxes p; o2 refers to a new boxed instance 

        Console.WriteLine("\n");
        Int32 v = 5; // Create an unboxed value type variable.
        Object o3 = v; // o refers to a boxed Int32 containing 5.
        v = 123; // Changes the unboxed value to 123
        Console.WriteLine(v + ", " + (Int32)o3); // Displays "123, 5" 

        {
            //NOT BOXED!
            var fd = new Test(55);
            Console.WriteLine(fd.a);
        }

        {
            var testBoxing = new Point();

            Console.WriteLine("Call .GetType()"); //Boxing!
            var test1 = testBoxing.GetType();

            Console.WriteLine("Call .ToString()");
            var test2 = testBoxing.ToString();

            Console.WriteLine("Call .GetHashCode()");
            var test3 = testBoxing.GetHashCode();

            Console.WriteLine("Call .Equals()");
            var test4 = testBoxing.Equals(new Point()); //Boxing!

            Console.WriteLine("Call .MemberwiseClone()");
            var prototype = testBoxing.Clone();

            //  IL_0287:  newobj instance void Test::.ctor(int32)
            //  IL_028c:  ldfld int32 Test::a
            //  IL_0291:  call       void [System.Console]System.Console::WriteLine(int32)
            //  IL_0296:  ldloca.s V_17
            //  IL_0298:  initobj Point
            //  IL_029e:  ldstr      "Call .GetType()"
            //  IL_02a3:  call       void [System.Console]System.Console::WriteLine(string)
            //  IL_02a8:  ldloc.s V_17
            //  IL_02aa:  box Point
            //  IL_02af:  call instance class [System.Runtime] System.Type[System.Runtime] System.Object::GetType()
            //  IL_02b4:  pop
            //  IL_02b5:  ldstr      "Call .ToString()"
            //  IL_02ba:  call void [System.Console] System.Console::WriteLine(string)
            //  IL_02bf:  ldloca.s V_17
            //  IL_02c1:  constrained.Point
            //  IL_02c7:  callvirt instance string[System.Runtime] System.Object::ToString()
            //  IL_02cc:  pop
            //  IL_02cd:  ldstr      "Call .GetHashCode()"
            //  IL_02d2:  call void [System.Console] System.Console::WriteLine(string)
            //  IL_02d7:  ldloca.s V_17
            //  IL_02d9:  constrained.Point
            //  IL_02df:  callvirt instance int32[System.Runtime] System.Object::GetHashCode()
            //  IL_02e4:  pop
            //  IL_02e5:  ldstr      "Call .Equals()"
            //  IL_02ea:  call void [System.Console] System.Console::WriteLine(string)
            //  IL_02ef:  ldloca.s V_17
            //  IL_02f1:  ldloca.s V_18
            //  IL_02f3:  initobj Point
            //  IL_02f9:  ldloc.s V_18
            //  IL_02fb:  box Point
            //  IL_0300:  constrained.Point
            //  IL_0306:  callvirt instance bool[System.Runtime] System.Object::Equals(object)
            //  IL_030b:  pop
            //  IL_030c:  ldstr      "Call .MemberwiseClone()"
            //  IL_0311:  call void [System.Console] System.Console::WriteLine(string)
            //  IL_0316:  ldloca.s V_17
            //  IL_0318:  call instance object Point::Clone()
            //  IL_031d:  pop
            //  IL_031e:  ret
        }

        Console.WriteLine("HUGE EXAMPLE!\n");
        {
            Point2 point_1 = new Point2(10, 10);            // Create two Point instances on the stack.
            Point2 point_2 = new Point2(20, 20);

            // point_1 does NOT get boxed to call ToString (a virtual method).
            Console.WriteLine(point_1.ToString());          // "(10, 10)"

            //***
            // point_1 DOES get boxed to call GetType (a non-virtual method).
            Console.WriteLine(point_1.GetType());           // "Point2"

            // point_1 does NOT get boxed to call CompareTo.
            // point_2 does NOT get boxed because CompareTo(Point2) is called.
            Console.WriteLine(point_1.CompareTo(point_2));  // "-1"

            //***
            IComparable c = point_1;      // point_1 DOES get boxed, and the reference is placed in c.                  
            Console.WriteLine(c.GetType());                 // "Point2"

            // point_1 does NOT get boxed to call CompareTo.
            // Since CompareTo is not being passed a Point2 variable,
            // CompareTo(Object) is called which requires a reference to
            // a boxed Point2.
            // c does NOT get boxed because it already refers to a boxed Point2.
            Console.WriteLine(point_1.CompareTo(c));      // "0"

            //***
            // c does NOT get boxed because it already refers to a boxed Point2.
            // point_2 does get boxed because CompareTo(Object) is called.
            Console.WriteLine(c.CompareTo(point_2));       // "-1" 

            // c is unboxed, and fields are copied into point_2.
            point_2 = (Point2)c;

            // Proves that the fields got copied into point_2.
            Console.WriteLine(point_2.ToString());          // "(10, 10)" 

            //  IL_027c: ldstr      "HUGE EXAMPLE!\n"
            //  IL_0281: call       void [System.Console]System.Console::WriteLine(string)
            //  IL_0286: ldloca.s V_16
            //  IL_0288: ldc.i4.s   10
            //  IL_028a: ldc.i4.s   10
            //  IL_028c: call instance void Point2::.ctor(int32,
            //                                            int32)
            //  IL_0291: ldloca.s V_17
            //  IL_0293: ldc.i4.s   20
            //  IL_0295: ldc.i4.s   20
            //  IL_0297: call instance void Point2::.ctor(int32,
            //                                            int32)
            //  IL_029c: ldloca.s V_16
            //  IL_029e: constrained.Point2
            //  IL_02a4: callvirt instance string[System.Runtime] System.Object::ToString()
            //  IL_02a9: call       void [System.Console]System.Console::WriteLine(string)

            //  IL_02ae: ldloc.s V_16
            //  IL_02b0: box Point2
            //  IL_02b5: call instance class [System.Runtime] System.Type[System.Runtime] System.Object::GetType()
            //  IL_02ba: call void [System.Console] System.Console::WriteLine(object)
            //  IL_02bf: ldloca.s V_16

            //  IL_02c1: ldloc.s V_17
            //  IL_02c3: call instance int32 Point2::CompareTo(valuetype Point2)
            //  IL_02c8: call void [System.Console] System.Console::WriteLine(int32)

            //  IL_02cd: ldloc.s V_16
            //  IL_02cf: box Point2
            //  IL_02d4: stloc.s V_18
            //  IL_02d6: ldloc.s V_18
            //  IL_02d8: callvirt instance class [System.Runtime] System.Type[System.Runtime] System.Object::GetType()
            //  IL_02dd: call void [System.Console] System.Console::WriteLine(object)
            //  IL_02e2: ldloca.s V_16

            //  IL_02e4: ldloc.s V_18
            //  IL_02e6: call instance int32 Point2::CompareTo(object)
            //  IL_02eb: call void [System.Console] System.Console::WriteLine(int32)
            //  IL_02f0: ldloc.s V_18

            //  IL_02f2: ldloc.s V_17
            //  IL_02f4: box Point2
            //  IL_02f9: callvirt instance int32[System.Runtime] System.IComparable::CompareTo(object)
            //  IL_02fe: call void [System.Console] System.Console::WriteLine(int32)

            //  IL_0303: ldloc.s V_18
            //  IL_0305: unbox.any Point2

            //  IL_030a: stloc.s V_17
            //  IL_030c: ldloca.s V_17
            //  IL_030e: constrained.Point2
            //  IL_0314: callvirt instance string[System.Runtime] System.Object::ToString()
            //  IL_0319: call void [System.Console] System.Console::WriteLine(string)
            //  IL_031e: ret
        }
        {
            Test test = new Test(55);
            var notActuallyBoxing = (object)test;
            Console.WriteLine("Not boxed!");
        }
    }
}