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
    public partial class PhotoGalleryEx : ContentPage
    {
        int minImageId = 1;
        int maxImageId = 10;
        int currentId = 1;

        public PhotoGalleryEx()
        {
            InitializeComponent();

            ImageDisplayed.Aspect = Aspect.AspectFit;

            ImageDisplayed.Source = new UriImageSource
            {
                Uri = new Uri("http://lorempixel.com/1920/1080/city/1"),
                CachingEnabled = false,
            };
        }

        private void LeftButton_Clicked(object sender, EventArgs e)
        {
            currentId--;
            if (currentId == minImageId)
                currentId = maxImageId;

            LoadImage();
        }

        private void RightButton_Clicked(object sender, EventArgs e)
        {
            currentId++;
            if (currentId == maxImageId)
                currentId = minImageId;

            LoadImage();
        }

        void LoadImage()
        {
            ImageDisplayed.Source = new UriImageSource
            {
                Uri = new Uri(String.Format("http://lorempixel.com/1920/1080/city/{0}", currentId)),
                CachingEnabled = false
            };
        }
    }
}