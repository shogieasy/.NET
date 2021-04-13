using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zad3.NET.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using zad3.NET.Data;
using zad3.NET.Pages.razor_CRUD;

namespace zad3.NET.Pages

{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly List _context;

        public List<FizzBuzz> FizzBuzzList { get; set; }

        [BindProperty]
        public FizzBuzz FizzBuzz {get; set; }
        public Ostatnie10 Ostatnie10 { get; set; }

        public IndexModel(ILogger<IndexModel> logger, List context) 
        {
            _logger = logger;
            _context = context;
        }



        public void OnGet()
        {
        }



        public async Task<IActionResult> OnPostAsync()
        {

            FizzBuzz.oblicz();

            if (ModelState.IsValid)
           {
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzz));
                //  return RedirectToPage("./ostatnio_szukane"); przechodzenie do zapisanych danych

                _context.FizzBuzz.Add(FizzBuzz);
                await _context.SaveChangesAsync();

            }
            return Page();
       
        }



    }
}
