using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }      
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        public ICollection<EmployeeLedger> employeeLedgers { get; set; }
    }
}
