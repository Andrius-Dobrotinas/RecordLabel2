using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AndrewD.RecordLabel.Web
{
    public static class Settings
    {
        private static int itemsPerPage;
        public static int ItemsPerPage => itemsPerPage;

        public static void InitSettings()
        {
            string itemsPP = ConfigurationManager.AppSettings["Data.ItemsPerPage"];
            if (!int.TryParse(itemsPP, out itemsPerPage)) {
                throw new ConfigurationErrorsException("Config value for Data.ItemPerPage is not of Int type");
            }            
        }
    }
}