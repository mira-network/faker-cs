using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
	[TestFixture]
	public class CompanyFixture
	{
		[Test]
		public void Should_Generate_Bs()
		{
			string bs = Company.Bs();
			Assert.IsTrue(Regex.IsMatch(bs, @"[\w\-]+ [\w\-]+ [\w\-]+"));
		}

		[Test]
		public void Should_Generate_Catchphrase()
		{
			string catchPhrase = Company.CatchPhrase();
			Assert.IsTrue(Regex.IsMatch(catchPhrase, @"[\w\-]+ [\w\-]+ [\w\-]+"));
		}

		[Test]
		public void Should_Generate_Company_Name()
		{
			string name = Company.Name();

			// Name should match one of the given formats
			Assert.IsTrue(new List<Func<bool>>
			{
				() => Regex.IsMatch(name, @"\w+ \w+"),
				() => Regex.IsMatch(name, @"\w+-\w+"),
				() => Regex.IsMatch(name, @"\w+, \w+ and \w+")
			}.Any(x => x.Invoke()));
		}
	}
}