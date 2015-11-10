namespace Articles.Models
{
    using Newtonsoft.Json;

    public class Pdf
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
