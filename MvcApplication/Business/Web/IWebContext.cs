using System.Web;

namespace MvcApplication.Business.Web
{
	public interface IWebContext
	{
		#region Properties

		HttpContextBase HttpContext { get; }

		#endregion
	}
}