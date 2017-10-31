using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        string[] quotes;
        int quoteIndex = 0;

        public QuotesPage()
        {
            InitializeComponent();

            quotes = new[]
            {
                "Burger King",
                "McDonald\'s",
                "KFC",
                "Quick"
            };

            quoteText.Text = quotes[quoteIndex];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int newQuoteIndex = quoteIndex >= quotes.Length ? 0 : quoteIndex++;
            quoteText.Text = quotes[newQuoteIndex];
        }
    }
}