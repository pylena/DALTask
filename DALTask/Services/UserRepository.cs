using DALTask.Data;
using DALTask.Models;

namespace DALTask.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IEnumerable<User> GetUserList()
        {
            return _dbContext.Users.ToList(); // Get all users
        }
        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id); // Get user by ID
        }
        public User CreateUser(User user)
        {
            _dbContext.Users.Add(user); // Add new user
            _dbContext.SaveChanges();
            return user;
        }
        public User UpdateUser(User user)
        {
            _dbContext.Users.Update(user); // Update existing user
            _dbContext.SaveChanges();
            return user;
        }

        public bool DeleteUser(int Id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == Id);
            if (user != null)
            {
                _dbContext.Users.Remove(user); // Remove user
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
