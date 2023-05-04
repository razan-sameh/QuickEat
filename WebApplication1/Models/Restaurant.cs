using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            FoodServeds = new List<FoodServed>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int MobileNumber { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FoodServed?> FoodServeds { get; set; }







        //public Restaurant(int id, string name, string address, string email, int mobileNumber, string description , List<FoodServed> foodServed, List<Customer>? customers =null,List<Order>? orders = null )
        //{
        //    Id = id;
        //    Name = name;
        //    Address = address;
        //    Email = email;
        //    MobileNumber = mobileNumber;
        //    Description = description;
        //    FoodServed = foodServed;
        //    Customers = customers;
        //    Orders = orders;

        //}
    }
    
}
