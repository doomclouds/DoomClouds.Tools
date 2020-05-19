using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoomClouds.Tools.Helpers.Http
{
    public class HttpClientHelper
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task SendPostAsync<T>(T t,string url)
        {
            var content = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var httpResponseMessage = await HttpClient.PostAsync(url, httpContent);
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}
