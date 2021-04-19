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
    public class IndexModel : PageModel
    {
        private readonly zad3.NET.Data.List _context;
        public List<FizzBuzz> FizzBuzzList { get; set; }
        public IndexModel(zad3.NET.Data.List context)
        {
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }

        public async Task OnGetAsync()
        {
            FizzBuzz = await _context.FizzBuzz.ToListAsync();
            FizzBuzz = _context.FizzBuzz.Take(10).OrderByDescending(s => s.data).ToList();
            //  FizzBuzzList = Ostatnie10.Sortowanie(FizzBuzzList);
            // FizzBuzz = FizzBuzzList;
            // FizzBuzz = await _context.FizzBuzz.ToListAsync();


        }

    }
}
