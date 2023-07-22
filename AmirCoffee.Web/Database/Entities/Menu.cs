using System.ComponentModel.DataAnnotations;

namespace AmirCoffee.Web.Database.Entities
{
	public class Menu
	{
		public int Id { get; set; }
		[MaxLength(64)]
		public string Title { get; set; }
		public string Url { get; set; }
		public int Order { get; set; }
		public MainMenuPosition Position { get; set; }
	}

	public enum MainMenuPosition
	{
		Right = 0,
		Left = 1,
	}
}
