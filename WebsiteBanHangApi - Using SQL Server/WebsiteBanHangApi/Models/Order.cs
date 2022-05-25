using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanHangApi.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedOnUtc { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
