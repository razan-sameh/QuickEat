using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }


        [ForeignKey(nameof(FoodServed))]
        public int FoodServiedId { get; set; }
        public virtual FoodServed? FoodServed { get; set; }
      


    }
}
