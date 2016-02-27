namespace MvcApplication.Business.Extensions
{
	public static class SystemInformationExtension
	{
		#region Fields

		private const string _alertCssClass = "alert";

		#endregion

		#region Methods

		public static string CssClass(this ISystemInformation systemInformation)
		{
			if(systemInformation == null)
				return null;

			string additional;

			// ReSharper disable SwitchStatementMissingSomeCases
			switch(systemInformation.Type)
			{
				case SystemInformationType.Confirmation:
				{
					additional = "alert-success";
					break;
				}
				case SystemInformationType.Exception:
				{
					additional = "alert-danger";
					break;
				}
				case SystemInformationType.Warning:
				{
					additional = "alert-warning";
					break;
				}
				default:
				{
					additional = "alert-info";
					break;
				}
			}
			// ReSharper restore SwitchStatementMissingSomeCases

			return _alertCssClass + " " + additional;
		}

		#endregion
	}
}