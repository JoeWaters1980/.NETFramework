namespace ClassLibrary1.Migrations
{
    using ClassLibrary1.Club_Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibrary1.ClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClassLibrary1.ClubContext context)
        {
            //Seed the Database with 3 Clubs, 2 members and 2 events foreach club.
            //Two clubs should have one same member.The club Members should have attended the events.
            context.Clubs.AddOrUpdate(new Club[]
           {
                new Club
                {
                   ClubName = "Guitar Club",
                   CreationDate = DateTime.Parse("25/01/2020"),
                   ClubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000001",
                            Approved = true
                        },
                        new Member
                        {
                            StudentID = "S00000002",
                            Approved = true
                        }
                   },
                   ClubEvents = new List<ClubEvent>()
                   {
                        new ClubEvent
                        {   StartDateTime = DateTime.Parse("05/02/2020").Add(new TimeSpan(5,15,0,0,0)),
                            EndDateTime =  DateTime.Parse("05/02/2020").Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Sligo",
                            Venue="Arena"
                        },
                        new ClubEvent
                        {   StartDateTime = DateTime.Parse("10/02/2020").Add(new TimeSpan(3,10,0,0,0)),
                            EndDateTime =  DateTime.Parse("10/02/2020").Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo",
                            Venue="Main Canteen"
                        }
                   }
                },
                new Club
                {
                   ClubName = "GAA Club",
                   CreationDate = DateTime.Parse("03/04/2020"),
                   ClubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000003",
                            Approved = true
                        },
                        new Member
                        {
                            StudentID = "S00000004",
                            Approved = true
                        }
                   },
                   ClubEvents = new List<ClubEvent>()
                   {
                        new ClubEvent
                        {   StartDateTime = DateTime.Parse("15/05/2020").Add(new TimeSpan(5,17,0,0,0)),
                            EndDateTime =  DateTime.Parse("15/05/2020").Add(new TimeSpan(5,18,0,0,0)),
                            Location = "mayo",
                            Venue="GAA club"
                        },
                        new ClubEvent
                        {   StartDateTime = DateTime.Parse("10/05/2020").Add(new TimeSpan(3,19,0,0,0)),
                            EndDateTime =  DateTime.Parse("10/05/2020").Add(new TimeSpan(3,21,0,0,0)),
                            Location = "mayo",
                            Venue="Gym"
                        }
                   }
                },
                new Club
                {
                   ClubName = "Football Club",
                   CreationDate = DateTime.Parse("06/02/2020"),
                   ClubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000004",
                            Approved = true
                        },
                        new Member
                        {
                            StudentID = "S00000005",
                            Approved = true
                        }
                   },
                   ClubEvents = new List<ClubEvent>()
                   {
                        new ClubEvent
                        {   StartDateTime = DateTime.Parse("20/02/2020").Add(new TimeSpan(5,10,0,0,0)),
                            EndDateTime =  DateTime.Parse("20/02/2020").Add(new TimeSpan(5,13,0,0,0)),
                            Location = "Mayo",
                            Venue="Football pitch"
                        },
                        new ClubEvent
                        {   StartDateTime = DateTime.Parse("01/03/2020").Add(new TimeSpan(3,10,0,0,0)),
                            EndDateTime =  DateTime.Parse("01/02/2020").Add(new TimeSpan(3,13,0,0,0)),
                            Location = "Sligo",
                            Venue="Away game"
                        }
                   }
                },
           });
            // this method will  iterate over the clubs and create events with its members attendances
            SeedEventAttendance(context);
            context.SaveChanges();
        }

        private void SeedEventAttendance(ClubContext context)
        {
            List<Club> clubs = context.Clubs.ToList();

            foreach (Club club in clubs)
                foreach (ClubEvent ev in club.ClubEvents)
                    foreach (Member m in club.ClubMembers)
                        context.EventAttendances.AddOrUpdate(a => new { a.EventID, a.AttendeeMember },
                            new EventAttendnace
                            {
                                EventID = ev.EventID,
                                AttendeeMember = m.MemberID
                            });
            context.SaveChanges();
        }
    }
}
