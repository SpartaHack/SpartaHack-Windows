using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Constants
{
    public class APIConstants
    {
        public static readonly string RootURL= "https://d.api.spartahack.com";
        public static readonly string Token = "67a016ff86e35dd9dac23a9faaf99b96";
                     
        public static readonly string Schedule = RootURL + "/schedule/";
        public static readonly string FAQ = RootURL + "/faq/";
        public static readonly string Sessions = RootURL + "/sessions/";
        public static readonly string Users = RootURL + "/users/";
        public static readonly string Sponsors = RootURL + "/sponsors/";
        public static readonly string Prizes = RootURL + "/prizes/";
        public static readonly string Categories = RootURL + "/categories/";


        public static readonly string OldSlackURL = "https://hooks.slack.com/services/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";
        public static readonly string SlackURL = "https://hooks.slack.com/services/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";
    }
}
