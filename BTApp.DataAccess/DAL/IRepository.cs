using BTApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTApp.DataAccess.DAL
{
    public interface IRepository
    {
        UserPassword GetPassword(int userId);
        void SavePassword(UserPassword userPassword);
        void SaveChanges();
        UserPassword GetUserPassword(int userId, string password);
    }
}
