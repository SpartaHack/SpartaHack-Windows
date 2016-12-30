using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SpartaHack.BLL.Models
{
    public class HeaderGroup<T>: ObservableCollection<T>
    {
        public HeaderGroup(IEnumerable<T> items) : base(items) { }
        public string Header { get; set; }
    }
}
