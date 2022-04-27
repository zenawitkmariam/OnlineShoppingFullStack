using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCounselling.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public string Uom { get; set; }
    }
}
