using System.Security.Principal;

namespace MvcApplication.Business.Security.Principal
{
	public interface IWindowsIdentity : IIdentity
	{
		#region Methods

		IWindowsImpersonationContext Impersonate();

		#endregion
	}
}