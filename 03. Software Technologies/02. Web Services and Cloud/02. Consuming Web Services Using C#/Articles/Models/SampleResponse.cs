namespace Articles.Models
{
    using Newtonsoft.Json;

    public class SampleResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
}
