using System.Security.Principal;

namespace MvcApplication.Business.Threading
{
	public interface IThread
	{
		#region Properties

		IPrincipal CurrentPrincipal { get; }

		#endregion
	}
}