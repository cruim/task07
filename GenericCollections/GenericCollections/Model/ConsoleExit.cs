using System;
using System.Text;

namespace GenericCollections.Model
{
	/// <summary>
	/// Console extensions.
	/// </summary>
	public static class ConsoleEx
	{
		/// <summary>
		/// Reads the next line of characters from the standard input stream.
		/// </summary>
		/// <returns>
		/// A line of characters read from the input stream, or <c>null</c> if ESC was pressed.
		/// </returns>
		public static string TryReadLine()
		{
			StringBuilder builder = new StringBuilder();

			for (; ; )
			{
				ConsoleKeyInfo info = Console.ReadKey(true);

				switch (info.Key)
				{
					case ConsoleKey.Enter:
						Console.WriteLine();
						return builder.ToString();

					case ConsoleKey.Escape:
						return null;

					default:
						Console.Write(info.KeyChar);
						builder.Append(info.KeyChar);
						break;
				}
			}
		}
	}
}
