using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;

namespace Introduction
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var schema = Schema.For(@"
              type Query {
                name: String,
                age: Int,
                isMarked: Boolean
              }
            ");

            var json = await schema.ExecuteAsync(_ =>
            {
                _.Query = "{ name, age, isMarked }";
                _.Root = new
                {
                    Name = "Danny",
                    Age = 21,
                    IsMarked = true
                };
            });

            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}
