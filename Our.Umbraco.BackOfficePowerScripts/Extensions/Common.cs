﻿using System;

using Our.Umbraco.BackOfficePowerScripts.Configuration;

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
	}
}
