using System;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Web;
using System.Web.SessionState;
using MvcApplication.Business.Configuration;
using MvcApplication.Business.IO;
using MvcApplication.Business.Security.Principal;
using MvcApplication.Business.Threading;
using MvcApplication.Business.Web;
using MvcApplication.Business.Web.Security.Principal;
using MvcApplication.Models.ViewModels;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace MvcApplication.Business.InversionOfControl
{
	public class Registry : global::StructureMap.Configuration.DSL.Registry
	{
		#region Constructors

		public Registry()
		{
			Register(this);
		}

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
		public static void Register(IProfileRegistry registry)
		{
			if(registry == null)
				throw new ArgumentNullException(nameof(registry));

			registry.For<AppDomain>().Singleton().Use(() => AppDomain.CurrentDomain);
			registry.For<IApplicationDomain>().Singleton().Use<AppDomainWrapper>();
			registry.For<IApplicationFile>().Singleton().Use<ApplicationFile>();
			registry.For<IConfigurationManager>().Singleton().Use<ConfigurationManagerWrapper>();
			registry.For<IEnvironment>().Singleton().Use<EnvironmentWrapper>();
			registry.For<IFileSystem>().Singleton().Use<FileSystem>();
			registry.For<IPrincipalContext>().Singleton().Use<PrincipalContext>();
			registry.For<IThread>().Singleton().Use<ThreadWrapper>();
			registry.For<IViewModelFactory>().Singleton().Use<ViewModelFactory>();
			registry.For<IWindowsIdentityContext>().Singleton().Use<WindowsIdentityContext>();

			// Web
			registry.For<HttpApplicationState>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Application);
			registry.For<HttpApplicationStateBase>().HybridHttpOrThreadLocalScoped().Use<HttpApplicationStateWrapper>();
			registry.For<HttpContext>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current);
			registry.For<HttpContextBase>().HybridHttpOrThreadLocalScoped().Use<HttpContextWrapper>();
			registry.For<HttpRequest>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Request);
			registry.For<HttpRequestBase>().HybridHttpOrThreadLocalScoped().Use<HttpRequestWrapper>();
			registry.For<HttpResponse>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Response);
			registry.For<HttpResponseBase>().HybridHttpOrThreadLocalScoped().Use<HttpResponseWrapper>();
			registry.For<HttpServerUtility>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Server);
			registry.For<HttpServerUtilityBase>().HybridHttpOrThreadLocalScoped().Use<HttpServerUtilityWrapper>();
			registry.For<HttpSessionState>().HybridHttpOrThreadLocalScoped().Use(() => HttpContext.Current.Session);
			registry.For<HttpSessionStateBase>().HybridHttpOrThreadLocalScoped().Use<HttpSessionStateWrapper>();
			registry.For<IWebContext>().Singleton().Use<WebContext>();
		}

		#endregion
	}
}