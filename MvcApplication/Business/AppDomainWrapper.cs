using System;
using MvcApplication.Business.Abstractions;

namespace MvcApplication.Business
{
	public class AppDomainWrapper : Wrapper<AppDomain>, IApplicationDomain
	{
		#region Constructors

		public AppDomainWrapper(AppDomain appDomain) : base(appDomain, nameof(appDomain)) {}

		#endregion

		#region Methods

		public virtual object GetData(string name)
		{
			return this.WrappedInstance.GetData(name);
		}

		#endregion
	}
}