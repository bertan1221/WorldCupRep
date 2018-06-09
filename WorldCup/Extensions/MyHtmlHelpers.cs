﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldCup.Extensions
{
    public static class MyHtmlHelpers
    {
        public static MvcHtmlString MyColoredPasswordTextBox(this HtmlHelper helper, string color, string name)
        {
            var html =
                $"<input type='password' style='color:{color}' name='{name}' />";

            return new MvcHtmlString(html);
        }
    }
}