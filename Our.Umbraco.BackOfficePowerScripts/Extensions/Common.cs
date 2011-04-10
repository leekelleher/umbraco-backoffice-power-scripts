using System;
using System.IO;

using umbraco.IO;

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

		public static string ResourceName
		{
			get
			{
				return "Our.Umbraco.BackOfficePowerScripts.Resources.Config.BackOfficePowerScripts.config";
			}
		}

		public static string GetScriptPath(string filename)
		{
			var path = string.Concat(umbraco.IO.SystemDirectories.Umbraco, "/plugins/backofficeScripts/");
			var dir = IOHelper.MapPath(path);

			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			return IOHelper.MapPath(string.Concat(path, filename));
		}

		public static void CopyResourceToFile(Type type, string resourceName, string path)
		{
			using (var resource = type.Assembly.GetManifestResourceStream(resourceName))
			using (var file = File.Create(path))
			{
				resource.CopyTo(file);
			}
		}
	}
}
