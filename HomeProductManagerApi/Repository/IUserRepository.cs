
using Common.Models;

namespace Repository
{
    public interface IUserRepository
    {
        UserModel GetUser(string name, string password);
    }
}
