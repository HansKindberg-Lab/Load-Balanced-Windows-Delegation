using System;
using System.Web.Mvc;
using MvcApplication.Models.ViewModels;

namespace MvcApplication.Controllers
{
	public abstract class SiteController : Controller
	{
		#region Constructors

		protected SiteController(IViewModelFactory viewModelFactory)
		{
			if(viewModelFactory == null)
				throw new ArgumentNullException(nameof(viewModelFactory));

			this.ViewModelFactory = viewModelFactory;
		}

		#endregion

		#region Properties

		protected internal virtual IViewModelFactory ViewModelFactory { get; }

		#endregion
	}
}