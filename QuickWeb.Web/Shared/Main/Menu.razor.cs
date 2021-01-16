using System;
using System.Collections.Generic;

namespace QuickWeb.Web.Shared
{
    public class MenuObject
    {
        public String Title { get; set; }
        public Dictionary<String, String> Tab { get; set; }
        public Boolean Show { get; set; }
    }
}