using Newtonsoft.Json;

namespace Company.Integration.CompanyA.Models;

public class Officer
{
    [JsonProperty("first_name")]
    public string? FirstName { get; set; }

    [JsonProperty("last_name")]
    public string? LastName { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("date_from")]
    public FullDate? DateFrom { get; set; }

    [JsonProperty("date_to")]
    public FullDate? DateTo { get; set; }

    [JsonProperty("role")]
    public string? Role { get; set; }

    [JsonProperty("date_of_birth")]
    public FullDate? DateOfBirth { get; set; }
}