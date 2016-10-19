using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SpartaHack
{
    class DebuggingHelper
    {
        public static async void ShowError(string message)
        {
#if DEBUG
            await new Windows.UI.Popups.MessageDialog(message,"Error found").ShowAsync();
#endif
        }
    }
}
