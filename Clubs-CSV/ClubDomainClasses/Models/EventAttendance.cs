using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDomainClasses.Models
{
    [Table("EventAttendance")]
    public class EventAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("AssociatedEvent")]
        public int EventID { get; set; }
        [ForeignKey("MemberAttending")]
        // Set Nullable to avoid cascading deletes
        // which would lead to indirect circular deletes
        public int? AttendeeMember { get; set; }
        public virtual Member MemberAttending { get; set; }
        public virtual ClubEvent AssociatedEvent { get; set; }
    }
}
