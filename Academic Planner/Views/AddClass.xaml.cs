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
    public partial class AddClass : ContentPage
    {
        private int InstructorId;
        public AddClass()
        {
            InitializeComponent();
            status.Items.Add("Not Started");
            status.Items.Add("In-Progess");
            status.Items.Add("Completed");
            status.SelectedItem = "Not Started";
        }
        private async Task<bool> ValidateInput()
        {
            if (title.Text == "" || title.Text == null || instructor.Text == "" || instructor.Text == null)
            {
                await DisplayAlert("Invalid Input", "Please enter valid input into all fields", "OK");
                return false;
            }
            if (start.Date > end.Date)
            {
                await DisplayAlert("Invalid Input", "End date must be after start date", "OK");
                return false;
            }

            var termViewModel = (TermViewModel)BindingContext;
            Term term = termViewModel.Term;
            if (start.Date < term.Start
                    || start.Date > term.End
                    || end.Date < term.Start
                    || end.Date > term.End)
            {
                await DisplayAlert("Invalid Input", "Class dates must be inside current term", "OK");
                return false;
            }

            IEnumerable<Instructor> instructors = await termViewModel.GetInstructors();
            string name = instructor.Text.Trim();
            if (!instructors.Any(i => i.Name == name))
            {
                bool newInstructor = await DisplayAlert("Instructor Not Found", "Instructor " + name + " does not exist, would you like to add one?", "Yes", "No");
                if (newInstructor) 
                {
                    var addInstructor = new AddInstructor { BindingContext = BindingContext };
                    addInstructor.Init(instructor.Text);
                    await Navigation.PushModalAsync(addInstructor);
                }
                return false;
            }

            InstructorId = instructors.First(i => i.Name == name).Id;
            return true;
        }
        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (!await ValidateInput())
            {
                return;
            }


            var termViewModel = (TermViewModel)BindingContext;

            await termViewModel.Add(new Class
            {
                TermId = termViewModel.Term.Id,
                Title = title.Text,
                Start = start.Date,
                End = end.Date,
                InstructorId = InstructorId,
                Status = (string)status.SelectedItem
            });
            await Navigation.PopModalAsync();
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}