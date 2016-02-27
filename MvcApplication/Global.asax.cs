using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcApplication.Business.InversionOfControl;
using MvcApplication.Business.StructureMap;
using StructureMap;

namespace MvcApplication
{
	public class Global : HttpApplication
	{
		#region Methods

		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected void Application_Start(object sender, EventArgs e)
		{
			AreaRegistration.RegisterAllAreas();

			DependencyResolver.SetResolver(new StructureMapDependencyResolver(new Container(new Registry())));

			RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			RouteTable.Routes.MapRoute("Default", "{controller}/{action}/{id}", new {controller = "Home", action = "Index", id = UrlParameter.Optional});
		}

		#endregion
	}
}