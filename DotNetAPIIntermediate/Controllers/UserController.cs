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
    public class UserController : ControllerBase
    {
        private DataContextDapper _dapper;

        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("TestConnection")]
        //public IEnumerable<Users> GetUsers()
        public DateTime TestConnection()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        }

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            string sql = @"SELECT [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
                FROM [EmployeeInfo_YK].[TutorialAppSchema].[Users]";
            IEnumerable<User> users= _dapper.LoadData<User>(sql);

            return users;                        
        }

        [HttpGet("GetSingleUser/{userid}")]
        public User GetUser(int userid)
        {
            string sql = @"SELECT [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active]
                FROM [EmployeeInfo_YK].[TutorialAppSchema].[Users]
                WHERE UserId=" + userid;
            User user = _dapper.LoadDataSingle<User>(sql);

            return user;                       
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody]User user) 
        {
            string sql = "UPDATE [EmployeeInfo_YK].[TutorialAppSchema].[Users] SET " +
                          "[FirstName]='" + user.FirstName + "'," + 
                          "[LastName]= '" + user.LastName + "'," +
                          "[Email]= '" + user.Email + "'," +
                          "[Gender]= '" + user.Gender + "'," +
                          "[Active]= '" + user.Active + "'" +
                    " WHERE UserId= " + user.UserId.ToString();
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to update User");            
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody]UserToAddDTO user)
        {
            string sql = "INSERT INTO [EmployeeInfo_YK].[TutorialAppSchema].[Users]([FirstName],[LastName],[Email],[Gender],[Active]) " +
                          " VALUES('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.Gender + "','" + user.Active + "')";
            Console.WriteLine(sql);

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to add User");
        }

        [HttpDelete("DeleteUser/{userid}")]
        public IActionResult DeleteUser(int userid)
        {
            string sql = "DELETE FROM [EmployeeInfo_YK].[TutorialAppSchema].[Users] WHERE UserId=" + userid.ToString();                          

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete User");
        }

        [HttpGet("GetUserSalaries")]
        public IEnumerable<UserSalary> GetUserSalaries()
        {
            string sql = @"SELECT [UserId],[Salary]
                          FROM [EmployeeInfo_YK].[TutorialAppSchema].[UserSalary]";
            IEnumerable<UserSalary> userSalaries = _dapper.LoadData<UserSalary>(sql);
            return userSalaries;
        }

        [HttpGet("GetUserSalary/{userid}")]
        public UserSalary GetUserSalary(int userid)
        {
            string sql = @"SELECT [UserId],[Salary] FROM [EmployeeInfo_YK].[TutorialAppSchema].[UserSalary]
                            WHERE UserId=" + userid;
            UserSalary userSalary = _dapper.LoadDataSingle<UserSalary>(sql);

            return userSalary;
        }

        [HttpPut("EditUserSalary")]
        public IActionResult EditUserSalary([FromBody]UserSalary userSalary)
        {
            string sql = @"UPDATE [EmployeeInfo_YK].[TutorialAppSchema].[UserSalary] SET [Salary]=" + userSalary.Salary + "  WHERE UserId=" + userSalary.UserId;
                                    
            if (_dapper.ExecuteSql(sql))
            {
                return Ok(userSalary);
            }
            throw new Exception("Failed to update User Salary");
        }

        [HttpPost("AddUserSalary")]
        public IActionResult AddUserSalary([FromBody] UserSalary userSalary)
        {
            string sql = "INSERT INTO [EmployeeInfo_YK].[TutorialAppSchema].[UserSalary]([UserId],[Salary]) " +
                          " VALUES(" + userSalary.UserId + "," + userSalary.Salary + ")";

            if (_dapper.ExecuteSql(sql))
            {
                return Ok(userSalary);
            }
            throw new Exception("Failed to add User Salary");
        }

        [HttpDelete("DeleteUserSalary/{userid}")]
        public IActionResult DeleteUserSalary(int userid)
        {
            string sql = "DELETE FROM [EmployeeInfo_YK].[TutorialAppSchema].[UserSalary] WHERE UserId=" + userid.ToString();

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete User Salary");
        }

        [HttpGet("GetUsersJobInfo")]
        public IEnumerable<UserJobInfo> GetUsersJobInfo()
        {
            string sql = @"SELECT [UserId],[JobTitle],[Department]
                          FROM [EmployeeInfo_YK].[TutorialAppSchema].[UserJobInfo]";
            IEnumerable<UserJobInfo> usersJobInfo = _dapper.LoadData<UserJobInfo>(sql);
            return usersJobInfo;
        }

        [HttpGet("GetUserJobInfo/{userid}")]
        public UserJobInfo GetUserJobInfo(int userid)
        {
            string sql = @"SELECT [UserId],[JobTitle],[Department] FROM [EmployeeInfo_YK].[TutorialAppSchema].[UserJobInfo]
                            WHERE UserId=" + userid;
            UserJobInfo userJobInfo = _dapper.LoadDataSingle<UserJobInfo>(sql);

            return userJobInfo;
        }

        [HttpPut("EditUserJobInfo")]
        public IActionResult EditUserJobInfo([FromBody] UserJobInfo userJobInfo)
        {
            string sql = @"UPDATE [EmployeeInfo_YK].[TutorialAppSchema].[UserJobInfo] SET [JobTitle]='" + userJobInfo.JobTitle + "'," +
                "[Department]='" + userJobInfo.Department + "' WHERE UserId=" + userJobInfo.UserId;
            
            if (_dapper.ExecuteSql(sql))
            {
                return Ok(userJobInfo);
            }
            throw new Exception("Failed to update User Job Info");
        }

        [HttpPost("AddUserJobInfo")]
        public IActionResult AddUserJobInfo([FromBody] UserJobInfo userJobInfo)
        {      
      
            string sql = "INSERT INTO [EmployeeInfo_YK].[TutorialAppSchema].[UserJobInfo]([UserId],[JobTitle],[Department]) " +
                          " VALUES(" + userJobInfo.UserId + ",'" + userJobInfo.JobTitle + "','" + userJobInfo.Department + "')";

            if (_dapper.ExecuteSql(sql))
            {
                return Ok(userJobInfo);
            }
            throw new Exception("Failed to add User Job Info");
        }

        [HttpDelete("DeleteUserJobInfo/{userid}")]
        public IActionResult DeleteUserJobInfo(int userid)
        {
            string sql = "DELETE FROM [EmployeeInfo_YK].[TutorialAppSchema].[UserJobInfo] WHERE UserId=" + userid.ToString();

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete User Job Info");
        }
    }
}