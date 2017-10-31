using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl
        {
            get
            {
                return String.Format("http://lorempixel.com/200/200/people/{0}", Id.ToString());
            }
        }
    }
}
