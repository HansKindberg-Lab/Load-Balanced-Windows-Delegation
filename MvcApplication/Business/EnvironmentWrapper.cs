using System;

namespace MvcApplication.Business
{
	public class EnvironmentWrapper : IEnvironment
	{
		#region Properties

		public virtual string MachineName => Environment.MachineName;
		public virtual string NewLine => Environment.NewLine;

		#endregion
	}
}