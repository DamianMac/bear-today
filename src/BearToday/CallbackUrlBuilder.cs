using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace BearToday
{
    public enum BearAction
    {
        Create
    };
    public class CallbackUrlBuilder
    {
        private static readonly Hashtable Actions = new Hashtable
        {
            {BearAction.Create, "create"}
        };

        public Uri BuildUrl(BearAction action, string[] tags, bool pin, bool showTimestamp, string title, string body)
        {

            var uri = new UriBuilder {Scheme = "bear", Host = "x-callback-url", Path = (string)Actions[action]};

            var queryParams = new NameValueCollection();
            queryParams.Add("title", Escape(title));
            queryParams.Add("tags", Escape(string.Join(",", tags)));
            queryParams.Add("pin", pin ? "yes" : "no");
            queryParams.Add("timestamp", showTimestamp ? "yes" : "no");
            queryParams.Add("show_window", "no");

            
            queryParams.Add("text", body);
            
            uri.Query = ToQueryString(queryParams);
            
            return uri.Uri;
        }
        
        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{HttpUtility.UrlPathEncode(key)}={Escape(value)}"
            ).ToArray();
            return string.Join("&", array);
        }

        private string Escape(string input)
        {
            return input
                .Replace("/", "%2F")
                .Replace(",", "%2C")
                .Replace("#", "%23")
                .Replace(" ", "%20")
                .Replace(Environment.NewLine, "%0A");
        }
    }
}