using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Models.Forms
{
	public class FileTextForm
	{
		#region Properties

		[Display(Name = "Text to add to file")]
		public virtual string Text { get; set; }

		#endregion
	}
}