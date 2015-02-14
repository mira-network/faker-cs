using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;
using NUnit.Framework;

namespace Faker.Tests.Extensions
{
	[TestFixture]
	public class ArrayExtensionsFixture
	{
		[Test]
		public void Should_Return_All_Array_Items()
		{
			var input = new[] { "a", "b", "c" };
			IEnumerable<string> result = 100.Times(x => input.Random());

			Assert.AreEqual(3, result.Distinct().Count());
		}

		[Test]
		public void Should_Return_Single_Item_From_Array()
		{
			string s = new[] { "Foo" }.Random();
			Assert.AreEqual("Foo", s);
		}
	}
}