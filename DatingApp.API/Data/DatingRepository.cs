using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        
        public DatingRepository(DataContext context)
        {
            this._context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public User GetUser(int id)
        {
            var user = _context.Users
                .Include(p => p.Photos)
                .FirstOrDefault(u => u.Id == id);

            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _context.Users
                .Include(p => p.Photos)
                .ToList();

            return users;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0 ;
        }

        public bool Update()
        {
            throw new System.NotImplementedException();
        }

        
    }
}