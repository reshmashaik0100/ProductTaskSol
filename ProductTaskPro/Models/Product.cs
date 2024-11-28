using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductTaskPro.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProcuctName { get; set; }
        public float ProductPrice { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
