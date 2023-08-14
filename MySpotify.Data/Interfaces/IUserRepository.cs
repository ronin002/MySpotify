using MySpotify.Models;

namespace MySpotify.Data.Interfaces
{
    public interface IUserRepository
    {
        public bool Save(User user);
        public User GetById(Guid id);
        public User GetByEmail(string email);
        public User Login(string email, string password);
    }
}
