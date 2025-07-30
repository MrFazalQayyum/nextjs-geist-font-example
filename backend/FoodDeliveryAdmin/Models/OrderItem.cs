using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAdmin.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int MenuItemId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string MenuItemName { get; set; } = string.Empty;
        
        public decimal MenuItemPrice { get; set; }
        
        [Range(1, 100)]
        public int Quantity { get; set; }
        
        public decimal Subtotal { get; set; }
        
        public virtual Order Order { get; set; } = null!;
        public virtual MenuItem MenuItem { get; set; } = null!;
    }
}
