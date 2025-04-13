using System.ComponentModel.DataAnnotations;

namespace DALTask.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
    }
}
