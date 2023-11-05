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
    public partial class Notes : ContentPage
    {
        public Notes()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            var addNote = new AddNote
            {
                BindingContext = BindingContext,
            };
            Navigation.PushModalAsync(addNote);
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            var note = (Note)viewCell.BindingContext;
            var editNote = new EditNote
            {
                BindingContext = BindingContext,
                Note = note
            };
            editNote.Init(note);
            await Navigation.PushModalAsync(editNote);
        }
    }
}