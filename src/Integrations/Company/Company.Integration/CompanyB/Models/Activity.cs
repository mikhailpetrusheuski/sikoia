using Newtonsoft.Json;

namespace Company.Integration.CompanyB.Models;

public class Activity
{
    [JsonProperty("activityCode")]
    public int? ActivityCode { get; set; }

    [JsonProperty("activityDescription")]
    public string? ActivityDescription { get; set; }
}