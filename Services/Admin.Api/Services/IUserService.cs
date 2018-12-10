using Admin.Api.Models;

namespace Admin.Api.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Register(User user, string password);
        User GetById(int id);
    }
}
