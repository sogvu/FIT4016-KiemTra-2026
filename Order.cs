using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementApp
{
    [Table("orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required, StringLength(50)]
        public string OrderNumber { get; set; } // Format: ORD-YYYYMMDD-XXXX

        [Required, StringLength(100, MinimumLength = 2)]
        public string CustomerName { get; set; }

        public int Quantity { get; set; }

        [Required, EmailAddress]
        public string CustomerEmail { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Helper property for Status display
        [NotMapped]
        public string Status => DeliveryDate.HasValue ? "Delivered" : "Pending";
    }
}