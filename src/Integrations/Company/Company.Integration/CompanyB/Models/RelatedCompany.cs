using Newtonsoft.Json;

namespace Company.Integration.CompanyB.Models;

public class RelatedCompany
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("dateFrom")]
    public string? DateFrom { get; set; }

    [JsonProperty("dateTo")]
    public string? DateTo { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("ownership")]
    public string? Ownership { get; set; }

    [JsonProperty("country")]
    public string? Country { get; set; }
}