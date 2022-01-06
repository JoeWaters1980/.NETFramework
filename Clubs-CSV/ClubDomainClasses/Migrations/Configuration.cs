namespace ClubDomainClasses.Migrations
{
    using ClubDomainClasses.Models;
    using CsvHelper;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubDomainClasses.ClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClubDomainClasses.ClubContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Courses.AddOrUpdate(c => new { c.CourseCode, c.Year },
                Get_courses().ToArray());
            context.Students.AddOrUpdate(s => s.StudentID,
                Get_students().ToArray());
            context.SaveChanges();

            context.Clubs.AddOrUpdate(club => club.CreationDate, new Club[]{
                new Club
                {
                    ClubName = "The Chess Club",
                    CreationDate = DateTime.Parse("25/01/2020"),
                    ClubEvents = new List<ClubEvent>()
                    {
                        new ClubEvent {StartDateTime = DateTime.Parse("25/01/2020").Add(new TimeSpan(5,15,0,0,0)),
                        EndDateTime  = DateTime.Parse("25/01/2020").Add(new TimeSpan(5,10,0,0,0)),
                        Location = "Sligo", Venue="Arena"
                        },

                        new ClubEvent {StartDateTime = DateTime.Parse("25/01/2020").Add(new TimeSpan(3,10,0,0,0)),
                        EndDateTime = DateTime.Parse("25/01/2020").Add(new TimeSpan(3,12,0,0,0)),
                        },
                    }
                },

                new Club
                {
                    ClubName = "The Volleyball Club",
                    CreationDate = DateTime.Parse("01/01/2020"),
                    ClubEvents = new List<ClubEvent>()
                    {
                            new ClubEvent {StartDateTime = DateTime.Parse("01/01/2020").Add(new TimeSpan(5,15,0,0,0)),
                                    EndDateTime = DateTime.Parse("01/01/2020").Add(new TimeSpan(5,16,0,0,0)),
                                    Location = "Sligo", Venue = "Arena"
                            },

                            new ClubEvent {StartDateTime = DateTime.Parse("01/01/2020").Add(new TimeSpan(3,10,0,0,0)),
                            EndDateTime = DateTime.Parse("01/01/2020").Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Main Canteen"
                            },
                    }
                },

                new Club
                {
                    ClubName = "The Soccor club",
                    CreationDate = DateTime.Parse("07/01/2020"),
                    ClubEvents = new List<ClubEvent>()
                    {
                        new ClubEvent { StartDateTime = DateTime.Parse("07/01/2020").Add(new TimeSpan(5,15,0,0,0)),
                        EndDateTime = DateTime.Parse("07/01/2020").Add(new TimeSpan(5,16,0,0,0)),
                        Location = "Sligo", Venue = "Arena"
                        },
                        new ClubEvent {StartDateTime =DateTime.Parse("07/01/2020").Add(new TimeSpan(3,10,0,0,0)),
                        EndDateTime = DateTime.Parse("07/01/2020").Add(new TimeSpan(3,12,0,0,0)),
                        Location = "Sligo", Venue = "Main Canteen"}
                    },
                }




            });
            context.SaveChanges();
            SeedStudentMembers(context);
            context.SaveChanges();
            SeedEventAttendance(context);
            context.SaveChanges();
        }

        public static List<T> Get<T>(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                    //csvReader.Configuration.HasHeaderRecord = false;
                    return csvReader.GetRecords<T>().ToList();
                }
            }
        }

        public class CourseDTO
        {
            public string CourseCode { get; set; }
            public string Year { get; set; }
            public string Title { get; set; }
        }

        private static List<Course> Get_courses()
        {
            List<CourseDTO> cdto = Get<CourseDTO>("D:/Collage Work/3rd year repeat/RAD/301/.NetFramework/Clubs-CSV/ClubDomainClasses/Courses.csv");
            List<Course> Courses = new List<Course>();


            cdto.ForEach(rec =>
            {
                Courses.Add(
                    new Course
                    {
                        CourseCode = rec.CourseCode,
                        CourseName = rec.Title,
                        Year = rec.Year
                    });
            });
            return Courses;
        }

        public class StudentDTO
        {
            public string StudentID { get; set; }
            public string FirstName { get; set; }

            public string SecondName { get; set; }

        }

        private static List<Student> Get_students()
        {
            List<StudentDTO> sdto = Get<StudentDTO>("D:/Collage Work/3rd year repeat/RAD/301/.NetFramework/Clubs-CSV/ClubDomainClasses/StudentList1.csv");
            List<Student> students = new List<Student>();

            sdto.ForEach(rec =>
            {
                students.Add(
                    new Student
                    {
                        StudentID = rec.StudentID,
                        FirstName = rec.FirstName,
                        SecondName = rec.SecondName
                    });
            });
            return students;

        }

        public void SeedStudentMembers(ClubContext ctx)
        {
            List<Club> clubs = ctx.Clubs.ToList();

            foreach (var club in clubs)
            {
                List<Student> selectedStudents = new List<Student>();
                var randomStudentSet = ctx.Students
                    .Select(s => new { s.StudentID, r = Guid.NewGuid() });

                List<string> subset = randomStudentSet
                    .OrderBy(s => s.r)
                    .Select(s => s.StudentID)
                    .Take(2).ToList();

                foreach (string s in subset)
                {
                    selectedStudents.Add(
                        ctx.Students.First(st => st.StudentID == s)
                        );
                }

                foreach (Student s in selectedStudents)
                {
                    ctx.Members.AddOrUpdate(m => m.StudentID,
                        new Member
                        {
                            AssociatedClub = club.ClubId,
                            StudentID = s.StudentID

                        });

                }
                ctx.SaveChanges();


            }
        }

        private void SeedEventAttendance(ClubContext context)
        {
            List<Club> clubs = context.Clubs.ToList();

            foreach (Club club in clubs)
                foreach (ClubEvent ev in club.ClubEvents)
                    foreach (Member m in club.ClubMembers)
                        context.EventAttendances.AddOrUpdate(a => new { a.EventID, a.AttendeeMember },
                            new EventAttendance
                            {
                                EventID = ev.EventID,
                                AttendeeMember = m.MemberID
                            });
            context.SaveChanges();
        }
    }
}

