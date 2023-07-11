using AutoMapper;
using DotNetAPIIntermediate.Data;
using DotNetAPIIntermediate.DTO;
using DotNetAPIIntermediate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserEFController : ControllerBase
    {
        private IMapper _mapper;

        private IUserRepository _userRepository;

        public UserEFController(IConfiguration config, IUserRepository userRepository)
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()));
            _userRepository = userRepository;
        }

        [HttpGet("Users")]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _userRepository.GetAllUsers();
            return users;                        
        }

        [HttpGet("Users/{userid}")]
        public User GetUser(int userid)
        {
            User? user = _userRepository.GetUser(userid);
            return user;                   
        }

        [HttpPut("Users")]
        public IActionResult PutUserEF([FromBody]User userToUpdate) 
        {
            User? userDB = _userRepository.GetUser(userToUpdate.UserId);
            if (userDB != null)
            {
                userDB.FirstName = userToUpdate.FirstName;
                userDB.LastName = userToUpdate.LastName;
                userDB.Email = userToUpdate.Email;
                userDB.Gender = userToUpdate.Gender;
                userDB.Active = userToUpdate.Active;
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to update User");
        }

        [HttpPost("Users")]
        public IActionResult PostUserEF([FromBody]UserDTO userToAdd)
        {
            User userDB = _mapper.Map<User>(userToAdd);            
           
           _userRepository.AddEntity<User>(userDB);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to add User");
        }

        [HttpDelete("User/{userid}")]
        public IActionResult DeleteUserEF(int userid)
        {
            User? userDB = _userRepository.GetUser(userid);
            if (userDB != null)
            {
                _userRepository.RemoveEntity<User>(userDB);
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete User");
        }

        [HttpGet("UserSalary")]
        public IEnumerable<UserSalary> GetUserSalariesEF()
        {
            IEnumerable<UserSalary> userSalaries = _userRepository.GetUserSalaries();
            return userSalaries;
        }

        [HttpGet("UserSalary/{userid}")]
        public UserSalary GetSingleUserSalaryEF(int userid)
        {
            UserSalary? userSalary = _userRepository.GetUserSalary(userid);          
            return userSalary;
        }

        [HttpPut("UserSalary")]
        public IActionResult PutUserSalaryEF([FromBody] UserSalary userSalaryForUpdate)
        {
            UserSalary? userSalaryDB = _userRepository.GetUserSalary(userSalaryForUpdate.UserId);
            if (userSalaryDB != null)
            {
                userSalaryDB.UserId = userSalaryForUpdate.UserId;
                userSalaryDB.Salary = userSalaryForUpdate.Salary;                
                if (_userRepository.SaveChanges())
                {
                    return Ok(userSalaryForUpdate);
                }
            }
            throw new Exception("Failed to update User Salary");
        }

        [HttpPost("UserSalary")]
        public IActionResult PostUserSalaryEF([FromBody] UserSalary userSalaryToAdd)
        {
            UserSalary userSalaryDB = new UserSalary();

            userSalaryDB.UserId= userSalaryToAdd.UserId;
            userSalaryDB.Salary= userSalaryToAdd.Salary;
            _userRepository.AddEntity<UserSalary>(userSalaryDB);
            if (_userRepository.SaveChanges())
            {
                return Ok(userSalaryToAdd);
            }
            throw new Exception("Failed to add User Salary");
        }

        [HttpDelete("UserSalary/{userid}")]
        public IActionResult DeleteUserSalaryEF(int userid)
        {
            UserSalary? userSalaryToDelete = _userRepository.GetUserSalary(userid);
            if (userSalaryToDelete != null)
            {
                _userRepository.RemoveEntity<UserSalary>(userSalaryToDelete);
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete User Salary");
        }

        [HttpGet("UserJobInfo")]
        public IEnumerable<UserJobInfo> GetUsersJobInfo()
        {
            IEnumerable<UserJobInfo> usersJobInfo = _userRepository.GetUsersJobInfo();
            return usersJobInfo;
        }

        [HttpGet("UserJobInfo/{userid}")]
        public UserJobInfo GetUserJobInfo(int userid)
        {
            UserJobInfo? userJobInfo = _userRepository.GetUserJobInfo(userid);
            return userJobInfo;
        }

        [HttpPut("UserJobInfo")]
        public IActionResult PutUserJobInfo([FromBody] UserJobInfo userJobInfo)
        {
            UserJobInfo? userJobInfoDB = _userRepository.GetUserJobInfo(userJobInfo.UserId);
            if (userJobInfoDB != null)
            {
                userJobInfoDB.UserId = userJobInfo.UserId;
                userJobInfoDB.JobTitle = userJobInfoDB.JobTitle;
                userJobInfoDB.Department = userJobInfo.Department;
                if (_userRepository.SaveChanges())
                {
                    return Ok(userJobInfoDB);
                }
            }
            throw new Exception("Failed to update User Job Info");
        }

        [HttpPost("UserJobInfo")]
        public IActionResult PostUserJobInfo([FromBody] UserJobInfo userJobInfo)
        {
            UserJobInfo userJobInfoDB = new UserJobInfo();

            userJobInfoDB.UserId=userJobInfo.UserId;
            userJobInfoDB.JobTitle = userJobInfo.JobTitle;
            userJobInfoDB.Department = userJobInfo.Department;

            _userRepository.AddEntity<UserJobInfo>(userJobInfoDB);
            if (_userRepository.SaveChanges())
            {
                return Ok(userJobInfoDB);
            }
            throw new Exception("Failed to add User Job Info");
        }

        [HttpPost("UserJobInfo")]
        public IActionResult DeleteUserJobInfo(int userid)
        {
            UserJobInfo? userJobInfoDB = _userRepository.GetUserJobInfo(userid);
            if (userJobInfoDB != null)
            {
                _userRepository.RemoveEntity<UserJobInfo>(userJobInfoDB);
                if (_userRepository.SaveChanges())
                {
                    return Ok(userJobInfoDB);
                }
            }
            throw new Exception("Failed to delete User Job Info");
        }
        
    }
}