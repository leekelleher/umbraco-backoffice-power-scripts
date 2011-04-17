using System;
using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts
{
	[ConfigurationCollection(typeof(ScriptsElement), CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class ScriptsCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new ScriptsElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as ScriptsElement).Path;
		}

		public void Add(ScriptsElement element)
		{
			this.BaseAdd(element);
		}

		public void Clear()
		{
			this.BaseClear();
		}

		public int IndexOf(ScriptsElement element)
		{
			return this.BaseIndexOf(element);
		}

		public void Remove(ScriptsElement element)
		{
			if (this.BaseIndexOf(element) >= 0)
			{
				this.BaseRemove(element.Path);
			}
		}

		public void RemoveAt(int index)
		{
			this.BaseRemoveAt(index);
		}

		public ScriptsElement this[int index]
		{
			get
			{
				return (ScriptsElement)this.BaseGet(index);
			}
			set
			{
				if (this.BaseGet(index) != null)
				{
					this.BaseRemoveAt(index);
				}
				this.BaseAdd(index, value);
			}
		}
	}
}