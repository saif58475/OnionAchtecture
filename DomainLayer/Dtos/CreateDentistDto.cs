﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos
{
    public class CreateDentistDto
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public int Age{ get; set; }
        [Required]
        public string Major{ get; set; }
    }
}
