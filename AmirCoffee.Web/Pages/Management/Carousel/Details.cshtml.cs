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
    public class DetailsModel : PageModel
    {
        private readonly AmirCoffee.Web.Database.AppDbContext _context;

        public DetailsModel(AmirCoffee.Web.Database.AppDbContext context)
        {
            _context = context;
        }

      public Database.Entities.Carousel Carousel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Carousels == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousels.FirstOrDefaultAsync(m => m.Id == id);
            if (carousel == null)
            {
                return NotFound();
            }
            else 
            {
                Carousel = carousel;
            }
            return Page();
        }
    }
}
