using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDomainClasses.Models
{
    [Table("Member")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        public int AssociatedClub { get; set; }
        public string StudentID { get; set; }
        public bool Approved { get; set; }
        [ForeignKey("AssociatedClub")]
        public virtual Club MyClub { get; set; }
    }
}
