using System;
using StructureMap;

namespace MvcApplication.Models.ViewModels
{
	public class ViewModelFactory : IViewModelFactory
	{
		#region Constructors

		public ViewModelFactory(IContainer container)
		{
			if(container == null)
				throw new ArgumentNullException(nameof(container));

			this.Container = container;
		}

		#endregion

		#region Properties

		protected internal virtual IContainer Container { get; }

		#endregion

		#region Methods

		public virtual T Create<T>()
		{
			return this.Container.GetInstance<T>();
		}

		#endregion
	}
}