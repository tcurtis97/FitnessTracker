using FitnessTracker.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Repositories
{
    public class WorkoutRepository : BaseRepository, IWorkoutRepository
    {
        public WorkoutRepository(IConfiguration config) : base(config) { }

        public void AddWorkout(Workout workout)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Workout([Name])
                        OUTPUT INSERTED.ID
                        VALUES (@name)";

                    cmd.Parameters.AddWithValue("@name", workout.Name);

                    int id = (int)cmd.ExecuteScalar();

                    workout.Id = id;
                }
            }
        }

        public void DeleteWorkout(int workoutId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM Workout
                        WHERE Id = @workoutId";

                    cmd.Parameters.AddWithValue("@workoutId", workoutId);

                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM PostWorkout
                        WHERE WorkoutId = @workoutId";
                    cmd.Parameters.AddWithValue("@workoutId", workoutId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Workout> GetAllWorkouts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT  Id, [Name]
                          FROM  Workout
                      ORDER BY  Name";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Workout> workouts = new List<Workout>();
                    while (reader.Read())
                    {
                        workouts.Add(NewWorkoutFromReader(reader));
                    }

                    reader.Close();

                    return workouts;
                }
            }
        }

        public Workout GetWorkoutById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, [Name]
                        FROM Workout
                        WHERE Id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Workout workout = new Workout();
                    if (reader.Read())
                    {
                        workout = NewWorkoutFromReader(reader);
                        reader.Close();
                        return workout;
                    }

                    reader.Close();
                    return workout;
                }
            }
        }


        public void UpdateWorkout(Workout workout)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Update  Workout
                           SET  
                                [Name] = @name
                         WHERE  Id = @id";
                    cmd.Parameters.AddWithValue("@name", workout.Name);
                    cmd.Parameters.AddWithValue("@id", workout.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Workout NewWorkoutFromReader(SqlDataReader reader)
        {
            return new Workout()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name"))
            };
        }
    }
}
