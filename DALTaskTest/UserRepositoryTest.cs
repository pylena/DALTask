using DALTask.Data;
using DALTask.Models;
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
        public async void GetUserList_shouldReurnUserList()
        {
            // Arrange
            // Arrange
            _context.Users.Add(new User { Id = 1, FName = "Lina" , LName ="Alsehli", Email = "lina@com"});
            _context.Users.Add(new User { Id = 2, FName = "hamed" , LName="al", Email = "h@com"});
            await _context.SaveChangesAsync();

            // Act
            var result =  _userRepository.GetUserList();
            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {
            // Arrange
            _context.Users.Add(new User { Id = 1, FName = "LINA", LName="AL", Email="Lina@com" });
            await _context.SaveChangesAsync();

            // Act
            var result =  _userRepository.GetUserById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("LINA", result.FName);
        }
        [Fact]
        public async Task AddUserAsync_ShouldAddUser()
        {
            // Arrange
            var user = new User { Id = 3, FName = "shahad", LName="al" , Email="f@com"};

            // Act
             _userRepository.CreateUser(user);

            // Assert
            var result = await _context.Users.FindAsync(3);
            Assert.NotNull(result);
            Assert.Equal("shahad", result.FName);
        }



    }
}
