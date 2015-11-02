namespace MusicStore.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class ConsoleClient
    {
        public static void Main()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:56976/")
            };

            GetAllAlbums(client);

            PostAlbum(client);

            UpdateAlbum(client);

            DeleteAlbum(client);
        }

        private static void PostAlbum(HttpClient client)
        {
            Console.WriteLine("Creating album");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", "Bedroom Summer Fashion 2015"),
                new KeyValuePair<string, string>("Year", "2015"),
                new KeyValuePair<string, string>("Producer", "DJ Mascota")
            });

            HttpResponseMessage response = client.PostAsync("api/Albums/Post", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Created");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetAllAlbums(HttpClient client)
        {
            Console.WriteLine("All albums");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Albums/get").Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(albums);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void UpdateAlbum(HttpClient client)
        {
            Console.WriteLine("Updating album");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", "That Felling"),
                new KeyValuePair<string, string>("Year", "2014"),
                new KeyValuePair<string, string>("Producer", "DJ Mascota")
            });

            HttpResponseMessage response = client.PutAsync("api/Albums/Put/1", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void DeleteAlbum(HttpClient client)
        {
            Console.WriteLine("Deleting album");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Albums/Delete/1").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
