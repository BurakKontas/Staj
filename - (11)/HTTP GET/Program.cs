using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HTTP_GET
{
    internal class Program
    {
        public class PostBody {
            public string htmlString { get; set; }
        }

        public static async void ReqPost(string api, string htmlString,string pdfDest)
        {
            if(htmlString.StartsWith("C:\\"))
            {
                htmlString = File.ReadAllText(htmlString);
            }
            var client = new RestClient(api);
            var request = new RestRequest($"htmltopdf", Method.Post);
            request.AddHeader("Content-Type", "application/json ");
            var json = new PostBody();
            json.htmlString = htmlString;
            var body = JsonConvert.SerializeObject(json);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            var result = response.Content.Replace("\"", string.Empty);
            var mybytearray = Convert.FromBase64String(result);
            File.WriteAllBytes(pdfDest, mybytearray);
        }
        static void Main(string[] args)
        {
            ReqPost("https://pdfminimalapi.azurewebsites.net/", "C:\\Users\\konta\\Desktop\\c.html", "C:\\Users\\konta\\Desktop\\test1234.pdf");

        }
    }
}
