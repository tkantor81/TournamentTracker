using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TournamentTracker
{
    public class CustomLocationViewEngine : RazorViewEngine
    {
        private static string[] Locations = new[] {
            "~/Views/Settings/{1}/{0}.cshtml",
            "~/Views/Settings/{1}/{0}.vbhtml"
        };

        public CustomLocationViewEngine()
        {
            ViewLocationFormats = ViewLocationFormats.Union(Locations).ToArray();
        }
    }
}