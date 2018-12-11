using Common.Models;
using HomeProductManagerApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace HomeProductManagerApi.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository m_UserRepository;

        public UserController(IUserRepository userRepository)
        {
            m_UserRepository = userRepository;
        }

		/// <summary>
		/// login with specified user.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		[HttpPost("login")]
		public IActionResult Login([FromQuery] string name, [FromQuery] string password)
		{
			return Ok();
		}

		/// <summary>
		/// Gets the specified user.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		[HttpGet]
        public IActionResult Get([FromQuery] string name, [FromQuery] string password)
        {
            UserModel user = m_UserRepository.GetUser(name, password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Creates the new user.
        /// </summary>
        /// <param name="newUserViewModel">The new user view model.</param>
        /// <returns></returns>
        public IActionResult CreateNewUser([FromBody] NewUserViewModel newUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(); // TODO: return error
            }

            return Ok();
        }

    }
}
