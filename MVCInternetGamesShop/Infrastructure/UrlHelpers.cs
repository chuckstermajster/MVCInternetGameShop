using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInternetGamesShop.Infrastructure
{
    public static class UrlHelpers
    {
        public static string Ps4CoversPath(this UrlHelper helper, string Ps4CoversName)
        {
            var ps4CoversFolder = AppConfig.PS4CoversRelativeFolder;
            var path = Path.Combine(ps4CoversFolder, Ps4CoversName);
            var unRelativePath = helper.Content(path);
            return unRelativePath;
        }

        public static string XBoxOneCoversPath(this UrlHelper helper, string XboxOneCoversName)
        {
            var xboxOneCoversFolder = AppConfig.XBOXONECoversRelativeFolder;
            var path = Path.Combine(xboxOneCoversFolder, XboxOneCoversName);
            var unRelativePath = helper.Content(path);
            return unRelativePath;
        }

        public static string PCCoversPath(this UrlHelper helper, string PCCoversName)
        {
            var PCCoversFolder = AppConfig.PCCoversRelativeFolder;
            var path = Path.Combine(PCCoversFolder, PCCoversName);
            var unRelativePath = helper.Content(path);
            return unRelativePath;
        }
    }
}