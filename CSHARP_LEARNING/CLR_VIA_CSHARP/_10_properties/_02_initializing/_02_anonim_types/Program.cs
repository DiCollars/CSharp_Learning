var myType = new { Name = "Danny", Age = 25 };
Console.WriteLine(myType.Name + " " + myType.Age);

string name = "Danny";
DateTime date = DateTime.Now;

var myNewType = new { name, date.Hour };
Console.WriteLine(myNewType.name + " " + myNewType.Hour);

var anonimusArray = new[]
{
    new { Name = "Harry" },
    new { Name = "Bobby" },
    new { Name = "Andry" },
    new { Name = "Mari" },
    new { Name = "Pencilson" },
    new { Name = "Rogers" },
    new { Name = "Arman" }
};

foreach (var anonim in anonimusArray)
{
    Console.WriteLine(anonim.Name);
}
