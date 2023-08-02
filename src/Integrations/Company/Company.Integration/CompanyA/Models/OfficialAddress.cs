using Newtonsoft.Json;

namespace Company.Integration.CompanyA.Models;

public class OfficialAddress
{
    [JsonProperty("street")]
    public string? Street { get; set; }

    [JsonProperty("city")]
    public string? City { get; set; }

    [JsonProperty("country")]
    public string? Country { get; set; }

    [JsonProperty("postcode")]
    public string? Postcode { get; set; }
}