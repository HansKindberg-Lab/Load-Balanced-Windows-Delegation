using System.Security.Principal;

namespace MvcApplication.Business.Security.Principal
{
	public interface IWindowsPrincipal : IPrincipal
	{
		#region Properties

		IWindowsIdentity WindowsIdentity { get; }

		#endregion
	}
}