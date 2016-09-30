using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomHTMLHelper.Helpers
{
    public static class HeaderHelper
    {
        public static IHtmlString H1(this HtmlHelper helper, string text)
        {
            return new HtmlString(String.Format("<h1>{0}</h1>", text));
        }

        public static IHtmlString H2(this HtmlHelper helper, string text)
        {
            return new HtmlString(String.Format("<h2>{0}</h2>", text));
        }

        public static IHtmlString H3(this HtmlHelper helper, string text)
        {
            return new HtmlString(String.Format("<h3>{0}</h3>", text));
        }
    }
}