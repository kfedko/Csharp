using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBinding
{
	public class DynamicBindingExamples
	{
		public void StaticTypeSafety()
		{
			Console.WriteLine("### StaticTypeSafety ###");

			//string text = "String value";
			//int textLength = text.Length;
			//int textMonth = text.Month; // won't compile

			//DateTime date = DateTime.Now;
			//int dateLength = date.Length; // won't compile
			//int dateMonth = date.Month;

			//############################

			//string text = "String value";
			//int textLength = text.Length;
			//int textMonth = ((DateTime)text).Month; // won't compile

			//DateTime date = DateTime.Now;
			//int dateLength = ((string)date).Length; // won't compile
			//int dateMonth = date.Month;

			//############################

			//string text = "String value";
			//int textLength = text.Length;
			//int textMonth = ((DateTime)(object)text).Month;

			//DateTime date = DateTime.Now;
			//int dateLength = ((string)(object)date).Length;
			//int dateMonth = date.Month;

			//############################

			//var list = new ArrayList();
			//list.Add("String value");
			//int length = ((string)list[0]).Length;
			//int month = ((DateTime)list[0]).Month; // no compiler error
		}

		public void DynamicTypeSafety()
		{
			Console.WriteLine("### DynamicTypeSafety ###");

			//IGeometricShape circle = new Circle { Radius = 1 };
			//Square square = ((Square)circle); // no compiler error
			//var side = square.Side;

			//if (shape is Square)
			//{
			//	Square square = ((Square)shape);
			//	var side = square.Side;
			//}
			//if (shape is Circle)
			//{
			//	Circle circle = ((Circle)shape);
			//	var radius = circle.Radius;
			//}

			//############################

			//dynamic text = "String value";
			//int textLength = text.Length;
			//int textMonth = text.Month; // throws exception at runtime

			//dynamic date = DateTime.Now;
			//int dateLength = date.Length; // throws exception at runtime
			//int dateMonth = date.Month;

			//############################
			
			//dynamic value = GetAnonymousType();
			//Console.WriteLine($"{value.Name} {value.Surname}, {value.Age}");
			
			//############################

			string json = @"
				{
					""name"": ""John"",
					""surname"": ""Doe"",
					""age"": 42
				}";

			dynamic value = JObject.Parse(json);
			Console.WriteLine($"{value.name} {value.surname}, {value.age}");

		}

		public dynamic GetAnonymousType()
		{
			return new
			{
				Name = "John",
				Surname = "Doe",
				Age = 42
			};
		}

		public interface IGeometricShape
		{
			double Circumference { get; }
			double Area { get; }
		}

		public class Square : IGeometricShape
		{
			public double Side { get; set; }

			public double Circumference => 4 * Side;

			public double Area => Side * Side;
		}

		public class Circle : IGeometricShape
		{
			public double Radius { get; set; }

			public double Circumference => 2 * Math.PI * Radius;

			public double Area => Math.PI * Radius * Radius;
		}
	}
}
