using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WpfClient.MarkupExtensions
{
    // https://thomaslevesque.com/2011/09/23/wpf-4-5-subscribing-to-an-event-using-a-markup-extension/
    internal class MyExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            throw new NotImplementedException();
        }
    }
}
