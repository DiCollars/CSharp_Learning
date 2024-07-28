using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;

namespace _002_Introduction
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var shema = Schema.For(@"
              type Person {
                id: Guid!
                age: Int!
                name: String!
              }
              
              type Query {
                goal: Person
              }
            ",
            _ =>
            {
                _.Types.Include<Query>();
            });

            var json = await shema.ExecuteAsync(_ =>
            {
                _.Query = "{ goal { id age name } }";
            });

            await Console.Out.WriteLineAsync(json);
        }
    }
    
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Query
    {
        [GraphQLMetadata("goal")]
        public Person GetPerson()
        {
            return new Person
            {
                Id = Guid.NewGuid(),
                Age = 21,
                Name = "Danny"
            };
        }
    }
}
