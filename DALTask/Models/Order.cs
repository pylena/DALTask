using System.ComponentModel.DataAnnotations;

namespace DALTask.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
