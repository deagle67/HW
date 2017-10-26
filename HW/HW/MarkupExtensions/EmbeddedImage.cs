using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HW.MarkupExtensions
{
    [ContentProperty("RessourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string RessourceId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(RessourceId))
                return null;

            return ImageSource.FromResource(RessourceId);
        }
    }
}
