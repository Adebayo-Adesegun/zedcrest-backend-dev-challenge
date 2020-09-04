using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ZedCrest_Dev_Challenge.Services.Interface
{
    public interface IFizzBuzz
    {
        Tuple<bool, string, int> Buzz(int number);
    }
}
