using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        public ICollection<Item> items { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
