﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmirCoffee.Web.Database;
using AmirCoffee.Web.Database.Entities;

namespace AmirCoffee.Web.Pages.Management.Menu
{
    public class EditModel : PageModel
    {
        private readonly AmirCoffee.Web.Database.AppDbContext _context;

        public EditModel(AmirCoffee.Web.Database.AppDbContext context)
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

            var menu =  await _context.Menus.FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            Menu = menu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(Menu.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MenuExists(int id)
        {
          return (_context.Menus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
