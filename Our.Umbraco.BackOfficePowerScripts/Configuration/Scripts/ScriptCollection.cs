using System.Configuration;

namespace Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts
{
	/// <summary>
	/// Collection of <see cref="ScriptElement"/> items.
	/// </summary>
	[ConfigurationCollection(typeof(ScriptElement), CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class ScriptCollection : ConfigurationElementCollection
	{
		/// <summary>
		/// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </summary>
		/// <returns>
		/// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new ScriptElement();
		}

		/// <summary>
		/// Gets the element key for a specified configuration element when overridden in a derived class.
		/// </summary>
		/// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for.</param>
		/// <returns>
		/// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as ScriptElement).Path;
		}

		/// <summary>
		/// Adds the specified element.
		/// </summary>
		/// <param name="element">The element.</param>
		public void Add(ScriptElement element)
		{
			this.BaseAdd(element);
		}

		/// <summary>
		/// Clears this instance.
		/// </summary>
		public void Clear()
		{
			this.BaseClear();
		}

		/// <summary>
		/// Gets an item from the collection with a given index.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public int IndexOf(ScriptElement element)
		{
			return this.BaseIndexOf(element);
		}

		/// <summary>
		/// Removes the specified element.
		/// </summary>
		/// <param name="element">The element.</param>
		public void Remove(ScriptElement element)
		{
			if (this.BaseIndexOf(element) >= 0)
			{
				this.BaseRemove(element.Path);
			}
		}

		/// <summary>
		/// Removes at.
		/// </summary>
		/// <param name="index">The index.</param>
		public void RemoveAt(int index)
		{
			this.BaseRemoveAt(index);
		}

		/// <summary>
		/// Gets or sets the <see cref="Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts.ScriptElement"/> at the specified index.
		/// </summary>
		/// <value></value>
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