using DALTask.Data;
using DALTask.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using DALTask.Models;

namespace DALTaskTest
{
    public class OrderRepositoryTest
    {
        private readonly OrderRepository _orderRepository;
        private readonly AppDbContext _context;


        public OrderRepositoryTest()
        {
            // Set up in-memory database 
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
             .Options;
            // Initialize database
            _context = new AppDbContext(options);
            _orderRepository = new OrderRepository(_context);
        }

        //Crud Opreation Test

        [Fact]
        public void CreateOrder_ShouldAddOrder()
        {
            // Arrange
            var order = new Order { Id = 1, UserId = 1, Product = "Test Product", Quantity = 2 , Price = 1};
            // Act
             _orderRepository.CreateOrder(order);
            // Assert
            var result =  _context.Orders.Find(1);
            Assert.NotNull(result);
            Assert.Equal(order.Product, result.Product);
        }

        [Fact]
        public void GetOrderById_ShouldReturnOrder()
        {
            // Arrange
            var order = new Order { Id = 1, UserId = 1, Product = "Test Product", Quantity = 2, Price = 1 };
            _orderRepository.CreateOrder(order);
            // Act
            var result = _orderRepository.GetOrderById(1);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.Product, result.Product);
        }
        [Fact]
        public void GetOrderList_ShouldReturnAllOrders()
        {
            // Arrange
            var order1 = new Order { Id = 1, UserId = 1, Product = "Test Product", Quantity = 2, Price = 1 };
            var order2 = new Order { Id = 2, UserId = 2, Product = "Test Product 2", Quantity = 3, Price = 2 };
            _orderRepository.CreateOrder(order1);
            _orderRepository.CreateOrder(order2);
            // Act
            var result = _orderRepository.GetOrderList();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void UpdateOrder_ShouldUpdateOrder()
        {
            // Arrange
            var order = new Order { Id = 1, UserId = 1, Product = "Test Product", Quantity = 2, Price = 1 };
            _orderRepository.CreateOrder(order);
            order.Product = "Updated Product";
            // Act
            var result = _orderRepository.UpdateOrder(order);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Product", result.Product);
        }

        [Fact]
        public void DeleteOrder_ShouldRemoveOrder()
        {
            // Arrange
            var order = new Order { Id = 1, UserId = 1, Product = "Test Product", Quantity = 2, Price = 1 };
            _orderRepository.CreateOrder(order);
            // Act
            var result = _orderRepository.DeleteOrder(1);
            // Assert
            Assert.True(result);
            Assert.Null(_orderRepository.GetOrderById(1));
        }

        [Fact]
        public void GetOrdersByUserIdAsync_ReturnsCorrectOrders()
        {
            // Arrange
            _context.Orders.AddRange(
                new Order { Id = 1, UserId = 1, Product = "Item A" },
                new Order { Id = 2, UserId = 1, Product = "Item B" },
                new Order { Id = 3, UserId = 2, Product = "Item C" }
            );
            _context.SaveChanges();

            // Act
            var result = _orderRepository.GetOrdersByUserIdAsync(1).ToList();
            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, order => Assert.Equal(1, order.UserId));


        }




    }
}
