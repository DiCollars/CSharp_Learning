IsOperatorTesting();

TypicalExamples();

void TypicalExamples()
{
    Object o = new Child();
    if (o is Child)
    {
        //In this moment CLR find out current 'o' type (Child) and after that check all
        //hierarchy in searching compatible type (Parent), cos 'Child'
        //is a child of type 'Parent' - it works.
        Parent parent = (Parent)o;
    }

    Parent? parent1 = o as Parent;

    Console.WriteLine(parent1?.GetType()?.FullName ?? "error");
}

void IsOperatorTesting()
{
    //is never throw Exception!
    object val = 5;
    Console.WriteLine($"{val} is int -> " + (val is int));

    Parent parent = new Parent();
    Console.WriteLine($"{parent} is Parent -> " + (parent is Parent));

    Parent parent1 = new Child();
    Console.WriteLine($"{parent1} is Parent -> " + (parent1 is Parent));

    var el = (object)null;
    Console.WriteLine($"{el ?? "null"} is Object -> " + (el is Object));

    var elNull = (object)null;
    Console.WriteLine($"{el ?? "null"} is null -> " + (el is null));

    var obj1 = new object();
    var obj2 = new object();

    Console.WriteLine($"obj1 == obj2 ? {Object.ReferenceEquals(obj1, obj2)}");
    Console.WriteLine($"obj1 == obj1 ? {Object.ReferenceEquals(obj1, obj1)}");
}

class Parent { }
class Child : Parent { }

class B
{ }
class D : B { }

//class Animal
//{
//    public string Type { get; set; }
//}

//class Cat : Animal
//{
//    public string Name { get; set; }

//    public static explicit operator Cat(Animal animal)
//    {
//        return new Cat { Name = animal.Type };
//    }
//}
