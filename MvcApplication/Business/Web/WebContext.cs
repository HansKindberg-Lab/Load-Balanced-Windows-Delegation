using System.Web;

namespace MvcApplication.Business.Web
{
	public class WebContext : IWebContext
	{
		#region Properties

		public virtual HttpContextBase HttpContext => new HttpContextWrapper(System.Web.HttpContext.Current);

		#endregion
	}
}