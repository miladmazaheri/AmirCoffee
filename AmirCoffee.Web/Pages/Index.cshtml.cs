using AmirCoffee.Web.Database;
using AmirCoffee.Web.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmirCoffee.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _appDbContext;

        public List<Carousel> Carousels { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public void OnGet()
        {
            Carousels = _appDbContext.Carousels.OrderBy(x => x.Order).ToList();
        }
    }
}