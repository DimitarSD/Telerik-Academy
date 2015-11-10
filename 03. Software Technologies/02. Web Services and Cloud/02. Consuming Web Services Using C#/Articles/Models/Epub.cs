namespace Articles.Models
{
    using Newtonsoft.Json;

    public class Epub
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
