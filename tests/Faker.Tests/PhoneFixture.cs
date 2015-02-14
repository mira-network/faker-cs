﻿using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
	[TestFixture]
	public class PhoneFixture
	{
		[TestCase("01## ### ####", @"01[0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]")]
		[TestCase("###-###-####", @"[0-9][0-9][0-9]\-[0-9][0-9][0-9]\-[0-9][0-9][0-9][0-9]")]
		[TestCase("### ### ####", @"[0-9][0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]")]
		public void Should_Generate_Phone_Number_Based_On_Pattern(string pattern, string regexMatchPattern)
		{
			string number = Phone.Number(pattern);
			Assert.IsTrue(Regex.IsMatch(number, regexMatchPattern));
		}

		[Test]
		public void Should_Generate_Phone_Number()
		{
			string number = Phone.Number();
			Assert.IsTrue(Regex.IsMatch(number, @"[0-9 x\-\(\)\.]+"));
		}
	}
}