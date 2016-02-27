using System.Security.Principal;

namespace MvcApplication.Business.Security.Principal
{
	public class WindowsIdentityContext : IWindowsIdentityContext
	{
		#region Properties

		public virtual IWindowsIdentity Current => (WindowsIdentityWrapper) WindowsIdentity.GetCurrent();

		#endregion
	}
}