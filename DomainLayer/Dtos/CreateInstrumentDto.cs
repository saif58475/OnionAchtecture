using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos
{
    public class CreateInstrumentDto
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public int Quantity{ get; set; }
        [Required]
        public IFormFile Image { get; set; }

    }
}   
