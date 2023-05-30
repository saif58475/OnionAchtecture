using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Instrument
    {
        [Key]
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int Quantity{ get; set; }
        public string Image{ get; set; }
    }
}
