namespace Articles
{
    using System.IO;
    using System.Net;

    using Articles.Models;
    using Newtonsoft.Json;

    public class GoogleBooksApiConsumer
    {
        private const string QueryString = "https://www.googleapis.com/books/v1/volumes?q={0}&maxResults={1}&key=AIzaSyCPtdYm7kpbdI5FAysIr3LiJwVjzRIivd4";

        public SampleResponse GetVolumes(string searchPattern, int count)
        {
            var queryString = BuildQueryString(searchPattern, count);
            var request = HttpWebRequest.Create(queryString);

            using (var responseStream = request.GetResponse().GetResponseStream())
            {
                using (var reader = new StreamReader(responseStream))
                {
                    var apiResult = JsonConvert.DeserializeObject<SampleResponse>(reader.ReadToEnd());
                    return apiResult;
                }
            }
        }

        private static string BuildQueryString(string query, int count)
        {
            var fullQueryString = string.Format(QueryString, query, count);
            return fullQueryString;
        }
    }
}
