using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyUserContact : ContentPage
    {
        private UserContact _contact = new UserContact();

        public event EventHandler<UserContact> UserContactSaved;

        public ModifyUserContact()
        {
            InitializeComponent();
            BindingContext = _contact;
        }

        public ModifyUserContact(UserContact contact)
        {
            InitializeComponent();
            _contact = contact ?? throw new ArgumentNullException();
            BindingContext = _contact;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(FirstNameEntry.Text) && String.IsNullOrWhiteSpace(LastNameEntry.Text))
            {
                await DisplayAlert("Name is empty!", "Please enter the name.", "OK");
                return;
            }

            UserContactSaved(this, _contact);

            await Navigation.PopAsync();
        }
    }
}