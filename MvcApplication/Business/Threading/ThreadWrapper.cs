using System.Security.Principal;
using System.Threading;

namespace MvcApplication.Business.Threading
{
	public class ThreadWrapper : IThread
	{
		#region Properties

		public virtual IPrincipal CurrentPrincipal => Thread.CurrentPrincipal;

		#endregion
	}
}