using DALTask.Data;
using DALTask.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTaskTest
{
    public class UserRepositoryTest
    {

        private readonly UserRepository _userRepository;
        private readonly AppDbContext _context;

        public UserRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDb")
           .Options;

            _context = new AppDbContext(options);
            _userRepository = new UserRepository(_context);
        }

        //Crud Opreation Test
        [Fact]
        public void GetUserList_s



    }
}
