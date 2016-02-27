using System.Security.Principal;

namespace MvcApplication.Business.Security.Principal
{
	public interface IPrincipalContext
	{
		#region Properties

		IPrincipal Current { get; }

		#endregion
	}
}