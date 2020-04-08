using BTApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTApp.BL
{
    public interface IPasswordBL
    {
        UserPassword GeneratePassword(UserPassword userPassword);
        string CheckValidity(int userId, string password);
    }
}
