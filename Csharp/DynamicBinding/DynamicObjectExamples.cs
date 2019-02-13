using System;

namespace DynamicBinding
{
	public class DynamicObjectExamples
	{
		public void Demo()
		{
			Console.WriteLine("### DynamicObjectExamples ###");

			dynamic person = new MyDynamicObject();
			person.Name = "John";
			person.Surname = "Doe";
			person.Age = 42;

			Console.WriteLine($"{person.Name} {person.Surname}, {person.Age}");

			person.AsString = (Func<string>)(() => $"{person.Name} {person.Surname}, {person.Age}");
			Console.WriteLine(person.AsString());

		}
	}
}
