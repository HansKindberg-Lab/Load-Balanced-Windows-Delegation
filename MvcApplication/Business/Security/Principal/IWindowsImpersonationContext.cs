using System;

namespace MvcApplication.Business.Security.Principal
{
	public interface IWindowsImpersonationContext : IDisposable
	{
		#region Methods

		void Undo();

		#endregion
	}
}