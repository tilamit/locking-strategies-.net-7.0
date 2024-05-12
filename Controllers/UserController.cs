using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            //Optimistic Locking - For this locking strategy, create a timestamp column in database table
            //try
            //{
            //    Users users = _dbContext.users.Where(c => c.Id == aUsers.Id).First();

            //    users.Name = aUsers.Name;

            //    _dbContext.SaveChanges();

            //    return Ok(users);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            //Pessimistic Locking - For this locking strategy, delete timestamp column in database table if created earlier
            using var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {
                Users users = _dbContext.users.Where(c => c.Id == aUsers.Id).First();
                _dbContext.Entry(users).State = EntityState.Modified;

                _dbContext.Database.ExecuteSqlRaw("SELECT * FROM Users WITH (UPDLOCK) WHERE Id = @Id", 
                                                                                      new SqlParameter("Id", aUsers.Id), 1);

                users.Name = aUsers.Name;

                _dbContext.SaveChanges();

                transaction.Commit();

                return Ok(users);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return BadRequest(ex.Message);
            }
        }
    }
}
