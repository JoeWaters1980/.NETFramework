using ClassLibrary1.Club_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ClubContext: DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<EventAttendnace> EventAttendances { get; set; }
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
