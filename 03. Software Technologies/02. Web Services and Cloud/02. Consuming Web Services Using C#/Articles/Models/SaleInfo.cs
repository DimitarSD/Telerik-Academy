namespace Articles.Models
{
    using Newtonsoft.Json;

    public class SaleInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("saleability")]
        public string Saleability { get; set; }

        [JsonProperty("isEbook")]
        public bool IsEbook { get; set; }
    }
}
