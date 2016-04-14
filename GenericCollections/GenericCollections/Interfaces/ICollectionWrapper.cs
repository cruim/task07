using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCollections.Model;

namespace GenericCollections
{
	public interface ICollectionWrapper
	{
		CollectionType CollectionType { get; }
		string SystemTypeName { get; }

		void AddElements();
		void DeleteOneElement(string delElement);
	}
}
