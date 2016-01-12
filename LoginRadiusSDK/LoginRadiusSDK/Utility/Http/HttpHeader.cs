using System.Collections.Generic;
using System.Net;

namespace LoginRadiusSDK.Utility.Http
{
    /// <summary>
    ///  Header class for for API excecution. 
    /// </summary>
    public class HttpHeader : Dictionary<string, string>
    {
        public WebHeaderCollection ToWebHeaderCollection()
        {
            var webheadercollection = new WebHeaderCollection();

            if (Count > 0)
            {
                foreach (var header in this)
                {
                    webheadercollection.Add(header.Key, header.Value);
                }
            }

            return webheadercollection;
        }
    }

    public static class HttpHeaderExtension
    {
        public static HttpHeader ToHttpHeader(this WebHeaderCollection webHeaderCollection)
        {
            var httpheaders = new HttpHeader();

            if (webHeaderCollection.Count > 0)
            {
                foreach (var header in webHeaderCollection)
                {
                    httpheaders.Add(header.ToString(), webHeaderCollection[header.ToString()]);
                }
            }

            return httpheaders;
        }
    }

}
