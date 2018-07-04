using Data;
using InterfaceBusiness;
using Model;
using System.Linq;

namespace BusinessApi
{
    public class UserRepository : IUserRepository
    {
        ApiContext m_DbContext = new ApiContext();

        public User GetUser(int userId)
        {
            User user = m_DbContext.Users.FirstOrDefault(us => us.Id == userId);

            return user;
        }
    }
}
