using BTApp.DataAccess;
using BTApp.DataAccess.DAL;
using BTApp.Entities;
using System;
using System.Linq;

namespace BTApp.BL
{
    public class PasswordBL : IPasswordBL
    {

        private readonly IRepository _repository;

        public PasswordBL(IRepository repository)
        {
            _repository = repository;
        }

        UserPassword IPasswordBL.GeneratePassword(UserPassword userPassword)
        {
            userPassword.Password = RandomString(5);
            userPassword.ValideTo = userPassword.ValideFrom.AddSeconds(30);
            _repository.SavePassword(userPassword);
            _repository.SaveChanges();
            return userPassword;
        }
        

        string IPasswordBL.CheckValidity(int userId, string password)
        {
            UserPassword userPassword = _repository.GetUserPassword(userId, password);
            if (userPassword == null)
                throw new NullReferenceException("User&Password combo does not exist");
            if (userPassword.ValideFrom <= DateTime.Now && userPassword.ValideTo >= DateTime.Now)
                return "Password Is valid";
            return "Password expired";
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
