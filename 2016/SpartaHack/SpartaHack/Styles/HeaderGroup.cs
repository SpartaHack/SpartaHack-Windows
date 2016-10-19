using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SpartaHack.Styles
{
    class HeaderGroup : ObservableCollection<object>
    {
        public HeaderGroup(IEnumerable<object> items) : base(items)
        {
        }

        public string Header { get; set; }
    }
}
