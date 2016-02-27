namespace MvcApplication.Models.ViewModels
{
	public interface IViewModelFactory
	{
		#region Methods

		T Create<T>();

		#endregion
	}
}