using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        [HiddenInput]
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public List<FoodServed> FoodServeds { get; set; }
    }
}
