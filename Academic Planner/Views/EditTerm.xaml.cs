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
    public partial class EditTerm : ContentPage
    {
        public EditTerm()
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

            var termViewModel = (TermViewModel)BindingContext;
            Term term = termViewModel.Term;
            if (termViewModel.DegreeViewModel.Terms.Count != 0)
            {
                if (termViewModel.DegreeViewModel.Terms.Any(t =>
                                            ((start.Date >= t.Start && start.Date <= t.End)
                                            || (end.Date >= t.Start && end.Date <= t.End)
                                            || (start.Date <= t.Start && end.Date >= t.End))
                                            && t.Id != term.Id))
                {
                    await DisplayAlert("Invalid Input", "Term dates cannot overlap, please review existing terms and try again", "OK");
                    return false;
                }
            }
            return true;
        }

        public void Init()
        {
            var termViewModel = (TermViewModel)BindingContext;
            Term term = termViewModel.Term;
            title.Text = term.Title;
            start.Date = term.Start;
            end.Date = term.End;
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var termViewModel = (TermViewModel)BindingContext;
            Term term = termViewModel.Term;

            if (title.Text == term.Title
                && start.Date == term.Start
                && end.Date == term.End)
            {
                await Navigation.PopModalAsync();
            }

            if (!await ValidateInput())
            {
                return;
            }

            
            term.Title = title.Text;
            term.Start = start.Date;
            term.End = end.Date;

            await termViewModel.DegreeViewModel.Update(term);
            await termViewModel.Refresh();
            await Navigation.PopModalAsync();
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}