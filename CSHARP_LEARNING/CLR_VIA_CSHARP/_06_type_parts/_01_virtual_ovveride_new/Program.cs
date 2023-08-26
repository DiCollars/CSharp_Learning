Entity light = new Entity();
light.Display();

Human mett = new Human();
mett.Display();

Dog rex = new Dog();
rex.Display();

Entity cizer = new Dog();
cizer.Display();

Entity dave = new Human();
dave.Display();

class Entity
{
    public virtual void Display()
    {
        Console.WriteLine("Entity");
    }
}

class Human : Entity
{
    public override void Display()
    {
        Console.WriteLine("Human");
    }
}

class Dog : Entity
{
    public new void Display()
    {
        Console.WriteLine("Dog");
    }
}