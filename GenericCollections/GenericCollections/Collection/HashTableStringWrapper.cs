using System;
using System.Collections;
using System.Diagnostics;
using GenericCollections.Model;
using NLog;

namespace GenericCollections.Collection
{
	class HashTableStringWrapper : ICollectionWrapper
	{
		Logger logger = LogManager.GetCurrentClassLogger();
		Hashtable internalHashtable = new Hashtable();
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.HashtableString;
			}
		}

		public string SystemTypeName
		{
			get { return internalHashtable.GetType().FullName; }
		}

		public void AddElements()
		{
			int collectionLength = Int32.Parse(Console.ReadLine());
			for (int key = 0; key < collectionLength; key++)
				internalHashtable.Add(key, RandomClass.CreateRandomString());

		}

		public void ShowElements()
		{
			foreach (DictionaryEntry s in internalHashtable)
				Console.WriteLine("{0}:\t{1}", s.Value, s.Key);
		}

		public void DeleteOneElement(string delElement)
		{
			internalHashtable.Remove(delElement);
		}

		public void ShowNumberOfElements()
		{
			Console.WriteLine("Текущее количество элементов: {0}", internalHashtable.Count);
		}

		public void StartHashTableString()
		{
			try
			{
				Console.WriteLine("Вы выбрали: {0}\n", CollectionType);
				Console.WriteLine("Подробная информация: {0}\n", SystemTypeName);
				Stopwatch stopWatch = new Stopwatch();
				Console.Write("Введите количество элементов коллекции: ");
				stopWatch.Start();
				AddElements();
				ShowElements();
				Console.WriteLine("Key           Value");
				stopWatch.Stop();
				Console.WriteLine("\nВремя заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				logger.Info("Время заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				Console.WriteLine("Количество элементов в коллекции: {0}", internalHashtable.Count);
				Console.Write("Введите ключ элемента, который хотите удалить: ");
				string delElement = Console.ReadLine();
				stopWatch.Reset();
				stopWatch.Start();
				DeleteOneElement(delElement);
				stopWatch.Stop();
				Console.WriteLine("Время удаления элемента: {0}", stopWatch.ElapsedTicks + " ms");
				ShowNumberOfElements();
			}
			catch (FormatException)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Попытка некорректного ввода данных! Попробуйте еще раз!");
				Console.ForegroundColor = ConsoleColor.Gray;

			}
		}
	}
}
