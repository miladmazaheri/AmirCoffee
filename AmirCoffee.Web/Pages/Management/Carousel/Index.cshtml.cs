using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AmirCoffee.Web.Database;
using AmirCoffee.Web.Database.Entities;

namespace AmirCoffee.Web.Pages.Management.Carousel
{
    public class IndexModel : PageModel
    {
        private readonly AmirCoffee.Web.Database.AppDbContext _context;

        public IndexModel(AmirCoffee.Web.Database.AppDbContext context)
        {
            _context = context;
        }

        public IList<Database.Entities.Carousel> Carousel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Carousels != null)
            {
                Carousel = await _context.Carousels.ToListAsync();
            }
        }
    }
}
