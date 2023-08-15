using MySpotify.Models;

namespace MySpotify.Services.Interfaces
{
    public interface IUserService
    {
        public bool Save(User user);
        public User GetById(Guid id);
        public User GetByEmail(string email);
        public User Login(string email, string password);
    }
}
