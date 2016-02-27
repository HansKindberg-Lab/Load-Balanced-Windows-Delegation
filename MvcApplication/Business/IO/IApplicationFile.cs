namespace MvcApplication.Business.IO
{
	public interface IApplicationFile
	{
		#region Properties

		string Content { get; }
		string Path { get; }

		#endregion

		#region Methods

		void AddContent(string content);
		void Clear();
		void TryRead();

		#endregion
	}
}