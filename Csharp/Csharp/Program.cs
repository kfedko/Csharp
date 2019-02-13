using DynamicBinding;
using System;

namespace Csharp
{
	class Program
	{
		static void Main(string[] args)
		{
			var ex = new DynamicBindingExamples();
			ex.DynamicTypeSafety();

			var expando = new ExpandoObjectExamples();
			expando.Demo();

			var doe = new DynamicObjectExamples();
			doe.Demo();

		}
	}
}
