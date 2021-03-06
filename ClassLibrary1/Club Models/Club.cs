using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Club_Models
{
    [Table("Club")]
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
        public int AdminID { get; set; }
        public virtual ICollection<Member> ClubMembers { get; set; }
        public virtual ICollection<ClubEvent> ClubEvents { get; set; }
    }
}
