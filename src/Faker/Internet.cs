using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Faker.Extensions;

namespace Faker
{
	public static class Internet
	{
		private static readonly IEnumerable<Func<string>> _userNameFormats = new List<Func<string>>
		{
			() => Name.First().AlphanumericOnly().ToLowerInvariant(),
			() => string.Format("{0}{1}{2}", Name.First().AlphanumericOnly(),
				new[] { ".", "_", "+" }.Random(), Name.Last().AlphanumericOnly()).ToLowerInvariant(),
		};

		private static readonly IEnumerable<Func<string>> _domainNameFormats = new List<Func<string>>
		{
			() => String.Format("{0}.{1}", DomainWord(), DomainSuffix()),
			() => String.Format("{0}.{1}.{2}", DomainWord(), DomainWord(), DomainSuffix()),
			() => String.Format("{0}.{1}.{2}.{3}", DomainWord(), DomainWord(), DomainWord(), DomainSuffix()),
		};

		public static string Email()
		{
			return String.Format("{0}@{1}", UserName(), DomainName());
		}

		public static string UserName()
		{
			return _userNameFormats.Random();
		}

		public static string DomainName()
		{
			return _domainNameFormats.Random();
		}

		public static string DomainWord()
		{
			return Company.Name().Split(' ').First().AlphanumericOnly().ToLowerInvariant();
		}

		public static string DomainSuffix()
		{
			return Resources.Internet.DomainSuffix.Split(Config.Separator).Random();
		}

		public static string IPV4Address()
		{
			var random = new Random();
			const int min = 2;
			const int max = 255;
			string[] parts =
			{
				random.Next(min, max).ToString(CultureInfo.InvariantCulture),
				random.Next(min, max).ToString(CultureInfo.InvariantCulture),
				random.Next(min, max).ToString(CultureInfo.InvariantCulture),
				random.Next(min, max).ToString(CultureInfo.InvariantCulture)
			};
			return String.Join(".", parts);
		}

		public static string IPV6Address()
		{
			var random = new Random();
			const int min = 0;
			const int max = 65536;
			string[] parts =
			{
				random.Next(min, max).ToString("x"),
				random.Next(min, max).ToString("x"),
				random.Next(min, max).ToString("x"),
				random.Next(min, max).ToString("x"),
				random.Next(min, max).ToString("x"),
				random.Next(min, max).ToString("x"),
				random.Next(min, max).ToString("x"),
				random.Next(min, max).ToString("x")
			};
			return String.Join(":", parts);
		}

		public static string Url()
		{
			return String.Format("http://{0}/{1}", DomainName(), UserName());
		}
	}
}