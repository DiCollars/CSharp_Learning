var person = new Person(new DateTime(1888, 1, 1).ToString());
person.Age = 30;
person.State = "1.0";

Person.Name = "God";

var method = (ref string a) => 
{
    a = "lol";
};

//! cant use property with ref/out !
//method(ref person.State);

public class Person : Creature
{
    public Person(string birthDate)
    {
        BirthDate = birthDate;
    }

    private int age;
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException($"{nameof(Age)} - can't be less than 0!");
            age = value;
        }
    }

    static private string name;
    static public string Name
    {
        get 
        { 
            return name; 
        }
        set 
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException($"{Name} - can't be null or whitespace!");
            name = value; 
        }
    }

    public override string BirthDate { get; }

    public override string? State { get => base.State; set => base.State = value; }
}

public abstract class Creature
{
    abstract public string BirthDate { get; }

    private string? state;
    public virtual string? State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }
}