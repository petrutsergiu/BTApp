using BTApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTApp.DataAccess.DAL
{
    public class Repository:IRepository
    {
        private readonly AppDbContext _context;
         
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        UserPassword IRepository.GetPassword(int userId)
        {
            return _context.UserPasswords.FirstOrDefault(u => u.UserID == userId);
        }

        UserPassword IRepository.GetUserPassword(int userId, string password)
        {
            return _context.UserPasswords.FirstOrDefault(u => u.Password == password && u.UserID == userId);
        }

        void IRepository.SaveChanges()
        {
            _context.SaveChanges();
        }

        void IRepository.SavePassword(UserPassword userPassword)
        {
            _context.UserPasswords.Add(userPassword);
        }
    }
}
