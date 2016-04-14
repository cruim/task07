using System;
using System.Collections.Specialized;
using System.Diagnostics;
using GenericCollections.Model;
using NLog;

namespace GenericCollections.Collection
{
	class cruim_TestCollection : ICollectionWrapper
	{
		// Представляет коллекцию связанных ключей String и значений String, доступ к которым можно получить с помощью ключа или индекса.

		NameValueCollection nameValueCollection = new NameValueCollection();

		Logger logger = LogManager.GetCurrentClassLogger();

		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.NameValueCollection;
			}
		}

		public string SystemTypeName
		{
			get { return nameValueCollection.GetType().FullName; }
		}

		public void AddElements()
		{
			
			nameValueCollection.Add(RandomClass.CreateRandomString(),RandomClass.CreateRandomString());
		}

		public void ShowElements()
		{
			
			foreach (String s in nameValueCollection.AllKeys)
				Console.WriteLine("   {0,-10} {1}", s, nameValueCollection[s]);
			Console.WriteLine("   KEY        VALUE");
			Console.WriteLine();
		}

		public void DeleteOneElement(string delElement)
		{
			nameValueCollection.Remove(delElement);
		}

		public void ShowNumberOfElements()
		{
			Console.WriteLine("Текущее количество элементов: {0}", nameValueCollection.Count);
		}

		public void StartValueCollection()
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
				Console.Write("Введите ключ элемента, который хотите удалить: ");
				string delElement = Console.ReadLine();
				stopWatch.Reset();
				stopWatch.Start();
				DeleteOneElement(delElement);
				stopWatch.Stop();
				Console.WriteLine("Время удаления элемента: {0}", stopWatch.ElapsedMilliseconds + " ms");
				logger.Info("Время удаления элемента: {0}", stopWatch.ElapsedMilliseconds + " ms");
				ShowNumberOfElements();
				ShowElements();
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