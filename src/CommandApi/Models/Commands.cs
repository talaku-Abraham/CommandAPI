using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandApi.Models
{
    public class Commands
    {
        [Key]
        [Required]
        public int Id{get;set;}
        [Required]
        [MaxLength(250)]
        public String HowTo{get;set;}
        [Required]
        public String Platform{get;set;}
        [Required]
        public String CommandLine{get;set;}
    }
}