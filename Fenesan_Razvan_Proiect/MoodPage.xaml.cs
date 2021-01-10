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
    public partial class MoodPage : ContentPage
    {
        Journal j1;
        public MoodPage(Journal jtoday)
        {
            InitializeComponent();
            j1 = jtoday;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var mood = (Mood)BindingContext;
            await App.Database.SaveMoodAsync(mood);
            listView.ItemsSource = await App.Database.GetMoodsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var mood = (Mood)BindingContext;
            await App.Database.DeleteMoodAsync(mood);
            listView.ItemsSource = await App.Database.GetMoodsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMoodsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Mood m;
            if(e.SelectedItem!=null)
            {
                m = e.SelectedItem as Mood;
                var lm = new ListMood()
                {
                    JournalID = j1.ID,
                    MoodID = m.ID
                };
                await App.Database.SaveListMoodAsync(lm);
                m.ListMoods = new List<ListMood> { lm };

                //await Navigation.PopAsync();
            }
        }
    }
}