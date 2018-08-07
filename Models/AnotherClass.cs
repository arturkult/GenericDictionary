using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionaries.Models
{
    public class AnotherClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
