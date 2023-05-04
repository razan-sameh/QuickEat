using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    //public enum UserType
    //{
    //    Customer, SystemAdmin , RestaurantAdmin
    //}
    public  class User
    {
        public User()
        {
            Orders = new List<Order?>();
        }

        [Key]
 
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
      
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int MobileNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }
        [ForeignKey(nameof(UserType))]
        public int UserTypeId { get; set; }
        public virtual UserType? UserType { get; set; }
        public virtual ICollection<Order?> Orders { get; set; }
        //[Required]
        //public UserType UserType { get; set; }
    }
}
