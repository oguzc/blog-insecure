using System.Linq;
using JsonFlatFileDataStore;
using Admin.Api.Models;

namespace Admin.Api.Services
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataStore _store;
        private readonly IDocumentCollection<User> _collection;

        public AdminRepository()
        {
            // Open database (create new if file doesn't exist)
            _store = new DataStore("admins.json");

            // Get employee collection
            _collection = _store.GetCollection<User>();
        }

        public void AddNewUser(User user)
        {
            _collection.InsertOne(user);

        }

        public bool HasUser(string username)
        {
            return _collection.AsQueryable().Any(_ => _.Username == username);
        }

        public User GetUser(string username)
        {
            return _collection.AsQueryable().SingleOrDefault(_ => _.Username == username);
        }

        public User GetUserById(int userId)
        {
            return _collection.AsQueryable().SingleOrDefault(_ => _.Id == userId);
        }
    }
}
