using System;
using System.Collections;
using  System.Diagnostics;
using GenericCollections.Model;
using NLog;

namespace GenericCollections.Collection
{
	class ArrayListWrapper : ICollectionWrapper
	{
		Logger logger = LogManager.GetCurrentClassLogger();
		ArrayList internalArrayList = new ArrayList();

		public CollectionType CollectionType
		{
			get { return CollectionType.ArrayList; }
		}

		public string SystemTypeName
		{
			get { return internalArrayList.GetType().FullName; }
		}

		public void AddElements()
		{
			internalArrayList.Add(RandomClass.CreateRandomString());
			
		}

		public void ShowElements()
		{
			foreach (var s in internalArrayList)
				Console.Write("{0}\t", s);
		}

		public void DeleteOneElement(string delElement)
		{
			internalArrayList.Remove(delElement);
		}

		public void ShowNumberOfElements()
		{
			Console.WriteLine("Текущее количество элементов: {0}",internalArrayList.Count);
		}

		public void StartArrayList()
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
