using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace MvcApplication.Business.Configuration
{
	public interface IConfigurationManager
	{
		#region Properties

		NameValueCollection ApplicationSettings { get; }
		IEnumerable<ConnectionStringSettings> ConnectionStrings { get; }

		#endregion
	}
}