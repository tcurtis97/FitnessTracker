using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public DateTime SessionDate { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
