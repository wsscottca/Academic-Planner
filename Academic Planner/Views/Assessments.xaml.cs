using Academic_Planner.Models;
using Academic_Planner.View_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Academic_Planner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assessments : ContentPage
    {
        public Assessments()
        {
            InitializeComponent();
        }
        public void Init()
        {
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            ObservableCollection<Assessment> assessments = classViewModel.Assessments;
            perfTitle.Text = "";
            perfStart.Date = DateTime.Now;
            perfEnd.Date = DateTime.Now;
            perfToggleNotifStart.IsToggled = false;
            perfToggleNotifEnd.IsToggled = false;
            objTitle.Text = "";
            objStart.Date = DateTime.Now;
            objEnd.Date = DateTime.Now;
            objToggleNotifStart.IsToggled = false;
            objToggleNotifEnd.IsToggled = false;
            foreach (Assessment assessment in assessments)
            {
                if (assessment.Type == "Performance")
                {
                    perfTitle.Text = assessment.Title;
                    perfStart.Date = assessment.Start;
                    perfEnd.Date = assessment.End;
                    perfToggleNotifStart.IsToggled = assessment.NotifyStart;
                    perfToggleNotifEnd.IsToggled = assessment.NotifyEnd;
                }
                else
                {
                    objTitle.Text = assessment.Title;
                    objStart.Date = assessment.Start;
                    objEnd.Date = assessment.End;
                    objToggleNotifStart.IsToggled = assessment.NotifyStart;
                    objToggleNotifEnd.IsToggled = assessment.NotifyEnd;
                }
            }
        }
        private async Task<bool> ValidatePerfInput()
        {
            if (perfTitle.Text == null || perfTitle.Text == "")
            {
                await DisplayAlert("Input Error", "Please enter a valid title.", "OK");
                return false;
            }

            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            if (perfStart.Date < aClass.Start
                || perfStart.Date > aClass.End
                || perfEnd.Date > aClass.End
                || perfStart.Date > perfEnd.Date)
            {
                await DisplayAlert("Input Error", "Start and end date must be within class dates and start must be before end.", "OK");
                return false;
            }

            return true;
        }
        private async Task<bool> ValidateObjInput()
        {
            if (objTitle.Text == null || objTitle.Text == "")
            {
                await DisplayAlert("Input Error", "Please enter a valid title.", "OK");
                return false;
            }

            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            if (objStart.Date < aClass.Start
                || objStart.Date > aClass.End
                || objEnd.Date > aClass.End
                || objStart.Date > objEnd.Date)
            {
                await DisplayAlert("Input Error", "Start and end date must be within class dates and start must be before end.", "OK");
                return false;
            }

            return true;
        }
        private async void ButtonPerfUpdate_Clicked(object sender, EventArgs e)
        {
            if (!await ValidatePerfInput())
            {
                return;
            }
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            ObservableCollection<Assessment> assessments = classViewModel.Assessments;
            foreach (Assessment assessment in assessments)
            {
                if (assessment.Type == "Performance")
                {
                    assessment.Title = perfTitle.Text;
                    assessment.Start = perfStart.Date;
                    assessment.End = perfEnd.Date;
                    assessment.NotifyStart = perfToggleNotifStart.IsToggled;
                    assessment.NotifyEnd = perfToggleNotifEnd.IsToggled;
                    await classViewModel.Update(assessment);
                    await classViewModel.Refresh();
                    await DisplayAlert("Assessment Updated", "Peformance assessment successfully updated.", "OK");
                    Init();
                    return;
                }
            }

            
            await classViewModel.Add(new Assessment
            {
                Title = perfTitle.Text,
                Start = perfStart.Date,
                ClassId = aClass.Id,
                Type = "Performance",
                End = perfEnd.Date,
                NotifyStart = perfToggleNotifStart.IsToggled,
                NotifyEnd = perfToggleNotifEnd.IsToggled
            });
            Init();
            await classViewModel.Refresh();
            await DisplayAlert("Assessment Created", "Peformance assessment successfully created.", "OK");

        }
        private async void ButtonPerfDelete_Clicked(object sender, EventArgs e)
        {
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            ObservableCollection<Assessment> assessments = classViewModel.Assessments;
            foreach (Assessment assessment in assessments)
            {
                if (assessment.Type == "Performance")
                {
                    await classViewModel.Remove<Assessment>(assessment.Id);
                    await classViewModel.Refresh();
                    await DisplayAlert("Assessment Deleted", "Peformance assessment successfully deleted.", "OK");
                    Init();
                    return;
                }
            }
            Init();
            await DisplayAlert("Delete Error", "Peformance assessment does not exist.", "OK");
        }
        private async void ButtonObjUpdate_Clicked(object sender, EventArgs e)
        {
            if (!await ValidateObjInput())
            {
                return;
            }
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            ObservableCollection<Assessment> assessments = classViewModel.Assessments;
            foreach (Assessment assessment in assessments)
            {
                if (assessment.Type == "Objective")
                {
                    assessment.Title = objTitle.Text;
                    assessment.Start = objStart.Date;
                    assessment.End = objEnd.Date;
                    assessment.NotifyStart = objToggleNotifStart.IsToggled;
                    assessment.NotifyEnd = objToggleNotifEnd.IsToggled;
                    await classViewModel.Update(assessment);
                    await classViewModel.Refresh();
                    await DisplayAlert("Assessment Updated", "Objective assessment successfully updated.", "OK");
                    Init();
                    return;
                }
            }


            await classViewModel.Add(new Assessment
            {
                Title = objTitle.Text,
                Start = objStart.Date,
                ClassId = aClass.Id,
                Type = "Objective",
                End = objEnd.Date,
                NotifyStart = objToggleNotifStart.IsToggled,
                NotifyEnd = objToggleNotifEnd.IsToggled
            });
            Init();
            await classViewModel.Refresh();
            await DisplayAlert("Assessment Created", "Objective assessment successfully created.", "OK");
        }
        private async void ButtonObjDelete_Clicked(object sender, EventArgs e)
        {
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            ObservableCollection<Assessment> assessments = classViewModel.Assessments;
            foreach (Assessment assessment in assessments)
            {
                if (assessment.Type == "Objective")
                {
                    await classViewModel.Remove<Assessment>(assessment.Id);
                    await classViewModel.Refresh();
                    await DisplayAlert("Assessment Deleted", "Objective assessment successfully deleted.", "OK");
                    Init();
                    return;
                }
            }
            Init();
            await DisplayAlert("Delete Error", "Objective assessment does not exist.", "OK");
        }
        private void ButtonClose_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}