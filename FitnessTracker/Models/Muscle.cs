using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class Muscle
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
