using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Styles
{
	[ConfigurationCollection(typeof(StyleElement), CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class StyleCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new StyleElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as StyleElement).Path;
		}

		public void Add(StyleElement element)
		{
			this.BaseAdd(element);
		}

		public void Clear()
		{
			this.BaseClear();
		}

		public int IndexOf(StyleElement element)
		{
			return this.BaseIndexOf(element);
		}

		public void Remove(StyleElement element)
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

		public StyleElement this[int index]
		{
			get
			{
				return (StyleElement)this.BaseGet(index);
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