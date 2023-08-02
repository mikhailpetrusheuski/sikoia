using Company.Integration.CompanyA.Models;

namespace Company.Integration.CompanyA.Extensions;

public static class OfficialAddressExtensions
{
    public static string? ToFormattedAddress(this OfficialAddress? officialAddress)
    {
        if (officialAddress == null)
        {
            return null;
        }
        
        var parts = new List<string?>
        {
            officialAddress.Street,
            officialAddress.City,
            officialAddress.Country,
            officialAddress.Postcode
        };

        return string.Join(", ", parts.Where(part => !string.IsNullOrWhiteSpace(part)));
    }
}
