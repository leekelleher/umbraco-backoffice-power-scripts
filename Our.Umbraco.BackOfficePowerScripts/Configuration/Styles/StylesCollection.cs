using System;
using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Styles
{
	[ConfigurationCollection(typeof(StylesElement), CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class StylesCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new StylesElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as StylesElement).Path;
		}

		public void Add(StylesElement element)
		{
			this.BaseAdd(element);
		}

		public void Clear()
		{
			this.BaseClear();
		}

		public int IndexOf(StylesElement element)
		{
			return this.BaseIndexOf(element);
		}

		public void Remove(StylesElement element)
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

		public StylesElement this[int index]
		{
			get
			{
				return (StylesElement)this.BaseGet(index);
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