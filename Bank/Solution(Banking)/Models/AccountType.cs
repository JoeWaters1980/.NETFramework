using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution_Banking_.Models
{
    [Table("Account Type")]
    public class AccountType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string TypeName { get; set; }
        [Display(Name = "Conditions")]
        public string Conditions { get; set; }

    }
}
