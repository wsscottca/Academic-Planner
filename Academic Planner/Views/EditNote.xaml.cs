using Academic_Planner.Models;
using Academic_Planner.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Academic_Planner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNote : ContentPage
    {
        public EditNote()
        {
            InitializeComponent();
        }

        public Note Note { get; internal set; }

        public void Init(Note note)
        {
            title.Text = Note.Title;
            message.Text = Note.Message;
            Note = note;
        }
        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            if (title.Text == "" || message.Text == "" || title.Text == null || message.Text == null)
            {
                await DisplayAlert("Input Error", "Please enter input into all fields.", "OK");
                return;
            }
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            Note.Title = title.Text;
            Note.Message = message.Text;
            await classViewModel.Update(Note);
            await classViewModel.Refresh();
            await Navigation.PopModalAsync();
        }
        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        private async void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            var classViewModel = (ClassViewModel)BindingContext;
            await classViewModel.Remove<Note>(Note.Id);
            await classViewModel.Refresh();
            await Navigation.PopModalAsync();
        }
        private async void ButtonShare_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = Note.Message,
                Title = Note.Title
            });
        }
    }
}