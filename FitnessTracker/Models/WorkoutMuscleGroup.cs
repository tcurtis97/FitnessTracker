﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class WorkoutMuscleGroup
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int MuscleId { get; set; }
    }
}
