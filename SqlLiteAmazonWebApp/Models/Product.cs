using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlLiteAmazonWebApp.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        [Required]
        public float Price { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        [NotMapped]
        public IFormFile Image { get; set; } = default!;
        
        [Required]
        public int CategoryId { get; set; }
        public virtual Categorie Categorie { get; set; } = default!;

        public Product()
        {
        }
    }
}
