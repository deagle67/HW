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
    public partial class ListExo : ContentPage
    {
        private SearchService _searchContext;
        private List<SearchGroup> _searchResults;

        public ListExo()
        {
            InitializeComponent();
            _searchContext = new SearchService();
            listView.ItemsSource = GetSearch();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var item = (sender as MenuItem).CommandParameter as Search;
            _searchContext.DeleteSearch(item.Id);
            listView.ItemsSource = GetSearch();
            listView.EndRefresh();
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetSearch();
            listView.EndRefresh();
        }

        private IEnumerable<SearchGroup> GetSearch(string search = null)
        {
            var searchValues = _searchContext.GetSearches(search);
            _searchResults = new List<SearchGroup>()
            {
                new SearchGroup("Recent Searches", "Recent Searches")
            };

            foreach(Search s in searchValues)
            {
                _searchResults[0].Add(s);
            }

            return _searchResults;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetSearch(e.NewTextValue);
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Search;
            DisplayAlert("Location", item.Location, "OK");
        }
    }
}