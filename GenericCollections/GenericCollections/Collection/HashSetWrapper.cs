using System;
using System.Collections.Generic;
using System.Diagnostics;
using GenericCollections.Model;
using NLog;

namespace GenericCollections.Collection
{
	class HashSetWrapper : ICollectionWrapper
	{
		Logger logger = LogManager.GetCurrentClassLogger();
		HashSet<string> internalHashSet = new HashSet<string>(StringComparer.Ordinal); 
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.HashSet;
			}
		}

		public string SystemTypeName
		{
			get { return internalHashSet.GetType().FullName; }
		}

		public void AddElements()
		{
			internalHashSet.Add(RandomClass.CreateRandomString());

		}

		public void ShowElements()
		{
			foreach (var s in internalHashSet)
				Console.Write("{0}\t", s);
		}

		public void DeleteOneElement(string delElement)
		{
			internalHashSet.Remove(delElement);
		}

		public void ShowNumberOfElements()
		{
			Console.WriteLine("Текущее количество элементов: {0}", internalHashSet.Count);
		}

		public void StartHashSet()
		{
			try
			{
				Console.WriteLine("Вы выбрали: {0}\n", CollectionType);
				Console.WriteLine("Подробная информация: {0}\n", SystemTypeName);
				Stopwatch stopWatch = new Stopwatch();
				Console.Write("Введит количество элементов коллекции: ");
				int collectionLength = Int32.Parse(Console.ReadLine());
				stopWatch.Start();
				for (int i = 0; i < collectionLength; i++)
					AddElements();
				ShowElements();
				stopWatch.Stop();
				Console.WriteLine("Время заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				logger.Info("Время заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				Console.WriteLine("Количество элементов в коллекции: {0}", collectionLength);
				Console.Write("Введите имя элемента, который хотите удалить: ");
				string delElement = Console.ReadLine();
				stopWatch.Reset();
				stopWatch.Start();
				DeleteOneElement(delElement);
				stopWatch.Stop();
				Console.WriteLine("Время удаления элемента: {0}", stopWatch.ElapsedMilliseconds + " ms");
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
