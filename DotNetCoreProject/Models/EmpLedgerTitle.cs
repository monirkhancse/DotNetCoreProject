using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject.Models
{
    public class EmpLedgerTitle
    {
        [Key]
        public int EmpLedgerTitleId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public ICollection<EmployeeLedger> employeeLedgers { get; set; }
    }
}
