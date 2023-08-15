using MySpotify.Data.Interfaces;
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotify.Data;
using MySpotity.Data;

namespace MySpotify.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public User GetById(Guid id)
        {

            var user = new User();
            user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public bool Save(User user)
        {

            var userExists = _context.Users.Any(x => x.Email == user.Email);
            if (userExists)
            {
                return false;
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;

        }
    }
}
