using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
         // Add user
         // Update user
         // Delete user
         // Get singel user
         // Get all users
         // Save changes

         IEnumerable<User> GetUsers();
         User GetUser(int id);
         void Add(User user);
         bool Update();
         void Delete(User user);
         bool SaveAll();                  
    }
}