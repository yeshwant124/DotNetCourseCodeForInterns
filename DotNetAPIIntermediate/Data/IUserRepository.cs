using DotNetAPIIntermediate.Models;

namespace DotNetAPIIntermediate.Data
{
    public interface IUserRepository
    {
        public bool SaveChanges();

        public void AddEntity<T>(T entityToAdd);

        public void RemoveEntity<T>(T entityToRemove);

        public IEnumerable<User> GetAllUsers();

        public User GetUser(int userid);

        public IEnumerable<UserSalary> GetUserSalaries();

        public UserSalary GetUserSalary(int userid);

        public IEnumerable<UserJobInfo> GetUsersJobInfo();

        public UserJobInfo GetUserJobInfo(int userid);
    }
}
