using Microsoft.AspNetCore.Mvc;
using OurLockingApp.Models;
using OurLockingApp.UserDbContext;

namespace OurLockingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersDbContext _dbContext;

        public UserController(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/user/GetUsers")]
        public IEnumerable<Users> GetUserDetails()
        {
           List<Users> users = (from c in _dbContext.users
                                select c).ToList();

            return users;
        }

        [HttpPost]
        [Route("/user/UpdateUser")]
        public IActionResult UpdateUserDetails([FromBody] Users aUsers)
        {
            try
            {
                Users users = _dbContext.users.Where(c => c.Id == aUsers.Id).First();

                users.Name = aUsers.Name;

                _dbContext.SaveChanges();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
