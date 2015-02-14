using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Times<T>(this int count, Func<int, T> func)
		{
			for (int i = 0; i < count; i++)
			{
				yield return func.Invoke(i);
			}
		}

		/// <summary>
		///     Select a random element from the Enumerable list.
		/// </summary>
		public static T Random<T>(this IEnumerable<T> list)
		{
			IList<T> enumerable = list as IList<T> ?? list.ToList();
			if (!enumerable.Any())
			{
				throw new InvalidOperationException("Enumerable list must contain at least one item");
			}

			return enumerable.ElementAt(RandomNumber.Next(0, enumerable.Count()));
		}

		/// <summary>
		///     Select a random element from the Enumerable list.
		/// </summary>
		public static T Random<T>(this IEnumerable<Func<T>> list)
		{
			IList<Func<T>> enumerable = list as IList<Func<T>> ?? list.ToList();
			if (!enumerable.Any())
			{
				throw new InvalidOperationException("Enumerable list must contain at least one item");
			}

			return enumerable.ElementAt(RandomNumber.Next(0, enumerable.Count())).Invoke();
		}

		/// <summary>
		///     Select a random string array from the Enumerable list.
		/// </summary>
		public static T[] Random<T>(this IEnumerable<Func<T[]>> list)
		{
			IList<Func<T[]>> enumerable = list as IList<Func<T[]>> ?? list.ToList();
			if (!enumerable.Any())
			{
				throw new InvalidOperationException("Enumerable list must contain at least one item");
			}

			return enumerable.ElementAt(RandomNumber.Next(0, enumerable.Count())).Invoke();
		}
	}
}