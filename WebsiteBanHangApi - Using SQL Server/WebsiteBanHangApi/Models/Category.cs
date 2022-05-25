using System;
using System.Collections.Generic;

#nullable disable

namespace WebsiteBanHangApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Slug { get; set; }
        public bool? ShowOnHomePage { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
