using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public string CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public string LastUpdate { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Upload Picture")]
        public IFormFile Image { get; set; }

    }
}
