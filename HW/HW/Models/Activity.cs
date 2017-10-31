using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Models
{
    public class Activity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImageUrl
        {
            get
            {
                return String.Format("http://lorempixel.com/100/100/people/{0}", UserId.ToString());
            }
        }
    }
}
