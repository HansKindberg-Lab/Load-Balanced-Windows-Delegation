using System.Security.Principal;

namespace MvcApplication.Business.Security.Principal
{
	public class Identity : IIdentity
	{
		#region Properties

		public virtual string AuthenticationType { get; set; }
		public virtual bool IsAuthenticated { get; set; }
		public virtual string Name { get; set; }

		#endregion
	}
}