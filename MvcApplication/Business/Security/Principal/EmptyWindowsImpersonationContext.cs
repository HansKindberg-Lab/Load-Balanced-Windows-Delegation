using System;

namespace MvcApplication.Business.Security.Principal
{
	public class EmptyWindowsImpersonationContextWrapper : IWindowsImpersonationContext
	{
		#region Methods

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {}
		public virtual void Undo() {}

		#endregion
	}
}