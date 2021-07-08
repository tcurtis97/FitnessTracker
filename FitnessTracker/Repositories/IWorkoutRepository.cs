using FitnessTracker.Models;
using System.Collections.Generic;

namespace FitnessTracker.Repositories
{
    public interface IWorkoutRepository
    {
        void AddWorkout(Workout workout);
        void DeleteWorkout(int workoutId);
        List<Workout> GetAllWorkouts();
        Workout GetWorkoutById(int id);
        void UpdateWorkout(Workout workout);
    }
}