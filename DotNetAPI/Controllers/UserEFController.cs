using AutoMapper;
using DotNetAPI.Data;
using DotNetAPI.DTO;
using DotNetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserEFController : ControllerBase
    {
        //With AutoMapper
        private DataContextEF _entityFramework;

        private IMapper _mapper;

        public UserEFController(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()));
        }

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _entityFramework.Users.ToList();
            return users;                        
        }

        [HttpGet("GetSingleUser/{userid}")]
        public User GetUser(int userid)
        {
            User? user = _entityFramework.Users.Where(u => u.UserId == userid).FirstOrDefault();
            if (user != null) {
                return user;
            }
            throw new Exception("User not found");                    
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody]User user) 
        {
            User? userDB = _entityFramework.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            if (userDB != null)
            {
                userDB.FirstName = user.FirstName;
                userDB.LastName = user.LastName;
                userDB.Email = user.Email;
                userDB.Gender = user.Gender;
                userDB.Active = user.Active;
                if (_entityFramework.SaveChanges() > 0)
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
            
           _entityFramework.Add(userDB);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            throw new Exception("Failed to add User");
        }

        [HttpDelete("DeleteUser/{userid}")]
        public IActionResult DeleteUser(int userid)
        {
            User? userDB = _entityFramework.Users.Where(u => u.UserId == userid).FirstOrDefault();
            if (userDB != null)
            {
                _entityFramework.Remove(userDB);
                if (_entityFramework.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete User");
        }

        [HttpGet("GetUserSalaries")]
        public IEnumerable<UserSalary> GetUserSalaries()
        {
            IEnumerable<UserSalary> userSalaries = _entityFramework.UserSalary.ToList().OrderByDescending(u=>u.UserId);
            return userSalaries;
        }

        [HttpGet("GetUserSalary/{userid}")]
        public UserSalary GetUserSalary(int userid)
        {
            UserSalary? userSalary = _entityFramework.UserSalary.Where(u => u.UserId == userid).FirstOrDefault();
            if (userSalary != null)
            {
                return userSalary;
            }
            throw new Exception("User Salary not found");
        }

        [HttpPut("EditUserSalary")]
        public IActionResult EditUserSalary([FromBody] UserSalary userSalary)
        {
            UserSalary? userSalaryDB = _entityFramework.UserSalary.Where(u => u.UserId == userSalary.UserId).FirstOrDefault();
            if (userSalaryDB != null)
            {
                userSalaryDB.UserId = userSalary.UserId;
                userSalaryDB.Salary = userSalary.Salary;                
                if (_entityFramework.SaveChanges() > 0)
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
            _entityFramework.Add(userSalaryDB);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok(userSalary);
            }
            throw new Exception("Failed to add User Salary");
        }

        [HttpDelete("DeleteUserSalary/{userid}")]
        public IActionResult DeleteUserSalary(int userid)
        {
            UserSalary? userSalaryDB = _entityFramework.UserSalary.Where(u => u.UserId == userid).FirstOrDefault();
            if (userSalaryDB != null)
            {
                _entityFramework.Remove(userSalaryDB);
                if (_entityFramework.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete User Salary");
        }

        [HttpGet("GetUsersJobInfo")]
        public IEnumerable<UserJobInfo> GetUsersJobInfo()
        {
            IEnumerable<UserJobInfo> usersJobInfo = _entityFramework.UserJobInfo.ToList().OrderByDescending(u => u.UserId);
            return usersJobInfo;
        }

        [HttpGet("GetUserJobInfo/{userid}")]
        public UserJobInfo GetUserJobInfo(int userid)
        {
            UserJobInfo? userJobInfo = _entityFramework.UserJobInfo.Where(u => u.UserId == userid).FirstOrDefault();
            if (userJobInfo != null)
            {
                return userJobInfo;
            }
            throw new Exception("User Job Info not found");
        }

        [HttpPut("EditUserJobInfo")]
        public IActionResult EditUserJobInfo([FromBody] UserJobInfo userJobInfo)
        {
            UserJobInfo? userJobInfoDB = _entityFramework.UserJobInfo.Where(u => u.UserId == userJobInfo.UserId).FirstOrDefault();
            if (userJobInfoDB != null)
            {
                userJobInfoDB.UserId = userJobInfo.UserId;
                userJobInfoDB.JobTitle = userJobInfoDB.JobTitle;
                userJobInfoDB.Department = userJobInfo.Department;
                if (_entityFramework.SaveChanges() > 0)
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

            _entityFramework.Add(userJobInfoDB);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok(userJobInfoDB);
            }
            throw new Exception("Failed to add User Job Info");
        }

        [HttpPost("DelteUserJobInfo")]
        public IActionResult DelteUserJobInfo(int userid)
        {
            UserJobInfo? userJobInfoDB = _entityFramework.UserJobInfo.Where(u => u.UserId == userid).FirstOrDefault();
            if (userJobInfoDB != null)
            {
                _entityFramework.Remove(userJobInfoDB);
                if (_entityFramework.SaveChanges() > 0)
                {
                    return Ok(userJobInfoDB);
                }
            }
            throw new Exception("Failed to delete User Job Info");
        }

        //Without AutoMapper        

        //private DataContextEF _entityFramework;

        //public UserEFController(IConfiguration config)
        //{
        //    _entityFramework = new DataContextEF(config);            
        //}

        //[HttpPut("EditUser")]
        //public IActionResult EditUser([FromBody] User user)
        //{
        //    User? userDB = _entityFramework.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
        //    if (userDB != null)
        //    {
        //        userDB.FirstName = user.FirstName;
        //        userDB.LastName = user.LastName;
        //        userDB.Email = user.Email;
        //        userDB.Gender = user.Gender;
        //        userDB.Active = user.Active;
        //        if (_entityFramework.SaveChanges() > 0)
        //        {
        //            return Ok();
        //        }
        //    }
        //    throw new Exception("Failed to update User");
        //}

        //[HttpPost("AddUser")]
        //public IActionResult AddUser([FromBody] UserDTO user)
        //{
        //    User userDB = _mapper.Map<User>(user);

        //    _entityFramework.Add(userDB);
        //    if (_entityFramework.SaveChanges() > 0)
        //    {
        //        return Ok();
        //    }
        //    throw new Exception("Failed to add User");
        //}

        //[HttpDelete("DeleteUser/{userid}")]
        //public IActionResult DeleteUser(int userid)
        //{
        //    User? userDB = _entityFramework.Users.Where(u => u.UserId == userid).FirstOrDefault();
        //    if (userDB != null)
        //    {
        //        _entityFramework.Remove(userDB);
        //        if (_entityFramework.SaveChanges() > 0)
        //        {
        //            return Ok();
        //        }
        //    }
        //    throw new Exception("Failed to delete User");
        //}
    }
}