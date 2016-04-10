using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GenericCollections.Model;
using NLog;

namespace GenericCollections.Collection
{
	class SortedListWrapper : ICollectionWrapper
	{
		Logger logger = LogManager.GetCurrentClassLogger();
		SortedList<int, string> internalSortedList = new SortedList<int, string>();
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.SortedList;
			}
		}

		public string SystemTypeName
		{
			get { return internalSortedList.GetType().FullName; }
		}

		public void AddElements()
		{
			int collectionLength = Int32.Parse(Console.ReadLine());
			for(int key = 0; key < collectionLength; key++)
			internalSortedList.Add(key, RandomClass.CreateRandomString());

		}

		public void ShowElements()
		{
			foreach (var s in internalSortedList)
				Console.WriteLine("{0}\t", s);
		}

		public void DeleteOneElement(string delElement)
		{
			internalSortedList.RemoveAt(Int32.Parse(delElement));
		}

		public void ShowNumberOfElements()
		{
			Console.WriteLine("Текущее количество элементов: {0}", internalSortedList.Count);
		}
		
		
		public void StartSortedList()
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
				stopWatch.Stop();
				Console.WriteLine("\nВремя заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				logger.Info("Время заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				Console.WriteLine("Количество элементов в коллекции: {0}", internalSortedList.Count);
				Console.Write("Введите индекс элемента, который хотите удалить: ");
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
