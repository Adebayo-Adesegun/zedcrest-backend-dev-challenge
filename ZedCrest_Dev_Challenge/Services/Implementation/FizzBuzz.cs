using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ZedCrest_Dev_Challenge.Services.Interface;

namespace ZedCrest_Dev_Challenge.Services.Implementation
{
    public class FizzBuzz : IFizzBuzz
    {
        public Tuple<bool, string, int> Buzz(int number)
        {

            if (IsMultiple(3, number) && IsMultiple(5, number))
            {
                return new Tuple<bool, string, int>(true, "FizzBuzz", 0);
            }
            else if (IsMultiple(3, number))
            {
                return new Tuple<bool, string, int>(true, "Fizz", 0);
            }
            else if (IsMultiple(5, number))
            {
                return new Tuple<bool, string, int>(true, "Buzz", 0);
            }
           
            else if (!(IsMultiple(3, number) && IsMultiple(5, number)))
            {
                return new Tuple<bool, string, int>(false, "", number);
            }
            else
            {
                return new Tuple<bool, string, int>(false, "", 0);
            }
        }

        /// <summary>
        /// Checks if a number is divisble by another number 
        /// </summary>
        /// <param name="mutilpleCheck"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool IsMultiple(int divisor, int number)
        {
            return (number % divisor) == 0;
        }
    }
}
