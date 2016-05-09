using System.Security.Principal;

namespace MvcApplication.Business.Security.Principal
{
	public interface IWindowsIdentity : IIdentity
	{
		#region Properties

		TokenImpersonationLevel ImpersonationLevel { get; }

		#endregion

		#region Methods

		IWindowsImpersonationContext Impersonate();

		#endregion
	}
}