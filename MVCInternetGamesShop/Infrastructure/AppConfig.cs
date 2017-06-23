using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Infrastructure
{
    public class AppConfig
    {
        private static string _ps4CoversRelativeFolder = ConfigurationManager.AppSettings["Ps4Covers"];
        public static string PS4CoversRelativeFolder
        {
            get
            {
                return _ps4CoversRelativeFolder;
            }
        }

        private static string _PCCoversRelativeFolder = ConfigurationManager.AppSettings["PCCovers"];
        public static string PCCoversRelativeFolder
        {
            get
            {
                return _PCCoversRelativeFolder;
            }
        }

        private static string _XBOXONECoversRelativeFolder = ConfigurationManager.AppSettings["XBOXONECovers"];
        public static string XBOXONECoversRelativeFolder
        {
            get
            {
                return _XBOXONECoversRelativeFolder;
            }
        }


    }
}