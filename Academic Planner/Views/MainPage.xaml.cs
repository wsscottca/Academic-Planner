using Academic_Planner.Models;
using Academic_Planner.View_Models;
using Academic_Planner.Views;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Academic_Planner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                var degreeViewModel = (DegreeViewModel)BindingContext;
                progress.Progress = await degreeViewModel.GetProgress();

                await DisplayNotifications();
            });
        }
        private async Task DisplayNotifications()
        {
            var degreeViewModel = (DegreeViewModel)BindingContext;
            Dictionary<Class, string> classNotifs = await degreeViewModel.GetClassNotifications();
            Dictionary<Assessment, string> assessmentNotifs = await degreeViewModel.GetAssessmentNotifications();

            string notifMessage;
            foreach (KeyValuePair<Class, string> pair in classNotifs)
            {
                if (pair.Value == "Both")
                {
                    notifMessage = "Class " + pair.Key.Title + " starts and ends today.\n";
                    CrossLocalNotifications.Current.Show("Class Notification", notifMessage);
                }
                else if (pair.Value == "Start")
                {
                    notifMessage = "Class " + pair.Key.Title + " starts today.\n";
                    CrossLocalNotifications.Current.Show("Class Notification", notifMessage);
                }
                else
                {
                    notifMessage = "Class " + pair.Key.Title + " ends today.\n";
                    CrossLocalNotifications.Current.Show("Class Notification", notifMessage);
                }
            }
            foreach (KeyValuePair<Assessment, string> pair in assessmentNotifs)
            {
                Class aClass = await degreeViewModel.GetClass(pair.Key.ClassId);
                if (pair.Value == "Both")
                {
                    notifMessage = "Assessment " + pair.Key.Title + " for class " + aClass.Title + " is available and due today.\n";
                    CrossLocalNotifications.Current.Show("Assessment Notification", notifMessage);
                }
                else if (pair.Value == "Start")
                {
                    notifMessage = "Assessment " + pair.Key.Title + " for class " + aClass.Title + " is available starting today.\n";
                    CrossLocalNotifications.Current.Show("Assessment Notification", notifMessage);
                }
                else
                {
                    notifMessage = "Assessment " + pair.Key.Title + " for class " + aClass.Title + " is due today.\n";
                    CrossLocalNotifications.Current.Show("Assessment Notification", notifMessage);
                }
            }
        }
        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            var addTerm = new AddTerm
            {
                BindingContext = BindingContext
            };
            await Navigation.PushModalAsync(addTerm);
        }
        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            var term = (Term)viewCell.BindingContext;
            var termViewModel = new TermViewModel
            {
                Term = term,
                DegreeViewModel = (DegreeViewModel)BindingContext
            };

            var termDetail = new TermDetail
            {
                BindingContext = termViewModel
            };

            termDetail.Init();

            await Navigation.PushModalAsync(termDetail);
        }
    }
}
