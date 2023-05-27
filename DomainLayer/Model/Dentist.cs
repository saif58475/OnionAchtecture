﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Dentist
    {
        [Key]
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int Age{ get; set; }
        public string Major { get; set; }
    }
}
