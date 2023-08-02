namespace Domain.Models;

public class Company
{
    public string? CompanyNumber { get; set; }
    public string? CompanyName { get; set; }
    public string? JurisdictionCode { get; set; }
    public string? CompanyType { get; set; }
    public string? Status { get; set; }
    public List<Officer>? Officers { get; set; }
    public List<Owner>? Owners { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public string? Address { get; set; }
    public List<Activity>? Activities { get; set; }
    public List<RelatedPerson>? RelatedPersons { get; set; }
    public List<RelatedCompany>? RelatedCompanies { get; set; }
}