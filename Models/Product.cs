using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgloobalTestBackendCSharp.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }
    }
}