using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AmirCoffee.Web.Database;
using AmirCoffee.Web.Database.Entities;

namespace AmirCoffee.Web.Pages.Management.Menu
{
    public class DetailsModel : PageModel
    {
        private readonly AmirCoffee.Web.Database.AppDbContext _context;

        public DetailsModel(AmirCoffee.Web.Database.AppDbContext context)
        {
            _context = context;
        }

      public Database.Entities.Menu Menu { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            else 
            {
                Menu = menu;
            }
            return Page();
        }
    }
}
