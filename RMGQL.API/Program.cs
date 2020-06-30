// Program.cs

using GraphQL;
using GraphQL.Types;
using SWGQL.API;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var schema = Schema.For(@"
                type Jedi {
                    name: String,
                    side: String
                    id: ID
                }

                type Query {
                    hello: String,
                    jedis: [Jedi]
                    jedi(id: ID): Jedi
                }
                ", _ =>
            {
                _.Types.Include<Query>();
            });

            var root = new { Hello = "Hello World!" };
            var json = schema.Execute(_ =>
            {
                _.Query = "{ jedi(id: 1) { name } }";
            });

            Console.WriteLine(json);
        }
    }
}
