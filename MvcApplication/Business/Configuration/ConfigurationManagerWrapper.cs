using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace MvcApplication.Business.Configuration
{
	public class ConfigurationManagerWrapper : IConfigurationManager
	{
		#region Properties

		public virtual NameValueCollection ApplicationSettings => ConfigurationManager.AppSettings;
		public virtual IEnumerable<ConnectionStringSettings> ConnectionStrings => ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>();

		#endregion
	}
}