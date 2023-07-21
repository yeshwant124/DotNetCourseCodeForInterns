using AutoMapper;
using DotNetAPIIntermediate.DTO;
using DotNetAPIIntermediate.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAPIIntermediate.Data
{
    public class UserRepository: IUserRepository
    {
        private DataContextEF _entityFramework;        

        public UserRepository(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);

            IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserToAddDTO, User>()));
        }

        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }

        public void AddEntity<T>(T entityToAdd)        
        {
            if(entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);                
            }            
        }

        public void RemoveEntity<T>(T entityToRemove)
        {
            if (entityToRemove != null)
            {
                _entityFramework.Remove(entityToRemove);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users = _entityFramework.Users.ToList();
            return users;
        }

        public User GetUser(int userid)
        {
            User? user = _entityFramework.Users.Where(u => u.UserId == userid).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            throw new Exception("User not found");
        }

        public IEnumerable<UserSalary> GetUserSalaries()
        {
            IEnumerable<UserSalary> userSalaries = _entityFramework.UserSalary.ToList().OrderByDescending(u => u.UserId);
            return userSalaries;
        }

        public UserSalary GetUserSalary(int userid)
        {
            UserSalary? userSalary = _entityFramework.UserSalary.Where(u => u.UserId == userid).FirstOrDefault();
            if (userSalary != null)
            {
                return userSalary;
            }
            throw new Exception("User Salary not found");
        }

        public IEnumerable<UserJobInfo> GetUsersJobInfo()
        {
            IEnumerable<UserJobInfo> usersJobInfo = _entityFramework.UserJobInfo.ToList().OrderByDescending(u => u.UserId);
            return usersJobInfo;
        }

        public UserJobInfo GetUserJobInfo(int userid)
        {
            UserJobInfo? userJobInfo = _entityFramework.UserJobInfo.Where(u => u.UserId == userid).FirstOrDefault();
            if (userJobInfo != null)
            {
                return userJobInfo;
            }
            throw new Exception("User Job Info not found");
        }

    }
}
