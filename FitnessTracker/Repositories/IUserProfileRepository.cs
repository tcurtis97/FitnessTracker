using FitnessTracker.Models;
using System.Collections.Generic;

namespace FitnessTracker.Repositories
{
    public interface IUserProfileRepository
    {
        void AddUser(UserProfile user);
        List<UserProfile> GetAll();
        UserProfile GetByEmail(string email);
        UserProfile GetById(int id);
    }
}