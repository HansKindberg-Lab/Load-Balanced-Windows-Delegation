using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using MvcApplication.Business;
using MvcApplication.Business.IO;
using MvcApplication.Models.Forms;
using MvcApplication.Models.ViewModels;

namespace MvcApplication.Controllers
{
	public class HomeController : SiteController
	{
		#region Constructors

		public HomeController(IApplicationFile applicationFile, IViewModelFactory viewModelFactory) : base(viewModelFactory)
		{
			if(applicationFile == null)
				throw new ArgumentNullException(nameof(applicationFile));

			this.ApplicationFile = applicationFile;
		}

		#endregion

		#region Properties

		protected internal virtual IApplicationFile ApplicationFile { get; }

		#endregion

		#region Methods

		[HttpPost]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public virtual ActionResult Clear()
		{
			try
			{
				this.ApplicationFile.Clear();

				return this.RedirectToAction("Index");
			}
			catch(Exception exception)
			{
				return this.View("~/Views/Home/Index.cshtml", this.CreateModel(exception));
			}
		}

		protected internal virtual HomeModel CreateModel()
		{
			return this.CreateModel(null);
		}

		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected internal virtual HomeModel CreateModel(Exception exception)
		{
			var model = this.ViewModelFactory.Create<HomeModel>();

			if(exception == null)
			{
				try
				{
					this.ApplicationFile.TryRead();

					model.ApplicationFile = this.ApplicationFile;

					return model;
				}
				catch(Exception catchedException)
				{
					exception = catchedException;

					model.ApplicationFile = null;
				}
			}

			// ReSharper disable ConditionIsAlwaysTrueOrFalse
			if(exception != null)
				model.SystemInformation = this.CreateSystemInformation(exception);
			// ReSharper restore ConditionIsAlwaysTrueOrFalse

			return model;
		}

		protected internal virtual ISystemInformation CreateSystemInformation(Exception exception)
		{
			if(exception == null)
				throw new ArgumentNullException(nameof(exception));

			return new SystemInformation
			{
				Heading = "Error",
				Information = exception.ToString(),
				Type = SystemInformationType.Exception
			};
		}

		public virtual ActionResult Index()
		{
			return this.View(this.CreateModel());
		}

		[HttpPost]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
		public virtual ActionResult Index(FileTextForm form)
		{
			// ReSharper disable InvertIf
			if(!string.IsNullOrEmpty(form?.Text))
			{
				try
				{
					this.ApplicationFile.AddContent(form.Text);

					var model = this.CreateModel();

					model.ApplicationFile = this.ApplicationFile;

					model.SystemInformation = new SystemInformation
					{
						Heading = "Confirmation",
						Information = "Added the text successfully.",
						Type = SystemInformationType.Confirmation
					};

					return this.View(model);
				}
				catch(Exception exception)
				{
					return this.View(this.CreateModel(exception));
				}
			}
			// ReSharper restore InvertIf

			return this.Index();
		}

		#endregion
	}
}