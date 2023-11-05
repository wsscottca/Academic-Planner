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
    public partial class AddNote : ContentPage
    {
        public AddNote()
        {
            InitializeComponent();
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            if (title.Text == "" || message.Text == "" || title.Text == null || message.Text == null)
            {
                await DisplayAlert("Input Error", "Please enter input into all fields.", "OK");
                return;
            }
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            await classViewModel.Add(new Note
            {
                Title = title.Text,
                Message = message.Text,
                ClassId = aClass.Id,
                Created = DateTime.Now
            });
            await classViewModel.Refresh();
            await Navigation.PopModalAsync();
        }
        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}