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

			return windowsPrincipal != null ? windowsPrincipal.WindowsIdentity.Impersonate() : new EmptyWindowsImpersonationContextWrapper();
		}

		#endregion
	}
}