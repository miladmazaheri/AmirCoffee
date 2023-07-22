using AmirCoffee.Web.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmirCoffee.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _appDbContext;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext appDbContext)
        {
	        _logger = logger;
	        _appDbContext = appDbContext;
        }

        public void OnGet()
        {

		}
    }
}