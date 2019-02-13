using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DynamicBinding
{
	public class ExpandoObjectExamples
	{
		public void Demo() {
			Console.WriteLine("### ExpandoObject ###");

			dynamic person = new ExpandoObject();
			person.Name = "John";
			person.Surname = "Doe";
			person.Age = 42;

			Console.WriteLine($"{person.Name} {person.Surname}, {person.Age}");

			Console.WriteLine("#########");
			var dictionary = (IDictionary<string, object>)person;

			foreach (var member in dictionary)
			{
				Console.WriteLine($"{member.Key} = {member.Value}");
			}
		}
	}
}
