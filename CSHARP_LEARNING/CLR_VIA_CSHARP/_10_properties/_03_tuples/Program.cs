Tuple<int, string> human = new Tuple<int, string>(25, "Danny");
Console.WriteLine(human.Item1 + " " + human.Item2);

(int age, string name) human2 = (age: 25, name: "Danny");
Console.WriteLine(human2.age + " " + human2.name);
