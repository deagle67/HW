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
    public partial class StackPage : ContentPage
    {
        public StackPage()
        {
            InitializeComponent();

            var layout = new StackLayout
            {
                Spacing = 40,
                Padding = new Thickness(20),
                Orientation = StackOrientation.Horizontal
            };

            layout.Children.Add(new Label { Text = "Label 1" });

            Content = layout;
        }
    }
}