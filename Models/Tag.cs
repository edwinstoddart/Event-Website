using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tag() { }
        public Tag(string name)
        {
            Name = name;
        }
    }
}
