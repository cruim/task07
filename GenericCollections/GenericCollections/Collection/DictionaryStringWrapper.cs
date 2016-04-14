using System;
using System.Collections.Generic;
using System.Diagnostics;
using GenericCollections.Model;
using NLog;

namespace GenericCollections.Collection
{
	class DictionaryStringWrapper : ICollectionWrapper
	{
		Logger logger = LogManager.GetCurrentClassLogger();
		Dictionary<string, int> internalDictionary = new Dictionary<string, int>(); 
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.Dictionary;
			}
		}

		public string SystemTypeName
		{
			get { return internalDictionary.GetType().FullName; }
		}

		public void AddElements()
		{
			int collectionLength = Int32.Parse(Console.ReadLine());
			for (int key = 0; key < collectionLength; key++)
				internalDictionary.Add( RandomClass.CreateRandomString(), key);

		}

		public void ShowElements()
		{
			foreach (var s in internalDictionary)
				Console.WriteLine("{0}\t", s);
		}

		public void DeleteOneElement(string delElement)
		{
			internalDictionary.Remove(delElement);
		}

		public void ShowNumberOfElements()
		{
			Console.WriteLine("Текущее количество элементов: {0}", internalDictionary.Count);
		}

		public void StartDictionary()
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
				Console.WriteLine("Количество элементов в коллекции: {0}", internalDictionary.Count);
				Console.Write("Введите ключ элемента, который хотите удалить: ");
				string delElement = Console.ReadLine();
				stopWatch.Reset();
				stopWatch.Start();
				DeleteOneElement(delElement);
				stopWatch.Stop();
				Console.WriteLine("Время удаления элемента: {0}", stopWatch.ElapsedTicks + " ms");
				logger.Info("Время удаления элемента: {0}", stopWatch.ElapsedMilliseconds + " ms");
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
