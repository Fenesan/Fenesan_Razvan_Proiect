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
    public partial class DayPage : ContentPage
    {
        public DayPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var jtoday = (Journal)BindingContext;
            jtoday.Date = DateTime.UtcNow;
            await App.Database.SaveJournalAsync(jtoday);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var jtoday = (Journal)BindingContext;
            await App.Database.DeleteJournalAsync(jtoday);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoodPage((Journal)this.BindingContext)
            {
                BindingContext = new Mood()
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var jourl = (Journal)BindingContext;
            listView.ItemsSource = await App.Database.GetListMoodsAsync(jourl.ID);
        }
    }
}