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
    public partial class ClassDetail : ContentPage
    {
        public ClassDetail()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Task.Run(async () => { await Init(); });
            base.OnAppearing();
        }
        public async Task Init()
        {
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            classTitle.Text = aClass.Title + " - " + aClass.Status;
            Instructor instructor = await classViewModel.GetInstructor(aClass.InstructorId);
            instructorName.Text = instructor.Name;
            instructorPhone.Text = instructor.Phone;
            instructorEmail.Text = instructor.Email;
            start.Text = aClass.Start.ToShortDateString();
            end.Text = aClass.End.ToShortDateString();
            notifications.Text = "Notifications: " + (aClass.NotifyStart || aClass.NotifyEnd ? "On" : "Off");
        }

        private async void ButtonEdit_Clicked(object sender, EventArgs e)
        {
            var editClass = new EditClass
            {
                BindingContext = BindingContext
            };
            await editClass.Init();
            await Navigation.PushModalAsync(editClass);
        }

        private async void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;
            await classViewModel.TermViewModel.DegreeViewModel.Remove<Class>(aClass.Id);
            await classViewModel.TermViewModel.Refresh();
            await Navigation.PopModalAsync();
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            var note = (Note)viewCell.BindingContext;
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = note.Message,
                Title = note.Title
            });
        }
    }
}