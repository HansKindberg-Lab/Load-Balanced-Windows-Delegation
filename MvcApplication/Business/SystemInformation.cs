using System.Collections.Generic;

namespace MvcApplication.Business
{
	public class SystemInformation : ISystemInformation
	{
		#region Properties

		public virtual IList<string> DetailedInformation { get; } = new List<string>();
		public virtual string Heading { get; set; }
		public virtual string Information { get; set; }
		public virtual SystemInformationType Type { get; set; }

		#endregion
	}
}