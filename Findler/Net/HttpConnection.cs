using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace Findler.Net
{
    public class HttpConnection
    {
        HttpClient client;

        public HttpConnection()
        {
            client = new HttpClient();
        }

        public async Task<string> requestByGet(string url)
        {
            Uri uri = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(uri);
            string rta = await response.Content.ReadAsStringAsync();
            return rta;
        }

        public async Task<string> requestByJsonPost(string url, string json)
        {
            Uri uri = new Uri(url);
            HttpStringContent content = new HttpStringContent(json);
            //Debemos especificar el tipo de contenido a enviar
            HttpMediaTypeHeaderValue contentType = new HttpMediaTypeHeaderValue("application/json");
            content.Headers.ContentType = contentType;
            //Ya podemos hacer el request
            HttpResponseMessage response = await client.PostAsync(uri, content);
            //Convertimos la respuesta en una cadena de texto
            string rta = await response.Content.ReadAsStringAsync();
            return rta;
        }

        public async Task<string> requestByFormPost(string url, List<KeyValuePair<string, string>> form)
        {
            Uri uri = new Uri(url);

            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(form);
            HttpMediaTypeHeaderValue contentType = new HttpMediaTypeHeaderValue("application/x-www-urlencoded");
            content.Headers.ContentType = contentType;
            HttpResponseMessage response = await client.PostAsync(uri, content);
            string rta = await response.Content.ReadAsStringAsync();
            return rta;
        }
    }
}
