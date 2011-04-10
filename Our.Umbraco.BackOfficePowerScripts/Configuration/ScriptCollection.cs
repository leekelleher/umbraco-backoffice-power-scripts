using System;
using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration
{
	[ConfigurationCollection(typeof(ScriptElement), CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class ScriptCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new ScriptElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as ScriptElement).Name;
		}

		public void Add(ScriptElement element)
		{
			this.BaseAdd(element);
		}
		
		public void Clear()
		{
			this.BaseClear();
		}

		public int IndexOf(ScriptElement element)
		{
			return this.BaseIndexOf(element);
		}

		public void Remove(ScriptElement element)
		{
			if (this.BaseIndexOf(element) >= 0)
			{
				this.BaseRemove(element.Name);
			}
		}

		public void RemoveAt(int index)
		{
			this.BaseRemoveAt(index);
		}

		public ScriptElement this[int index]
		{
			get
			{
				return (ScriptElement)this.BaseGet(index);
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