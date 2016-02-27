using System.Collections.Generic;

namespace MvcApplication.Business
{
	public interface ISystemInformation
	{
		#region Properties

		IList<string> DetailedInformation { get; }
		string Heading { get; set; }
		string Information { get; set; }
		SystemInformationType Type { get; set; }

		#endregion
	}
}