using System.ComponentModel.DataAnnotations.Schema;

namespace SqlLiteAmazonWebApp.Models
{
    [Table("Categories")]
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public Categorie()
        {
        }
    }
}
