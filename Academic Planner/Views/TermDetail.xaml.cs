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
    public partial class TermDetail : ContentPage
    {
        public TermDetail()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Init();
            base.OnAppearing();
        }
        public void Init()
        {
            var termViewModel = (TermViewModel)BindingContext;
            Term term = termViewModel.Term;
            termTitle.Text = term.Title;
            termDates.Text = term.Start.ToShortDateString() + " - " + term.End.ToShortDateString();
        }
        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            var addClass = new AddClass
            {
                BindingContext = BindingContext
            };
            await Navigation.PushModalAsync(addClass);
        }
        private async void ButtonEdit_Clicked(object sender, EventArgs e)
        {
            var editTerm = new EditTerm
            {
                BindingContext = BindingContext
            };
            editTerm.Init();
            await Navigation.PushModalAsync(editTerm);
        }

        private async void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            var termViewModel = (TermViewModel)BindingContext;
            Term term = termViewModel.Term;
            await termViewModel.DegreeViewModel.Remove<Term>(term.Id);
            await Navigation.PopModalAsync();
        }
        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            var aClass = (Class)viewCell.BindingContext;
            var classViewModel = new ClassViewModel
            {
                Class = aClass,
                TermViewModel = (TermViewModel)BindingContext
            };

            var classDetail = new ClassDetail
            {
                BindingContext = classViewModel
            };

            await classDetail.Init();

            await Navigation.PushModalAsync(classDetail);
        }
    }
}