using Academic_Planner.Models;
using Academic_Planner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Academic_Planner.View_Models
{
    public class TermViewModel : ViewModel
    {
        public DegreeViewModel DegreeViewModel { get; internal set; }
        public Term Term;
        private ObservableCollection<Class> _classes = new ObservableCollection<Class>();
        public ObservableCollection<Class> Classes
        {
            get => _classes;
            set
            {
                if (value != _classes)
                {
                    _classes = value;
                    OnPropertyChanged("Classes");
                }
            }
        }
        public TermViewModel()
        {
            Task.Run(async () =>
            {
                var classes = (List<Class>)await DBService.GetClasses();
                Classes = new ObservableCollection<Class>(classes.Where(c => c.TermId == Term.Id));
            });
            Task.WaitAll();
        }

        public async Task Add<T>(T obj)
        {
            await DBService.Add(obj);
            await Refresh();
        }

        public async Task Refresh()
        {
            var classes = (List<Class>)await DBService.GetClasses();
            Classes = new ObservableCollection<Class>(classes.Where(c => c.TermId == Term.Id));
            await Task.Delay(250);
        }

        public async Task<IEnumerable<Instructor>> GetInstructors()
        {
            return await DBService.GetInstructors();
        }
    }
}
