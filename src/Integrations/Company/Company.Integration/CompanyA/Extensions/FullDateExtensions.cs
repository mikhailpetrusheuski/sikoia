using Company.Integration.CompanyA.Models;

namespace Company.Integration.CompanyA.Extensions;

public static class FullDateExtensions
{
    public static string? ToFormattedDate(this FullDate? date)
    {
        if (date?.Day != null && date is { Month: not null, Year: not null })
        {
            return $"{date.Day.Value:D2}/{date.Month.Value:D2}/{date.Year.Value}";
        }

        return null;
    }
}
