using System;
using System.Collections.Generic;
using System.Linq;
using Admin.Api.Models;

namespace Admin.Api.Services
{
    public interface IAdminRepository
    {
        void AddNewUser(User user);
        bool HasUser(string username);
        User GetUser(string username);
        User GetUserById(int userId);
    }
}
