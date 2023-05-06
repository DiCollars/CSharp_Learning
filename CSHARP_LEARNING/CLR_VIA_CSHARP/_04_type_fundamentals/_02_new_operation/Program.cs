var child = new Child();
child.Display();

var fd = new Parent();
fd.Display();

Console.ReadKey();

//1.    Count required bytes to store all element fields (in general object state) and parent fields (only object in this case)
//      By the way, any object on the heap must include a type-object-pointer and
//      the sync-block-index - the weight of these objects
//      will be taken into account as a result of the calculation.

//2.    Memory allocation for already counted object and initialization these by zeros.

//3.    Type-object-pointer and sync-block-index initialization.

//4.    Call instance constructor with given arguments (and call parents .ctors too - and parents first!)

class Parent : A
{
    public Parent()
    {
        Console.WriteLine("I'm a daddy!");
    }
}

class Child : A
{
    public Child()
    {
        Console.WriteLine("I'm a child!");
    }
}

abstract class A
{
    public void Display()
    {
        Console.WriteLine(this.GetType().Name);
    }
}