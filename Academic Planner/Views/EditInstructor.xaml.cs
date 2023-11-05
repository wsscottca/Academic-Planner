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
    public partial class EditInstructor : ContentPage
    {
        private Instructor Instructor;
        public EditInstructor()
        {
            InitializeComponent();
        }
        public async Task Init()
        {
            var classViewModel = (ClassViewModel)BindingContext;
            Class aClass = classViewModel.Class;

            Instructor = await classViewModel.GetInstructor(aClass.InstructorId);
            if (Instructor != null)
            {
                name.Text = Instructor.Name;
                phone.Text = Instructor.Phone;
                email.Text = Instructor.Email;
            }
        }
        private async void ButtonSubmit_Clicked(object sender, EventArgs e)
        {
            if (!await ValidateInput())
            {
                return;
            }

            var classViewModel = (ClassViewModel)BindingContext;

            Instructor potentialInstructor = await classViewModel.GetInstructor(name.Text);
            if (potentialInstructor != null)
            {
                classViewModel.Class.InstructorId = potentialInstructor.Id;
                potentialInstructor.Phone = phone.Text;
                potentialInstructor.Email = email.Text;

                await classViewModel.Update(potentialInstructor);
                await classViewModel.Update(classViewModel.Class);
                await classViewModel.Refresh();
            }
            else
            {
                bool result = await DisplayAlert("Update Instructor", "Do you want to create a new instructor named " + name.Text + "?", "Yes", "No");
                if (result)
                {
                    await classViewModel.Add(new Instructor
                    {
                        Name = name.Text,
                        Phone = phone.Text,
                        Email = email.Text
                    });
                    potentialInstructor = await classViewModel.GetInstructor(name.Text);
                    classViewModel.Class.InstructorId = potentialInstructor.Id;
                    await classViewModel.Update(classViewModel.Class);
                    await classViewModel.Refresh();
                }
                else
                {
                    await classViewModel.Update(Instructor);
                }
            }


            await classViewModel.TermViewModel.Refresh();

            await Navigation.PopModalAsync();
        }

        private async Task<bool> ValidateInput()
        {
            if (name.Text == "" || phone.Text == ""|| email.Text == "")
            {
                await DisplayAlert("Invalid Input", "Please enter valid input into all fields", "OK");
                return false;
            }

            if (!Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                await DisplayAlert("Invalid Input", "Please enter a valid email", "OK");
                return false;
            }

            if (Instructor == null)
            {
                Instructor = new Instructor();
            }

            Instructor.Name = name.Text;
            Instructor.Phone = phone.Text;
            Instructor.Email = email.Text;

            return true;
        }
        private async void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            var classViewModel = (ClassViewModel)BindingContext;
            if (Instructor != null && Instructor.Name == name.Text)
            {
                await classViewModel.Remove<Instructor>(Instructor.Id);
                name.Text = "";
                phone.Text = "";
                email.Text = "";
                await DisplayAlert("Successfully Deleted", "Instructor " + Instructor.Name + " successfully deleted.", "OK");
                classViewModel.Class.InstructorId = -1;
                Instructor = null;
                return;
            }

            Instructor potentialInstructor = await classViewModel.GetInstructor(name.Text);
            if (potentialInstructor != null)
            {
                await classViewModel.Remove<Instructor>(potentialInstructor.Id);
                name.Text = "";
                phone.Text = "";
                email.Text = "";
                await DisplayAlert("Successfully Deleted", "Instructor " + potentialInstructor.Name + " successfully deleted.", "OK");
                classViewModel.Class.InstructorId = -1;
                return;
            }

            await DisplayAlert("Delete failed", "Instructor " + name.Text + " does not exist.", "OK");
        }
        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            var classViewModel = (ClassViewModel)BindingContext;

            if (classViewModel.Class.InstructorId != -1)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Cancel failed", "Course requires an instructor to be set.", "OK");
            }
            
        }
    }
}