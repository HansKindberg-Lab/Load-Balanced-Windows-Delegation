using System;
using System.Security.Principal;
using System.Web;
using MvcApplication.Business;
using MvcApplication.Business.IO;
using MvcApplication.Business.Security.Principal;
using MvcApplication.Business.Security.Principal.Extensions;
using MvcApplication.Business.Threading;
using MvcApplication.Models.Forms;

namespace MvcApplication.Models.ViewModels
{
	public class HomeModel
	{
		#region Fields

		private FileTextForm _form;
		private IIdentity _impersonatedIdentity;

		#endregion

		#region Constructors

		public HomeModel(IEnvironment environment, HttpContextBase httpContext, IThread thread, IWindowsIdentityContext windowsIdentityContext)
		{
			if(environment == null)
				throw new ArgumentNullException(nameof(environment));

			if(httpContext == null)
				throw new ArgumentNullException(nameof(httpContext));

			if(thread == null)
				throw new ArgumentNullException(nameof(thread));

			if(windowsIdentityContext == null)
				throw new ArgumentNullException(nameof(windowsIdentityContext));

			this.Environment = environment;
			this.HttpContext = httpContext;
			this.Thread = thread;
			this.WindowsIdentityContext = windowsIdentityContext;
		}

		#endregion

		#region Properties

		public virtual IApplicationFile ApplicationFile { get; set; }

		public virtual string Content
		{
			get
			{
				if(this.ApplicationFile == null)
					return null;

				var content = this.ApplicationFile.Content ?? string.Empty;

				return content.Replace(this.Environment.NewLine, @"\n").Replace(@"\n", "<br />");
			}
		}

		public virtual IIdentity ContextIdentity => this.HttpContext.User.Identity;
		protected internal virtual IEnvironment Environment { get; }

		public virtual FileTextForm Form
		{
			get { return this._form ?? (this._form = new FileTextForm()); }
			set { this._form = value; }
		}

		protected internal virtual HttpContextBase HttpContext { get; }

		public virtual IIdentity ImpersonatedIdentity
		{
			get
			{
				// ReSharper disable InvertIf
				if(this._impersonatedIdentity == null)
				{
					using(this.HttpContext.User.Impersonate())
					{
						var windowsIdentity = this.WindowsIdentityContext.Current;

						this._impersonatedIdentity = new Identity
						{
							AuthenticationType = windowsIdentity.AuthenticationType,
							IsAuthenticated = windowsIdentity.IsAuthenticated,
							Name = windowsIdentity.Name
						};
					}
				}
				// ReSharper restore InvertIf

				return this._impersonatedIdentity;
			}
		}

		public virtual ISystemInformation SystemInformation { get; set; }
		protected internal virtual IThread Thread { get; }
		public virtual IIdentity ThreadIdentity => this.Thread.CurrentPrincipal.Identity;
		public virtual IIdentity WindowsIdentity => this.WindowsIdentityContext.Current;
		protected internal virtual IWindowsIdentityContext WindowsIdentityContext { get; }

		#endregion
	}
}