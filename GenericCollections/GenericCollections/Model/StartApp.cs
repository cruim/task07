using System;
using GenericCollections.Collection;

namespace GenericCollections.Model
{
	class StartApp
	{
		public void OnStartApp()
		{
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Выберете коллекцию для тестирования, нажав соответствующую цифру\n\n" +
				                  "(1)string[]*(2)List<string>*(3)ArrayList*(4)SortedList*\n" +
				                  "(5)HashSet*(6)HashTable*(7)Dictionary<string,object>*(8)cruim_TestCollection\n\n");
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine("Результаты всех операций логируются. Сравнить быстродейтствие\n" +
				                  "коллекций можно в папке logs\n" +
				                  "Для выхода из программы нажмите Esq");
				string choise = ConsoleEx.TryReadLine();

				switch (choise)
				{
					case "1":
						StringArrayWrapper stringArray = new StringArrayWrapper();
						stringArray.StartStringArray();
						break;
					case "2":
						ListWrapper list = new ListWrapper();
						list.StartList();
						break;
					case "3":
						ArrayListWrapper arrayList = new ArrayListWrapper();
						arrayList.StartArrayList();
						break;
					case "4":
						SortedListWrapper sortedList = new SortedListWrapper();
						sortedList.StartSortedList();
						break;
					case "5":
						HashSetWrapper hashSet = new HashSetWrapper();
						hashSet.StartHashSet();
						break;
					case "6":
						HashTableStringWrapper hashTableString = new HashTableStringWrapper();
						hashTableString.StartHashTableString();
						break;
					case "7":
						DictionaryStringWrapper dictionaryString = new DictionaryStringWrapper();
						dictionaryString.StartDictionary();
						break;
					case "8":
						cruim_TestCollection cruim = new cruim_TestCollection();
						cruim.StartValueCollection();
						break;
					case null:
						Environment.Exit(0);
						break;
					default:
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Вводите только предложеные цифры!");
						Console.ForegroundColor = ConsoleColor.Gray;
						break;
					}
				}
			}
		}
	}
}

