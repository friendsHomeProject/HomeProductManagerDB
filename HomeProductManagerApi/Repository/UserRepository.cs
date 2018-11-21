using Common.Models;
using Data;
using System.Linq;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HomeProductManagerContext _context;

        public UserRepository(HomeProductManagerContext context)
        {
            _context = context;
        }

        public UserModel GetUser(string name, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == name && u.Password == password);

            return new UserModel
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
