using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZedCrest_Dev_Challenge.Models
{
    public class Response<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
