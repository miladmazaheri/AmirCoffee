using AmirCoffee.Web.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmirCoffee.Web.Database
{
	public class AppDbContext : DbContext
	{
		private readonly string _connectionString;

		public AppDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public DbSet<Menu> Menus { get; set; }
		public DbSet<Carousel> Carousels { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
			base.OnConfiguring(optionsBuilder);
		}
	}
}
