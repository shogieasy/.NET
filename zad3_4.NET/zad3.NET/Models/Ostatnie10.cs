using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zad3.NET.Models
{
    public class Ostatnie10
    {

        public static List<FizzBuzz> Sortowanie(List<FizzBuzz> lista)
        {
            var retList = new List<FizzBuzz>();

            int wielkoscListy = lista.Count;

            for (int i=0; i<10; i++)
            {
                if (wielkoscListy == 0)
                    return retList;
                else
                {
                    retList.Add(lista[wielkoscListy-1]);
                    wielkoscListy--;
                }

            }

            return retList;
        }
    }
}
