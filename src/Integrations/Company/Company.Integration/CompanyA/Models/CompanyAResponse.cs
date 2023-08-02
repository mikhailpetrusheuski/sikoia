using Newtonsoft.Json;

namespace Company.Integration.CompanyA.Models;

public class CompanyAResponse
{
    [JsonProperty("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonProperty("company_name")]
    public string? CompanyName { get; set; }

    [JsonProperty("jurisdiction_code")]
    public string? JurisdictionCode { get; set; }

    [JsonProperty("company_type")]
    public string? CompanyType { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("date_established")]
    public FullDate? DateEstablished { get; set; }

    [JsonProperty("date_dissolved")]
    public FullDate? DateDissolved { get; set; }

    [JsonProperty("official_address")]
    public OfficialAddress? OfficialAddress { get; set; }

    [JsonProperty("officers")]
    public List<Officer>? Officers { get; set; }

    [JsonProperty("owners")]
    public List<Owner>? Owners { get; set; }  
}