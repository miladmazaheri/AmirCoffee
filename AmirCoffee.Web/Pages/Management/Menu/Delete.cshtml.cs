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
    public class DeleteModel : PageModel
    {
        private readonly AmirCoffee.Web.Database.AppDbContext _context;

        public DeleteModel(AmirCoffee.Web.Database.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }
            var menu = await _context.Menus.FindAsync(id);

            if (menu != null)
            {
                Menu = menu;
                _context.Menus.Remove(Menu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
