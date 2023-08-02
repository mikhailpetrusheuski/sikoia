using Newtonsoft.Json;

namespace Company.Integration.CompanyA.Models;

public class Owner
{
    [JsonProperty("first_name")]
    public string? FirstName { get; set; }

    [JsonProperty("middlenames")]
    public string? MiddleNames { get; set; }

    [JsonProperty("last_name")]
    public string? LastName { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("date_from")]
    public FullDate? DateFrom { get; set; }

    [JsonProperty("date_to")]
    public FullDate? DateTo { get; set; }

    [JsonProperty("ownership_type")]
    public string? OwnershipType { get; set; }

    [JsonProperty("shares_held")]
    public double? SharesHeld { get; set; }

    [JsonProperty("date_of_birth")]
    public FullDate? DateOfBirth { get; set; }
}