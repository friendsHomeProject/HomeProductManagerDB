using BusinessApi;
using InterfaceBusiness;
using Model;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository m_UserRepository;

        public UserController(IUserRepository userRepository)
        {
            m_UserRepository = new UserRepository();
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IHttpActionResult GetUser(int userId)
        {
            User user = m_UserRepository.GetUser(userId);

            return Ok(user);
        }
    }
}
