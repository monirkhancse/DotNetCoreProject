using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string ProductCode { get; set; }   
        
        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Manufacturer Country")]
        public string ManufacturerCountry { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PackSize { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AlartQuantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiscountRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Stock { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal WholeSalePrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }

}
