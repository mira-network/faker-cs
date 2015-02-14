using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
	[TestFixture]
	public class InternetFixture
	{
		[Test]
		public void Should_Create_Email_Address()
		{
			string email = Internet.Email();
			Assert.IsTrue(Regex.IsMatch(email, @".+@.+\.\w+"));
		}

		[Test]
		public void Should_Create_User_Name()
		{
			string username = Internet.UserName();
			Assert.IsTrue(Regex.IsMatch(username, @"[a-z]+((_|\.)[a-z]+)?"));
		}

		[Test]
		public void Should_Get_Domain_Name()
		{
			string domain = Internet.DomainName();
			Assert.IsTrue(Regex.IsMatch(domain, @"\w+\.\w+"));
		}

		[Test]
		public void Should_Get_Domain_Suffix()
		{
			string suffix = Internet.DomainSuffix();
			Assert.IsTrue(Regex.IsMatch(suffix, @"^\w+(\.\w+)?"));
		}

		[Test]
		public void Should_Get_Domain_Word()
		{
			string word = Internet.DomainWord();
			Assert.IsTrue(Regex.IsMatch(word, @"^\w+$"));
		}
	}
}