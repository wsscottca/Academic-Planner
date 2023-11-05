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
    public partial class AddTerm : ContentPage
    {
        public AddTerm()
        {
            InitializeComponent();
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

            var degreeViewModel = (DegreeViewModel)BindingContext;
            if(degreeViewModel.Terms.Count != 0)
            {
                if (degreeViewModel.Terms.Any(t =>
                                            (start.Date >= t.Start && start.Date <= t.End)
                                            || (end.Date >= t.Start && end.Date <= t.End)
                                            || (start.Date <= t.Start && end.Date >= t.End)))
                {
                    await DisplayAlert("Invalid Input", "Term dates cannot overlap, please review existing terms and try again", "OK");
                    return false;
                }
            }
            return true;
        }
        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (!await ValidateInput())
            {
                return;
            }


            var degreeViewModel = (DegreeViewModel)BindingContext;

            await degreeViewModel.Add(new Models.Term
            {
                Title = title.Text,
                Start = start.Date,
                End = end.Date
            });
            await Navigation.PopModalAsync();
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}