using DALTask.Models;

namespace DALTask.Services
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUserList();

        public User GetUserById(int id);
        public User CreateUser(User user);
        public User UpdateUser(User user);
        public bool DeleteUser(int Id);
    }
}
