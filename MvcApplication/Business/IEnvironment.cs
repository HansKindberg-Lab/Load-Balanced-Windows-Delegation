namespace MvcApplication.Business
{
	public interface IEnvironment
	{
		#region Properties

		string MachineName { get; }
		string NewLine { get; }

		#endregion
	}
}