namespace MvcApplication.Business
{
	public interface IApplicationDomain
	{
		#region Methods

		object GetData(string name);

		#endregion
	}
}