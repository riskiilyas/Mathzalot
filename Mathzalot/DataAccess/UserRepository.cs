using System;
using MySql.Data.MySqlClient;
using Mathzalot.Models;

namespace Mathzalot.DataAccess
{
    public class UserRepository
    {
        private readonly MathzalotDbContext _context;

        public UserRepository(MathzalotDbContext context)
        {
            _context = context;
        }

        public void Add(UserModel User)
        {
            _context.Users.Add(User);
        }
        public void Update(UserModel User)
        {
            _context.Users.Update(User);
        }
        public void Delete(UserModel User)
        {
            _context.Users.Remove(User);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public UserModel GetById(int id)
        {
            return _context.Users.Find(id);
        }
        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}