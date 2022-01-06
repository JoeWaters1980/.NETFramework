using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution_Banking_.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcccountID { get; set; }
        public string AccountName { get; set; }
        [DataType(DataType.Date)]
        public DataType InceptionDate { get; set; }
        [ForeignKey("Customer")]
        public virtual int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [DataType(DataType.Currency)]
        public decimal CurrentBalance { get; set; }
        public int AccountTypeID { get; set; }
    }
}
