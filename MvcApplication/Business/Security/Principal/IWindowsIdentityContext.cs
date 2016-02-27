namespace MvcApplication.Business.Security.Principal
{
	public interface IWindowsIdentityContext
	{
		#region Properties

		IWindowsIdentity Current { get; }

		#endregion
	}
}