using System.Security.Principal;
using MvcApplication.Business.Abstractions;

namespace MvcApplication.Business.Security.Principal
{
	public class WindowsPrincipalWrapper : Wrapper<WindowsPrincipal>, IWindowsPrincipal
	{
		#region Constructors

		public WindowsPrincipalWrapper(WindowsPrincipal windowsPrincipal) : base(windowsPrincipal, nameof(windowsPrincipal)) {}

		#endregion

		#region Properties

		public virtual IIdentity Identity => this.WrappedInstance.Identity;
		public virtual IWindowsIdentity WindowsIdentity => (WindowsIdentityWrapper) (WindowsIdentity) this.WrappedInstance.Identity;

		#endregion

		#region Methods

		public static WindowsPrincipalWrapper FromWindowsPrincipal(WindowsPrincipal windowsPrincipal)
		{
			return windowsPrincipal;
		}

		public virtual bool IsInRole(string role)
		{
			return this.WrappedInstance.IsInRole(role);
		}

		public static implicit operator WindowsPrincipalWrapper(WindowsPrincipal windowsPrincipal)
		{
			return windowsPrincipal != null ? new WindowsPrincipalWrapper(windowsPrincipal) : null;
		}

		#endregion
	}
}