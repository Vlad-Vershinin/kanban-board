using System.Text.Json.Serialization;

namespace client_app.Models.Responses;

public class CheckResponse
{
    [JsonPropertyName("exists")]
    public bool Exists { get; set; }
}
