using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using Our.Umbraco.BackOfficePowerScripts;
using Our.Umbraco.BackOfficePowerScripts.Extensions;

[assembly: AssemblyTitle("Our.Umbraco.BackOfficePowerScripts")]
[assembly: AssemblyDescription("BackOffice Power Scripts for Umbraco")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Umbrella Inc Ltd")]
[assembly: AssemblyProduct("Our.Umbraco.BackOfficePowerScripts")]
[assembly: AssemblyCopyright("Copyright \xa9 Lee Kelleher, Umbrella Inc Ltd 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
[assembly: Guid("6F60C63D-EC16-4F70-ACB9-9FA1939C5286")]

[assembly: PreApplicationStartMethod(typeof(Application), Common.PreApplicationStartMethodName)]
