using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using zad3.NET.Migrations.zad3NET;

namespace zad3.NET.Models
{

    public class FizzBuzz
    {
        public int Id { get; set; }

        [Display(Name = "liczbe")]
        //[Required(ErrorMessage ="Polejest obowiązkowe")] nie działa na intach
        [Range(1, 1000)] //zakres


        public int liczba { get; set; }
       // [Required]
       // [MaxLength(200)]     // limit znaków
        public string wynik { get; set; }

        public string data { get; set; }

        public static string login { get; set; }

        /*
        public static void Logins()
        {
            login = ClaimTypes.Name;
        }
        */

        public void oblicz()
        {

            login = ClaimTypes.Name;

            data = DateTime.Now.ToString();

            wynik = "";

            if (liczba % 3 == 0)
            {
                wynik += "Fizz";
            }
            if (liczba % 5 == 0)
            {
                wynik += "Buzz";
            }



            
            if (wynik != "") //do 2
            {
                wynik = "Otrzymano: " + wynik + login; 
            }
            else
            {
                wynik = "Liczba " + liczba + " nie spełnia kryteriów Fizz/Buzz";
            }

        }



    }
}