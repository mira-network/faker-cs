using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
	[TestFixture]
	public class LoremFixture
	{
		[Test]
		public void Should_Generate_Paragraph()
		{
			string para = Lorem.Paragraph();
			Assert.IsTrue(Regex.IsMatch(para, @"([A-Z][a-z ]+\.\s?){3,6}"));
		}

		[Test]
		public void Should_Generate_Random_Word_Sentence()
		{
			string sentence = Lorem.Sentence();
			Assert.IsTrue(Regex.IsMatch(sentence, @"[A-Z][a-z ]+\."));
		}

		[Test]
		public void Should_Return_Word_List()
		{
			IEnumerable<string> words = Lorem.Words(10);
			Assert.AreEqual(10, words.Count());
		}
	}
}