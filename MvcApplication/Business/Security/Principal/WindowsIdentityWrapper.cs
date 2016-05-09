using System.Security.Principal;
using MvcApplication.Business.Abstractions;

namespace MvcApplication.Business.Security.Principal
{
	public class WindowsIdentityWrapper : Wrapper<WindowsIdentity>, IWindowsIdentity
	{
		#region Constructors

		public WindowsIdentityWrapper(WindowsIdentity windowsIdentity) : base(windowsIdentity, nameof(windowsIdentity)) {}

		#endregion

		#region Properties

		public virtual string AuthenticationType => this.WrappedInstance.AuthenticationType;
		public virtual TokenImpersonationLevel ImpersonationLevel => this.WrappedInstance.ImpersonationLevel;
		public virtual bool IsAuthenticated => this.WrappedInstance.IsAuthenticated;
		public virtual string Name => this.WrappedInstance.Name;

		#endregion

		#region Methods

		public static WindowsIdentityWrapper FromWindowsIdentity(WindowsIdentity windowsIdentity)
		{
			return windowsIdentity;
		}

		public virtual IWindowsImpersonationContext Impersonate()
		{
			return (WindowsImpersonationContextWrapper) this.WrappedInstance.Impersonate();
		}

		public static implicit operator WindowsIdentityWrapper(WindowsIdentity windowsIdentity)
		{
			return windowsIdentity != null ? new WindowsIdentityWrapper(windowsIdentity) : null;
		}

		#endregion
	}
}