using Academic_Planner.Models;
using Academic_Planner.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Academic_Planner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditClass : ContentPage
    {
        public EditClass()
        {
            InitializeComponent();
        }
        public async Task Init()
        {
            status.Items.Add("Not Started");
            status.Items.Add("In-Progess");
            status.Items.Add("Completed");
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            title.Text = aClass.Title;
            status.SelectedItem = aClass.Status;
            start.Date = aClass.Start;
            end.Date = aClass.End;

            Instructor instructor = await classViewModel.GetInstructor(aClass.InstructorId);
            instructorName.Text = instructor.Name;
            instructorEmail.Text = instructor.Email;
            instructorPhone.Text = instructor.Phone;

            toggleNotifStart.IsToggled = aClass.NotifyStart;
            toggleNotifEnd.IsToggled = aClass.NotifyEnd;
        }
        private async Task<bool> ValidateInput()
        {
            if (title.Text == "" || title.Text == null)
            {
                await DisplayAlert("Invalid Input", "Please enter valid input into all fields", "OK");
                return false;
            }

            if (start.Date > end.Date)
            {
                await DisplayAlert("Invalid Input", "End date must be after start date", "OK");
                return false;
            }

            var classViewModel = (ClassViewModel)BindingContext;
            TermViewModel termViewModel = classViewModel.TermViewModel;
            Term term = termViewModel.Term;
            if (start.Date < term.Start
                    || start.Date > term.End
                    || end.Date < term.Start
                    || end.Date > term.End)
            {
                await DisplayAlert("Invalid Input", "Class dates must be inside current term", "OK");
                return false;
            }

            Class aClass = classViewModel.Class;
            aClass.Title = title.Text;
            aClass.Start = start.Date;
            aClass.End = end.Date;
            aClass.Status = (string)status.SelectedItem;

            aClass.NotifyStart = toggleNotifStart.IsToggled;
            aClass.NotifyEnd = toggleNotifEnd.IsToggled;

            return true;
        }
        private async void ButtonEditInstructor_Clicked(object sender, EventArgs e)
        {
            var editInstructor = new EditInstructor { BindingContext = BindingContext };
            await editInstructor.Init();
            await Navigation.PushModalAsync(editInstructor);
        }
        private void ButtonEditNotes_Clicked(object sender, EventArgs e)
        {
            var notes = new Notes { BindingContext = BindingContext };
            Navigation.PushModalAsync(notes);
        }
        private void ButtonEditAssessments_Clicked(object sender, EventArgs e)
        {
            var assessments = new Assessments
            {
                BindingContext = BindingContext
            };
            assessments.Init();
            Navigation.PushModalAsync(assessments);
        }
        private async void ButtonSubmit_Clicked(object sender, EventArgs e)
        {
            if (!await ValidateInput())
            {
                return;
            }

            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            await classViewModel.Update(aClass);

            await classViewModel.TermViewModel.Refresh();
            
            await Navigation.PopModalAsync();
        }
        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}