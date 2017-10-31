
using System;
using Xamarin.Forms;
using HW.Models;

namespace HW
{
	public partial class ContactDetailPage : ContentPage
	{
		public ContactDetailPage(Contact contact)
		{
            BindingContext = contact ?? throw new ArgumentNullException(); 

			InitializeComponent();
		}
	}
}

