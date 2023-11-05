using Academic_Planner.Models;
using Academic_Planner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Academic_Planner.View_Models
{
    public class ClassViewModel : ViewModel
    {
        public TermViewModel TermViewModel { get; set; }
        public Class Class { get; set; }
        private ObservableCollection<Note> _notes = new ObservableCollection<Note>();
        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set
            {
                if (value != _notes)
                {
                    _notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }
        private ObservableCollection<Assessment> _assessments = new ObservableCollection<Assessment>();
        public ObservableCollection<Assessment> Assessments
        {
            get => _assessments;
            set
            {
                if (value != _assessments)
                {
                    _assessments = value;
                    OnPropertyChanged("Assessments");
                }
            }
        }
        public ClassViewModel()
        {
            Task.Run(async () =>
            {
                var notes = (List<Note>)await DBService.GetNotes();
                Notes = new ObservableCollection<Note>(notes.Where(n => n.ClassId == Class.Id));

                var assessments = (List<Assessment>)await DBService.GetAssessments();
                Assessments = new ObservableCollection<Assessment>(assessments.Where(a => a.ClassId == Class.Id));

            });
            Task.WaitAll();
        }
        public async Task Add<T>(T obj)
        {
            await DBService.Add(obj);
            await Refresh();
        }
        public async Task Remove<T>(int id)
        {
            await DBService.Remove<T>(id);
            await Refresh();
        }

        public async Task Update<T>(T obj)
        {
            await DBService.Update(obj);
            await Refresh();
        }

        public async Task Refresh()
        {
            var notes = (List<Note>)await DBService.GetNotes();
            Notes = new ObservableCollection<Note>(notes.Where(n => n.ClassId == Class.Id));

            var assessments = (List<Assessment>)await DBService.GetAssessments();
            Assessments = new ObservableCollection<Assessment>(assessments.Where(a => a.ClassId == Class.Id));
            await Task.Delay(250);
        }
        public async Task<Instructor> GetInstructor(int id)
        {
            return await DBService.GetInstructor(id);
        }
        public async Task<Instructor> GetInstructor(string name)
        {
            return await DBService.GetInstructor(name);
        }
    }
}
