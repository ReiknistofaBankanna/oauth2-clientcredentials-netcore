using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace oAuth2ClientCredentials
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {

            if (args.Length != 4)
            {
                Console.WriteLine("Usage: .. adfsUrl clientId clientSecret resource");
                return;
            }

            var adfsUrl = args[0];
            var clientId = args[1];
            var clientSecret = args[2];
            var resource = args[3];

            String url = adfsUrl;

            var dict = new Dictionary<string, string>();
            dict.Add("client_id", clientId);
            dict.Add("client_secret", clientSecret);
            dict.Add("grant_type", "client_credentials");
            dict.Add("resource", resource);

            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dict) };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage res = client.SendAsync(req).Result;
                var result = res.Content.ReadAsStringAsync().Result;
                if (res.IsSuccessStatusCode)
                {
                    AuthResult authResult = JsonConvert.DeserializeObject<AuthResult>(result);
                    Console.WriteLine("Access token: {0}", authResult.AccessToken);
                    Console.WriteLine("Token type  : {0}", authResult.TokenType);
                    Console.WriteLine("Expires in  : {0}", authResult.ExpiresIn);
                }
                else
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("StatusCode  : {0}", res.StatusCode);
                    Console.WriteLine("Response    : {0}", result);
                }
            }
        }      
    }
}
