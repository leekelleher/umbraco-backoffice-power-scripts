using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using Our.Umbraco.BackOfficePowerScripts;
using Our.Umbraco.BackOfficePowerScripts.Extensions;

// General Information about an assembly is controlled through the following set of attributes.
// Change these attribute values to modify the information associated with an assembly.
[assembly: AssemblyTitle("Our.Umbraco.BackOfficePowerScripts")]
[assembly: AssemblyDescription("BackOffice Power Scripts for Umbraco")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Umbrella Inc Ltd")]
[assembly: AssemblyProduct("Our.Umbraco.BackOfficePowerScripts")]
[assembly: AssemblyCopyright("Copyright \xa9 Lee Kelleher, Umbrella Inc Ltd 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible to COM components.
// If you need to access a type in this assembly from COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("6F60C63D-EC16-4F70-ACB9-9FA1939C5286")]

// Version information for an assembly consists of the following four values:
// Major Version, Minor Version, Build Number, Revision
// You can specify all the values or you can default the Build and Revision Numbers by using the '*' as shown below:
[assembly: AssemblyVersion("0.1.4.*")]
// [assembly: AssemblyFileVersion("0.1.4.*")]

// register the pre-application start method(s)
[assembly: PreApplicationStartMethod(typeof(Application), Common.PreApplicationStartMethodName)]