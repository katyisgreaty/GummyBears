using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gummies.Models
{
    public class Gummy
    {
        [Key]
        public int GummyId { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
    }
}
