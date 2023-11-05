using Academic_Planner.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Academic_Planner.Services
{
    public static class DBService
    {
        private static SQLiteAsyncConnection db;
        private static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "AcademicPlanner.db");
            db = new SQLiteAsyncConnection(databasePath, false);

            /*await db.DropTableAsync<Term>();
            await db.DropTableAsync<Class>();
            await db.DropTableAsync<Instructor>();
            await db.DropTableAsync<Note>();
            await db.DropTableAsync<Assessment>();*/

            await db.CreateTableAsync<Term>();
            await db.CreateTableAsync<Class>();
            await db.CreateTableAsync<Instructor>();
            await db.CreateTableAsync<Note>();
            await db.CreateTableAsync<Assessment>();

            IEnumerable<Term> getTerms = await GetTerms();
            if (!getTerms.Any())
            {
                await Add(new Term { Title = "Term 1", Start = new DateTime(2022, 7, 1), End = new DateTime(2022, 12, 31) });

                await Add(new Instructor { Name = "Will Scott", Email = "wscot83@wgu.edu", Phone = "916-305-5928" });
                IEnumerable<Instructor> instructors = await GetInstructors();
                Instructor instructor = instructors.First();

                await Add(new Class
                {
                    Title = "Class 1",
                    TermId = 1,
                    InstructorId = instructor.Id,
                    Start = new DateTime(2022, 7, 1),
                    End = new DateTime(2022, 12, 31),
                    Status = "In-Progess",
                    NotifyStart = true,
                    NotifyEnd = false
                });
                /*await Add(new Term { Title = "Term 1", Start = new DateTime(2022, 1, 1), End = new DateTime(2022, 6, 30) });
                await Add(new Term { Title = "Term 2", Start = new DateTime(2022, 7, 1), End = new DateTime(2022, 12, 31) });
                await Add(new Term { Title = "Term 3", Start = new DateTime(2023, 1, 1), End = new DateTime(2023, 6, 30) });
                await Add(new Term { Title = "Term 4", Start = new DateTime(2023, 7, 1), End = new DateTime(2023, 12, 31) });

                

                await Add(new Instructor { Name = "Instructor", Email = "instructor@wgu.edu", Phone = "385-867-5309" });
                IEnumerable<Instructor> instructors = await GetInstructors();
                Instructor instructor = instructors.First();

                getTerms = await GetTerms();
                DateTime start;
                DateTime end;
                string status;
                foreach (Term term in getTerms)
                {
                    switch (term.Id)
                    {
                        case 1:
                            start = new DateTime(2022, 1, 1);
                            end = new DateTime(2022, 6, 30);
                            status = "Completed";
                            break;
                        case 2:
                            start = new DateTime(2022, 7, 1);
                            end = new DateTime(2022, 12, 31);
                            status = "In-Progress";
                            break;
                        case 3:
                            start = new DateTime(2023, 1, 1);
                            end = new DateTime(2023, 6, 30);
                            status = "Not Started";
                            break;
                        case 4:
                            start = new DateTime(2023, 7, 1);
                            end = new DateTime(2023, 12, 31);
                            status = "Not Started";
                            break;

                        default:
                            return;
                    }
                    await Add(new Class
                    {
                        Title = "Class " + Convert.ToString((6 * (term.Id - 1)) + 1),
                        TermId = term.Id,
                        InstructorId = instructor.Id,
                        Start = start,
                        End = end,
                        Status = status
                    });
                    await Add(new Class
                    {
                        Title = "Class " + Convert.ToString((6 * (term.Id - 1)) + 2),
                        TermId = term.Id,
                        InstructorId = instructor.Id,
                        Start = start,
                        End = end,
                        Status = status
                    });
                    await Add(new Class
                    {
                        Title = "Class " + Convert.ToString((6 * (term.Id - 1)) + 3),
                        TermId = term.Id,
                        InstructorId = instructor.Id,
                        Start = start,
                        End = end,
                        Status = status
                    });
                    await Add(new Class
                    {
                        Title = "Class " + Convert.ToString((6 * (term.Id - 1)) + 4),
                        TermId = term.Id,
                        InstructorId = instructor.Id,
                        Start = start,
                        End = end,
                        Status = status
                    });
                    await Add(new Class
                    {
                        Title = "Class " + Convert.ToString((6 * (term.Id - 1)) + 5),
                        TermId = term.Id,
                        InstructorId = instructor.Id,
                        Start = start,
                        End = end,
                        Status = status
                    });
                    await Add(new Class
                    {
                        Title = "Class " + Convert.ToString((6 * (term.Id - 1)) + 6),
                        TermId = term.Id,
                        InstructorId = instructor.Id,
                        Start = start,
                        End = end,
                        Status = status
                    });
                }
            } */
                foreach (Class aClass in await GetClasses())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        await Add(new Note
                        {
                            ClassId = aClass.Id,
                            Title = "Note",
                            Message = "This is a note is a note that's a note. What's a note? Why this note is a note which makes it a note, yes a note. A note? A note.",
                            Created = DateTime.Now
                        });
                    }
                }
                foreach (Class aClass in await GetClasses())
                {
                    await Add(new Assessment
                    {
                        ClassId = aClass.Id,
                        Title = "Test 1",
                        Type = "Objective",
                        Start = DateTime.Now,
                        End = aClass.End,
                        NotifyStart = true,
                        NotifyEnd = false
                    });
                    await Add(new Assessment
                    {
                        ClassId = aClass.Id,
                        Title = "Task 1",
                        Type = "Performance",
                        Start = aClass.Start,
                        End = aClass.End,
                        NotifyStart = true,
                        NotifyEnd = false
                    });
                }
            }
        }

        public static async Task<Dictionary<Class, string>> GetClassNotifications()
        {
            var classes = (List<Class>)await GetClasses();
            var notifClasses = new Dictionary<Class, string>();
            foreach (Class aClass in classes)
            {
                if (aClass.NotifyStart && aClass.NotifyEnd)
                {
                    if (aClass.Start.Date == DateTime.Today && aClass.End.Date == DateTime.Today)
                    {
                        notifClasses.Add(aClass, "Both");
                    }
                    else if (aClass.Start.Date == DateTime.Today)
                    {
                        notifClasses.Add(aClass, "Start");
                    }
                    else
                    {
                        notifClasses.Add(aClass, "End");
                    }

                }
                else if (aClass.NotifyStart)
                {
                    if (aClass.Start.Date == DateTime.Today)
                    {
                        notifClasses.Add(aClass, "Start");
                    }
                }
                else if (aClass.NotifyEnd)
                {
                    if (aClass.End.Date == DateTime.Today)
                    {
                        notifClasses.Add(aClass, "End");
                    }
                }
            }
            return notifClasses;
        }
        public static async Task<Dictionary<Assessment, string>> GetAssessmentNotifications()
        {
            var assessments = (List<Assessment>)await GetAssessments();
            var notifAssessments = new Dictionary<Assessment, string>();
            foreach (Assessment assessment in assessments)
            {
                if (assessment.NotifyStart && assessment.NotifyEnd)
                {
                    if (assessment.Start.Date == DateTime.Today && assessment.End.Date == DateTime.Today)
                    {
                        notifAssessments.Add(assessment, "Both");
                    }
                    else if (assessment.Start.Date == DateTime.Today)
                    {
                        notifAssessments.Add(assessment, "Start");
                    }
                    else
                    {
                        notifAssessments.Add(assessment, "End");
                    }
                        
                }
                else if (assessment.NotifyStart)
                {
                    if (assessment.Start.Date == DateTime.Today)
                    {
                        notifAssessments.Add(assessment, "Start");
                    }
                }
                else if (assessment.NotifyEnd)
                {
                    if (assessment.End.Date == DateTime.Today)
                    {
                        notifAssessments.Add(assessment, "End");
                    }
                }
            }
            return notifAssessments;
        }
        public static async Task<Instructor> GetInstructor(int id)
        {
            await Init();
            return await db.FindAsync<Instructor>(id);
        }
        public static async Task<Instructor> GetInstructor(string name)
        {
            await Init();
            return await db.Table<Instructor>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public static async Task Add<T>(T obj)
        {
            await Init();
            await db.InsertAsync(obj);
        }
        public static async Task Remove<T>(int id)
        {
            await Init();
            await db.DeleteAsync<T>(id);
        }
        public static async Task Update<T>(T obj)
        {
            await Init();
            await db.UpdateAsync(obj);
        }
        public static async Task<IEnumerable<Term>> GetTerms()
        {
            await Init();
            List<Term> terms = await db.Table<Term>().OrderBy(t => t.Start).ToListAsync();
            return terms;
        }
        public static async Task<IEnumerable<Class>> GetClasses()
        {
            await Init();
            List<Class> classes = await db.Table<Class>().OrderBy(c => c.Start).ToListAsync();
            return classes;
        }
        public static async Task<IEnumerable<Instructor>> GetInstructors()
        {
            await Init();
            List<Instructor> instructors = await db.Table<Instructor>().OrderBy(i => i.Name).ToListAsync();
            return instructors;
        }
        public static async Task<IEnumerable<Note>> GetNotes()
        {
            await Init();
            List<Note> notes = await db.Table<Note>().OrderBy(n => n.ClassId).ToListAsync();
            return notes;
        }
        public static async Task<IEnumerable<Assessment>> GetAssessments()
        {
            await Init();
            List<Assessment> assessments = await db.Table<Assessment>().OrderBy(a => a.ClassId).ToListAsync();
            return assessments;
        }
        public static async Task<float> GetProgress()
        {
            await Task.Delay(1000);
            var classes = (List<Class>)await GetClasses();
            float count = 0;
            foreach (Class aClass in classes)
            {
                if (aClass.Status == "Completed")
                {
                    count++;
                }
            }
            float result = count / classes.Count;
            return result;
        }
        public static async Task<Class> GetClass(int id)
        {
            return await db.FindAsync<Class>(id);
        }
    }
}
