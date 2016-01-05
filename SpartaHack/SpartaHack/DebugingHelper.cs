using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SpartaHack
{
    class DebugingHelper
    {
        public static async void ShowError(string message)
        {
            await new Windows.UI.Popups.MessageDialog(message,"Error found").ShowAsync();
        }
    }
}
