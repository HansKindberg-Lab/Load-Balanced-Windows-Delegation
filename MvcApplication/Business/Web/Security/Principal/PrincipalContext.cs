using System;
using System.Security.Principal;
using MvcApplication.Business.Security.Principal;

namespace MvcApplication.Business.Web.Security.Principal
{
	public class PrincipalContext : IPrincipalContext
	{
		#region Constructors

		public PrincipalContext(IWebContext webContext)
		{
			if(webContext == null)
				throw new ArgumentNullException(nameof(webContext));

			this.WebContext = webContext;
		}

		#endregion

		#region Properties

		public virtual IPrincipal Current
		{
			get
			{
				var principal = this.WebContext.HttpContext.User;
				var windowsPrincipal = principal as WindowsPrincipal;

				if(windowsPrincipal != null)
					return (WindowsPrincipalWrapper) windowsPrincipal;

				return principal;
			}
		}

		protected internal virtual IWebContext WebContext { get; }

		#endregion
	}
}