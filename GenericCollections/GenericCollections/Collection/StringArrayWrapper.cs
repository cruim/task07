using System;
using GenericCollections.Model;
using System.Diagnostics;
using NLog;

namespace GenericCollections.Collection
{
	class StringArrayWrapper //: ICollectionWrapper
	{
		Logger logger = LogManager.GetCurrentClassLogger();
		string[] internalArray = new string[2000000];

		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.StringArray;
			}
		}

		public string SystemTypeName
		{
			get { return internalArray.GetType().FullName; }
		}

		public void AddElements()
		{
			for (int i = 0; i < internalArray.Length; i++)
			internalArray[i] = (RandomClass.CreateRandomString());

		}

		public void ShowElements()
		{
			foreach (var s in internalArray)
				Console.Write("{0}\t", s);
		}

		public void DeleteOneElement(int delElement)
		{
			Array.Reverse(internalArray, delElement, 0);
			Array.Reverse(internalArray);
			Array.Resize(ref internalArray, internalArray.Length - 1);
		}

		public void ShowNumberOfElements()
		{
			Console.WriteLine("Текущее количество элементов: {0}", internalArray.Length);
		}

		public void StartStringArray()
		{
			try
			{
				Console.WriteLine("Вы выбрали: {0}\n", CollectionType);
				Console.WriteLine("Подробная информация: {0}\n", SystemTypeName);
				Stopwatch stopWatch = new Stopwatch();
				stopWatch.Start();
				AddElements();
				ShowElements();
				stopWatch.Stop();
				Console.WriteLine("Время заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				logger.Info("Время заполнения коллекции: {0}", stopWatch.ElapsedMilliseconds + " ms");
				ShowNumberOfElements();
				Console.Write("Введите индекс элемент, который нужно удалить: ");
				int delElement = Int32.Parse(Console.ReadLine());
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
