using System.ComponentModel.DataAnnotations;

namespace DapperCRUDProduct.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
