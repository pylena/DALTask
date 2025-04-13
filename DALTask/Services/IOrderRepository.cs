using DALTask.Models;

namespace DALTask.Services
{
    public interface IOrderRepository
    {

        public IEnumerable<Order> GetOrderList();
        public IEnumerable<Order> GetOrdersByUserIdAsync(int userId);
        public Order GetOrderById(int id);
        public Order CreateOrder(Order order);
        public Order UpdateOrder(Order order);
        public bool DeleteOrder(int Id);
    }
}
