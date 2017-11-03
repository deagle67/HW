using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HW.Services;
using HW.Models;

namespace HW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExoContacts : ContentPage
    {
        List<UserContact> _contacts = new List<UserContact>();

        ContactsService _contactsService = new ContactsService();

        public ExoContacts()
        {
            InitializeComponent();
            PopulateList();
        }

        private async void AddButton_ClickedAsync(object sender, EventArgs e)
        {
            var page = new ModifyUserContact();
            page.UserContactSaved += (source, contact) =>
            {
                if(contact.Id == 0)
                {
                    var newUserId = _contactsService.AddContact(contact);
                }
                else
                {
                    _contactsService.UpdateContact(contact);
                }
                PopulateList();
            };
            await Navigation.PushAsync(new NavigationPage(page));
        }

        private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contactSelected = e.SelectedItem as UserContact;
            var page = new ModifyUserContact(contactSelected);
            await Navigation.PushAsync(new NavigationPage(page));
            listContacts.SelectedItem = null;
        }

        private void PopulateList()
        {
            _contacts = _contactsService.GetContacts().ToList();
            listContacts.ItemsSource = _contacts;
        }
    }
}