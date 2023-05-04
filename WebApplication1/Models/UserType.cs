using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserType
    {
        public UserType()
        {
            Users = new List<User?>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User?> Users { get; set; }
    }
}
