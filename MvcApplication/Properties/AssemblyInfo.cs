using System;
using System.Reflection;
using System.Runtime.InteropServices;
using log4net.Config;

[assembly: AssemblyDescription("Mvc-application for testing windows trusted delegation.")]
[assembly: CLSCompliant(true)]
[assembly: Guid("86e0f457-0c41-4543-b179-8d65c35546fc")]
[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

// ReSharper disable CheckNamespace
internal static class AssemblyInfo // ReSharper restore CheckNamespace
{
	#region Fields

	internal const string AssemblyName = "MvcApplication";

	#endregion
}