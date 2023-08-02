using Newtonsoft.Json;

namespace Company.Integration.CompanyA.Models;

public class FullDate
{
    [JsonProperty("year")]
    public int? Year { get; set; }

    [JsonProperty("month")]
    public int? Month { get; set; }

    [JsonProperty("day")]
    public int? Day { get; set; }
}