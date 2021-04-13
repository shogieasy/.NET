using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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



        public void oblicz()
        {
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
                wynik = "Otrzymano: " + wynik;
            }
            else
            {
                wynik = "Liczba " + liczba + " nie spełnia kryteriów Fizz/Buzz";
            }

        }

    }
}