using System;
using System.Security.Principal;

namespace MvcApplication.Business.Security.Principal.Extensions
{
	public static class PrincipalExtension
	{
		#region Methods

		public static IWindowsImpersonationContext Impersonate(this IPrincipal principal)
		{
			if(principal == null)
				throw new ArgumentNullException(nameof(principal));

			var windowsPrincipal = principal as IWindowsPrincipal;

			if(windowsPrincipal == null)
			{
				var concreteWindowsPrincipal = principal as WindowsPrincipal;

				if(concreteWindowsPrincipal != null)
					windowsPrincipal = (WindowsPrincipalWrapper) concreteWindowsPrincipal;
			}

			if(windowsPrincipal == null)
				throw new InvalidOperationException("The principal is not a windows-principal.");

			return windowsPrincipal.WindowsIdentity.Impersonate();

			//return windowsPrincipal != null ? windowsPrincipal.WindowsIdentity.Impersonate() : new EmptyWindowsImpersonationContextWrapper();
		}

		#endregion
	}
}