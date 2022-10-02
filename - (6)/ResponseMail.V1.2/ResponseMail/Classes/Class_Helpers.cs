using System.Collections.Specialized;
using System.Web;

namespace ResponseMail
{
    public class Class_Helpers
    {
        public class URLQueryStringHelper
        {
            public URLQueryStringHelper(HttpRequest pHttpRequest)
            {
                _HttpRequest = pHttpRequest;
                // QueryString sadece okunabilir oldugu icin parse ediliyor.
                _requestQueryString = HttpUtility.ParseQueryString(_HttpRequest.QueryString.ToString());
            }

            private HttpRequest _HttpRequest { get; set; }
            private NameValueCollection _requestQueryString { get; set; }

            public string GetKeyValue(string key)
            {
                if (!_requestQueryString.HasKeys()) return null;

                if (_requestQueryString[key] != null && !string.IsNullOrEmpty(_requestQueryString[key]))
                {
                    return _requestQueryString[key];
                }
                else return null;
            }
        }

    }
}