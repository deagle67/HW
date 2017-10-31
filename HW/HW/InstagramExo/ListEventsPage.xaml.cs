using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HW.Models;

namespace HW.InstagramExo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEventsPage : ContentPage
    {
        ActivityService _activityContext;

        public ListEventsPage()
        {
            InitializeComponent();
            if(_activityContext == null)
                _activityContext = new ActivityService();
            PopulateListView();
        }

        public async void ListEvents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var activity = e.SelectedItem as Activity;
            await Navigation.PushAsync(new ContactPage(activity.UserId));
            listEvents.SelectedItem = null;
        }

        public void PopulateListView()
        {
            listEvents.ItemsSource = _activityContext.GetActivities();
        }
    }
}