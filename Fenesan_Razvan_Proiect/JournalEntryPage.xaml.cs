using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fenesan_Razvan_Proiect.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fenesan_Razvan_Proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JournalEntryPage : ContentPage
    {
        public JournalEntryPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            journalView.ItemsSource = await App.Database.GetJournalsAsync();
        }
        async void OnJournalAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DayPage
            {
                BindingContext = new Journal()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem!=null)
            {
                await Navigation.PushAsync(new DayPage
                    { 
                    BindingContext=e.SelectedItem as Journal
                     });
            }
        }
        
    }
}