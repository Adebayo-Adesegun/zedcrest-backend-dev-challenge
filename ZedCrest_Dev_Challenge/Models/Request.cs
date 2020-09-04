using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZedCrest_Dev_Challenge.Models
{
    public class Request
    {
        [Required( ErrorMessage = "Number is required")]
        [Range(minimum:1, maximum:100, ErrorMessage = "Number should be in the range of 1 to 100")]
        public int Number { get; set; }
    }
}
