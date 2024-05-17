using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [DisplayName("Sub Category")]
        public string SubCategoryName { get; set; }
        public ICollection<Item> items { get; set; }
        public ICollection<Category> categories { get; set; }
    }
}
