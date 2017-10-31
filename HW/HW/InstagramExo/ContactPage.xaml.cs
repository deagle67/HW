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
    public partial class ContactPage : ContentPage
    {
        private UserService _userServiceContext = null;

        private User _user;
        public ContactPage(int userId)
        {
            InitializeComponent();
            if (_userServiceContext == null)
            {
                _userServiceContext = new UserService();
            }
            if (userId != 0)
                _user = _userServiceContext.GetUser(userId);

            BindingContext = _user ?? throw new ArgumentNullException();
        }
    }
}