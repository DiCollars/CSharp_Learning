using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;

namespace _003_introduction_first_approach
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                await Console.Out.WriteLineAsync("Enter fields:");
                var fields = Console.ReadLine();

                try
                {
                    var schema = new Schema { Query = new PersonQuery() };
                    var json = await schema.ExecuteAsync(_ =>
                    {
                        _.Query = $"{{ goal {{ {fields} }} }}";
                    });

                    Console.WriteLine(json);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string? Department { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public DateTime LastActivity { get; set; }
    }

    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id).Description("The id of the Person.");
            Field(x => x.Code).Description("The working code of the Person.");
            Field(x => x.Department).Description("The department of the Person.");
            Field(x => x.Age).Description("The age of the Person.");
            Field(x => x.Name).Description("The name of the Person.");
            Field(x => x.LastActivity).Description("The last time of persons active period.");
        }
    }

    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery()
        {
            Field<PersonType>("goal")
                .Resolve(context => new Person 
                { 
                    Id = Guid.NewGuid(), 
                    Name = "Danny",
                    LastActivity = DateTime.Now,
                    Age = 21,
                    Code = 36,
                    Department = "Khersonskay 12/14"
                });
        }
    }
}
