using ClubDomainClasses.Models;
using System.Data.Entity;

namespace ClubDomainClasses
{
    public class ClubContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<EventAttendance> EventAttendances { get; set; }
        public ClubContext()
            : base("DefaultConnection")
        {
        }
        public static ClubContext Create()
        {
            return new ClubContext();
        }
    }
}
