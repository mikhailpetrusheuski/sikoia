using Newtonsoft.Json;

namespace Company.Integration.CompanyB.Models;

public class CompanyBResponse
{
    [JsonProperty("companyNumber")]
    public string? CompanyNumber { get; set; }

    [JsonProperty("companyName")]
    public string? CompanyName { get; set; }

    [JsonProperty("country")]
    public string? Country { get; set; }

    [JsonProperty("dateFrom")]
    public string? DateFrom { get; set; }

    [JsonProperty("dateTo")]
    public string? DateTo { get; set; }

    [JsonProperty("address")]
    public string? Address { get; set; }

    [JsonProperty("activities")]
    public List<Activity>? Activities { get; set; }

    [JsonProperty("relatedPersons")]
    public List<RelatedPerson>? RelatedPersons { get; set; }

    [JsonProperty("relatedCompanies")]
    public List<RelatedCompany>? RelatedCompanies { get; set; }
}