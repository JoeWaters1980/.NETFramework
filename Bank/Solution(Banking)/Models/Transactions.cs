using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution_Banking_.Models
{
    [Table("Transactions")]
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public TransactionType TransactionType { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DataType TransactionDate { get; set; }
        [ForeignKey("Account")]
        public virtual int AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
    public enum TransactionType
    {
        Lodgement, 
        Withdrawl
    }
}
