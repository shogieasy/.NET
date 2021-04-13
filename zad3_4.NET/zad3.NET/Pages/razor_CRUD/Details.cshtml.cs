using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zad3.NET.Data;
using zad3.NET.Models;

namespace zad3.NET.Pages.razor_CRUD
{
    public class DetailsModel : PageModel
    {
        private readonly zad3.NET.Data.List _context;

        public DetailsModel(zad3.NET.Data.List context)
        {
            _context = context;
        }

        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
