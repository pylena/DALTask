using DALTask.Data;
using DALTask.Models;

namespace DALTask.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IEnumerable<Order> GetOrderList()
        {
            return _dbContext.Orders.ToList(); // Get all orders
        }

        public IEnumerable<Order> GetOrdersByUserIdAsync(int userId)
        {
            return _dbContext.Orders.Where(o => o.UserId == userId).ToList(); // Get orders by user ID
        }
        public Order GetOrderById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.Id == id); // Get order by ID
        }
        public Order CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order); // Add new order
            _dbContext.SaveChanges();
            return order;
        }
        public Order UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order); // Update existing order
            _dbContext.SaveChanges();
            return order;
        }
        public bool DeleteOrder(int Id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == Id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order); // Remove order
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
