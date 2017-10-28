using HW.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Services
{
    public class SearchService
    {
        private List<Search> _values;

        public SearchService()
        {
            _values = new List<Search>
            {
                new Search {
                    Id = 1,
                    Location = "West Hollywood, CA, United States",
                    CheckIn = new DateTime(2016, 09, 01),
                    CheckOut = new DateTime(2016, 11, 01)
                },
                new Search
                {
                    Id = 2,
                    Location = "Santa Monica, CA, United States",
                    CheckIn = new DateTime(2016, 09, 01),
                    CheckOut = new DateTime(2016, 11, 01)
                }
            };           
        }

        public IEnumerable<Search> GetSearches(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))
                return _values;
            else
                return _values.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        public void DeleteSearch(int searchId)
        {
            _values.RemoveAll(s => s.Id.Equals(searchId));
        }
    }
}
