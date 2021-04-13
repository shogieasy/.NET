using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using zad3.NET.Models;

namespace zad3.NET.Pages
{
    public class ostatnio_szukaneModel : PageModel
    {
        public FizzBuzz FizzBuzz { get; set; }

        public void OnGet()
        {
            var ostatnio_szukane = HttpContext.Session.GetString("SessionAddress");

            if (ostatnio_szukane != null)
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(ostatnio_szukane);
        }
    }
}
