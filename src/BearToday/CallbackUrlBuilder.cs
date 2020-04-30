using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace BearToday
{
    public class CallbackUrlBuilder
    {
        public Uri BuildToday(DateTime today)
        {
            var uri = new UriBuilder();
            uri.Scheme = "bear";
            uri.Host = "x-callback-url";
            uri.Path = "create";
            
            var queryParams = new NameValueCollection();
            queryParams.Add("title", today.ToString("d MMMM yyyy - dddd"));
            queryParams.Add("tags", "today/" + today.ToString("yyyy/MM"));
            queryParams.Add("pin", "yes");
            queryParams.Add("timestamp", "yes");
            queryParams.Add("show_window", "no");

            var body = $"{Environment.NewLine}{Environment.NewLine}## Today{Environment.NewLine}";
            queryParams.Add("text", body);
            
            uri.Query = ToQueryString(queryParams);
            
            return uri.Uri;
        }
        
        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{HttpUtility.UrlPathEncode(key)}={ExtraEscapes(value)}"
            ).ToArray();
            return string.Join("&", array);
        }

        private string ExtraEscapes(string input)
        {
            return input
                .Replace("/", "%2F")
                .Replace("#", "%23")
                .Replace(" ", "%20")
                .Replace(Environment.NewLine, "%0A");
        }
    }
}