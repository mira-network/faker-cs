using System;

namespace Faker.Extensions
{
	public static class ArrayExtensions
	{
		/// <summary>
		///     Select a random element from the array.
		/// </summary>
		public static T Random<T>(this T[] list)
		{
			if (list.Length == 0)
			{
				throw new InvalidOperationException("Enumerable list must contain at least one item");
			}
			return list[RandomNumber.Next(0, list.Length)];
		}
	}
}