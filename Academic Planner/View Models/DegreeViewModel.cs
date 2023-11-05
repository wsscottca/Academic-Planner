using Academic_Planner.Models;
using Academic_Planner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Academic_Planner.View_Models
{
    public class DegreeViewModel : ViewModel
    {
        private ObservableCollection<Term> _terms = new ObservableCollection<Term>();
        public ObservableCollection<Term> Terms
        {
            get => _terms;
            set
            {
                if (value != _terms)
                {
                    _terms = value;
                    OnPropertyChanged("Terms");
                }
            }
        }

        public DegreeViewModel()
        {
            Task.Run(async () => {
                Terms = new ObservableCollection<Term>(await DBService.GetTerms());
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
            Terms = new ObservableCollection<Term>(await DBService.GetTerms());
            await Task.Delay(250);
        }

        public async Task<float> GetProgress()
        {
            return await DBService.GetProgress();
        }
        public async Task<Dictionary<Class, string>> GetClassNotifications()
        {
            return await DBService.GetClassNotifications();
        }
        public async Task<Dictionary<Assessment, string>> GetAssessmentNotifications()
        {
            return await DBService.GetAssessmentNotifications();
        }
        public async Task<Class> GetClass(int id)
        {
            return await DBService.GetClass(id);
        }
    }
}
