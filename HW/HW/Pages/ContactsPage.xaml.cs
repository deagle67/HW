using System.Collections.Generic;

using Xamarin.Forms;
using HW.Models;

namespace HW
{
	public partial class ContactsPage : MasterDetailPage
	{
		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
            if (e.SelectedItem == null)
                return;
			var contact = e.SelectedItem as Contact;
			Detail = new NavigationPage(new ContactDetailPage(contact));
			IsPresented = false;
            listView.SelectedItem = null;
		}

		public ContactsPage()
		{
			InitializeComponent();

			listView.ItemsSource = new List<Contact> {
				new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1" },
				new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "Hey, let's talk!" }
			};
		}
	}
}

