using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAdmin.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string OrderNumber { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string CustomerEmail { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string DeliveryAddress { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string CustomerPhone { get; set; } = string.Empty;
        
        public decimal Subtotal { get; set; }
        
        public decimal DeliveryFee { get; set; }
        
        public decimal ServiceFee { get; set; }
        
        public decimal Total { get; set; }
        
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        
        public DateTime? EstimatedDelivery { get; set; }
        
        public int RestaurantId { get; set; }
        
        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Preparing,
        OnTheWay,
        Delivered,
        Cancelled
    }
}
