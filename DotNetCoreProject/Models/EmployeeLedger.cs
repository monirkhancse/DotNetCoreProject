using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject.Models
{
    public class EmployeeLedger
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int? EmpLedgerTitleId { get; set; }
        public virtual EmpLedgerTitle EmpLedgerTitle { get; set; }
        public int? EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        //[Required]
        //[Column(TypeName = "nvarchar(50)")]
        //[DisplayName("Select Title")]
        //public int LedgerTitleID { get; set; }     
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Debit { get; set; }
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Credit { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PreviousDue { get; set; }
        public bool PayAmount { get; set; }
        public bool Received { get; set; }
        public string Remarks { get; set; }

    }
}
