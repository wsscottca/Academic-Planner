using Academic_Planner.Models;
using Academic_Planner.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Academic_Planner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInstructor : ContentPage
    {
        public AddInstructor()
        {
            InitializeComponent();
        }
        public void Init(string instructorName)
        {
            name.Text = instructorName;
        }
        private async void ButtonSubmit_Clicked(object sender, EventArgs e)
        {
            if (!await ValidateInput())
            {
                return;
            }

            var termViewModel = (TermViewModel)BindingContext;
            await termViewModel.Add(new Instructor
            {
                Name = name.Text,
                Phone = phone.Text,
                Email = email.Text
            });


            await termViewModel.Refresh();

            await Navigation.PopModalAsync();
        }

        private async Task<bool> ValidateInput()
        {
            if (name.Text == "" || phone.Text == "" || email.Text == "" || name.Text == null || phone.Text == null || email.Text == null)
            {
                await DisplayAlert("Invalid Input", "Please enter valid input into all fields", "OK");
                return false;
            }

            if (!Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                await DisplayAlert("Invalid Input", "Please enter a valid email", "OK");
                return false;
            }

            return true;
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}