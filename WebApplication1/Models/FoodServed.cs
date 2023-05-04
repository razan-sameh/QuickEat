using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FoodServed
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category? Category { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }

        public virtual Restaurant? Restaurant { get; set; }

    
        //[ForeignKey("Order")]
        //public int OrderID { get; set; }

        //public virtual Order Order { get; set; }


        //public FoodServed(int id, string name, Category category)
        //{
        //    Id = id;
        //    Name = name;
        //    Category = category;
        //}
    }
}
