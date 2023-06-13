using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandApi.Dtos
{
    public class CommandUpdateDto
    {
         [Required]
        [MaxLength(250)]
        public String HowTo{get;set;}
        [Required]
        public String Platform{get;set;}

        [Required]
        public String CommandLine{get;set;}
    }
 }
