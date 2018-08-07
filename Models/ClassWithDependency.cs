using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionaries.Models
{
    public class ClassWithDependency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public BasicClass Dependency { get; set; }
        public AnotherClass AnotherDependency { get; set; }
    }
}
