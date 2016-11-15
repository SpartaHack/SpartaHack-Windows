using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Constants
{
    public class APIConstants
    {
        public static string RootURL= "https://d.api.spartahack.com";
        public static string Token = "67a016ff86e35dd9dac23a9faaf99b96";



        public static string Schedule = RootURL + "/schedule/";
        public static string FAQ = RootURL + "/faq/";
        public static string Sessions = RootURL + "/sessions/";
        public static string Users = RootURL + "/users/";



        public static string SlackURL = "https://hooks.slack.com/services/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";
    }
}
