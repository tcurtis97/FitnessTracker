using FitnessTracker.Models;
using FitnessTracker.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IWorkoutRepository _workoutRepo;
       

        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepo = workoutRepository;
            
        }
        // GET: WorkoutController
        public ActionResult Index()
        {
            List<Workout> workouts = _workoutRepo.GetAllWorkouts();
            return View(workouts);
        }

        // GET: WorkoutController/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkoutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkoutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workout workout)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkoutController/Edit/5
        public ActionResult Edit(int id)
        {
            Workout workout = _workoutRepo.GetWorkoutById(id);
            if (workout == null)
            {
                return NotFound();
            }
            return View(workout);
        }

        // POST: WorkoutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Workout workout)
        {
            try
            {
                _workoutRepo.UpdateWorkout(workout);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(workout);
            }
        }

        // GET: WorkoutController/Delete/5
        public ActionResult Delete(int id)
        {
            Workout workout = _workoutRepo.GetWorkoutById(id);
            return View(workout);
        }

        // POST: WorkoutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Workout workout)
        {
            try
            {
                _workoutRepo.DeleteWorkout(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(workout);
            }
        }
    }
}
