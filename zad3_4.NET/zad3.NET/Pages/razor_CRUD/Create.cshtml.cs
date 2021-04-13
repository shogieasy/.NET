using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using zad3.NET.Data;
using zad3.NET.Models;

namespace zad3.NET.Pages.razor_CRUD
{
    public class CreateModel : PageModel
    {
        private readonly zad3.NET.Data.List _context;

        public CreateModel(zad3.NET.Data.List context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FizzBuzz.Add(FizzBuzz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
