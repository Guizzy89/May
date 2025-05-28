using System.Collections.Generic;

namespace WebApplication1.DataAccessLayer.Models
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}