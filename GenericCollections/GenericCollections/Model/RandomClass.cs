using System;
using System.Text;

namespace GenericCollections.Model
{
	 class RandomClass
	{
		private static Random r = new Random();

		static string chars = "01234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

		public static string CreateRandomString()
		{
			var sb = new StringBuilder();
			for (int i = 0; i < 10; i++)
			{
				var randomIndex = r.Next(chars.Length);
				sb.Append(chars[randomIndex]);
			}
			return sb.ToString();
		}
	}
}
