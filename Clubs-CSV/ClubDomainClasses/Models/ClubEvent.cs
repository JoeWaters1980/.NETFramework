using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDomainClasses.Models
{
    [Table("ClubEvent")]
    public class ClubEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        public string Venue { get; set; }
        public string Location { get; set; }
        [ForeignKey("AssociatedClub")]
        public int ClubId { get; set; }
        public virtual Club AssociatedClub { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
