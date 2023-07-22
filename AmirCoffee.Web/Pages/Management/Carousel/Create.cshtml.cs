using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AmirCoffee.Web.Database;
using AmirCoffee.Web.Database.Entities;

namespace AmirCoffee.Web.Pages.Management.Carousel
{
    public class CreateModel : PageModel
    {
        private readonly AmirCoffee.Web.Database.AppDbContext _context;

        public CreateModel(AmirCoffee.Web.Database.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Database.Entities.Carousel Carousel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Carousels == null || Carousel == null)
            {
                return Page();
            }

            _context.Carousels.Add(Carousel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
