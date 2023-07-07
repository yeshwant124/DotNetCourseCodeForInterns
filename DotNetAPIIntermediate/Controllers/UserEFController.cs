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

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _userRepository.GetAllUsers();
            return users;                        
        }

        [HttpGet("GetSingleUser/{userid}")]
        public User GetUser(int userid)
        {
            User? user = _userRepository.GetUser(userid);
            return user;                   
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody]User user) 
        {
            User? userDB = _userRepository.GetUser(user.UserId);
            if (userDB != null)
            {
                userDB.FirstName = user.FirstName;
                userDB.LastName = user.LastName;
                userDB.Email = user.Email;
                userDB.Gender = user.Gender;
                userDB.Active = user.Active;
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to update User");
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody]UserDTO user)
        {
            User userDB = _mapper.Map<User>(user);            
           
           _userRepository.AddEntity<User>(userDB);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to add User");
        }

        [HttpDelete("DeleteUser/{userid}")]
        public IActionResult DeleteUser(int userid)
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

        [HttpGet("GetUserSalaries")]
        public IEnumerable<UserSalary> GetUserSalaries()
        {
            IEnumerable<UserSalary> userSalaries = _userRepository.GetUserSalaries();
            return userSalaries;
        }

        [HttpGet("GetUserSalary/{userid}")]
        public UserSalary GetUserSalary(int userid)
        {
            UserSalary? userSalary = _userRepository.GetUserSalary(userid);          
            return userSalary;
        }

        [HttpPut("EditUserSalary")]
        public IActionResult EditUserSalary([FromBody] UserSalary userSalary)
        {
            UserSalary? userSalaryDB = _userRepository.GetUserSalary(userSalary.UserId);
            if (userSalaryDB != null)
            {
                userSalaryDB.UserId = userSalary.UserId;
                userSalaryDB.Salary = userSalary.Salary;                
                if (_userRepository.SaveChanges())
                {
                    return Ok(userSalary);
                }
            }
            throw new Exception("Failed to update User Salary");
        }

        [HttpPost("AddUserSalary")]
        public IActionResult AddUserSalary([FromBody] UserSalary userSalary)
        {
            UserSalary userSalaryDB = new UserSalary();

            userSalaryDB.UserId=userSalary.UserId;
            userSalaryDB.Salary=userSalary.Salary;
            _userRepository.AddEntity<UserSalary>(userSalaryDB);
            if (_userRepository.SaveChanges())
            {
                return Ok(userSalary);
            }
            throw new Exception("Failed to add User Salary");
        }

        [HttpDelete("DeleteUserSalary/{userid}")]
        public IActionResult DeleteUserSalary(int userid)
        {
            UserSalary? userSalaryDB = _userRepository.GetUserSalary(userid);
            if (userSalaryDB != null)
            {
                _userRepository.RemoveEntity<UserSalary>(userSalaryDB);
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete User Salary");
        }

        [HttpGet("GetUsersJobInfo")]
        public IEnumerable<UserJobInfo> GetUsersJobInfo()
        {
            IEnumerable<UserJobInfo> usersJobInfo = _userRepository.GetUsersJobInfo();
            return usersJobInfo;
        }

        [HttpGet("GetUserJobInfo/{userid}")]
        public UserJobInfo GetUserJobInfo(int userid)
        {
            UserJobInfo? userJobInfo = _userRepository.GetUserJobInfo(userid);
            return userJobInfo;
        }

        [HttpPut("EditUserJobInfo")]
        public IActionResult EditUserJobInfo([FromBody] UserJobInfo userJobInfo)
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

        [HttpPost("AddUserJobInfo")]
        public IActionResult AddUserJobInfo([FromBody] UserJobInfo userJobInfo)
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

        [HttpPost("DelteUserJobInfo")]
        public IActionResult DelteUserJobInfo(int userid)
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