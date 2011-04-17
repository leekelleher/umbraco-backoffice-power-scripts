using System;

using Our.Umbraco.BackOfficePowerScripts.Configuration.Scripts;
using Our.Umbraco.BackOfficePowerScripts.Configuration.Styles;

namespace Our.Umbraco.BackOfficePowerScripts.Extensions
{
	public class Common
	{
		public static string ConfigName
		{
			get
			{
				return "BackOfficePowerScripts";
			}
		}

		public static ScriptCollection RegisteredScripts { get; set; }
		
		public static StyleCollection RegisteredStyles { get; set; }
	}
}
