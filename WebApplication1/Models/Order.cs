using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public enum OrderStatus
    {
        Delivered ,Pending , Delivering
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
         //public DateTime DateTime { get; set; }
         public int Quantity { get; set; }
         //public int Price { get; set; }
        public string Description { get; set; }

        //[ForeignKey(nameof(Restaurant))]
        //public int RestaurantID { get; set; }
        //public virtual Restaurant? Restaurant { get; set; }

     


        //public OrderStatus OrderStatus { get; set; }
        //[ForeignKey(nameof(User))]
        //public int UserId { get; set; }
        //public virtual User? User { get; set; }






        //public List<OrderDetails> OrderDetails { get; set; }
        //public List<FoodServed> OrderDetails { get; set; }


        //public Restaurant Restaurant { get; set; }
        //public Customer Customer { get; set; }


    }
}
