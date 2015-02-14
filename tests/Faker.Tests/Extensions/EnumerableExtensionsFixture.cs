using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;
using NUnit.Framework;

namespace Faker.Tests.Extensions
{
	[TestFixture]
	public class EnumerableExtensionsFixture
	{
		[Test]
		public void Should_Invoke_Func_Given_Number_Of_Times()
		{
			IEnumerable<int> numbers = 10.Times(x => x);
			Assert.AreEqual(10, numbers.Count());
		}
	}
}