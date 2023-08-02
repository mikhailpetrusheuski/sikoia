using System.Reflection;
using Domain.Models;

namespace Services;

public class CompanyHelper
{
    public static Company MergeCompanyData(List<Company> companyData)
    {
        Company mergedCompany = new();

        foreach (Company company in companyData)
        {
            mergedCompany.CompanyNumber = SelectLonger(mergedCompany.CompanyNumber, company.CompanyNumber);
            mergedCompany.CompanyName = SelectLonger(mergedCompany.CompanyName, company.CompanyName);
            mergedCompany.JurisdictionCode = SelectLonger(mergedCompany.JurisdictionCode, company.JurisdictionCode);
            mergedCompany.CompanyType = SelectLonger(mergedCompany.CompanyType, company.CompanyType);
            mergedCompany.Status = SelectLonger(mergedCompany.Status, company.Status);
            
            mergedCompany.Officers = MergeLists(mergedCompany.Officers, company.Officers);
            mergedCompany.Owners = MergeLists(mergedCompany.Owners, company.Owners);

            mergedCompany.DateFrom = SelectLonger(mergedCompany.DateFrom, company.DateFrom);
            mergedCompany.DateTo = SelectLonger(mergedCompany.DateTo, company.DateTo);
            mergedCompany.Address = SelectLonger(mergedCompany.Address, company.Address);

            mergedCompany.Activities = MergeLists(mergedCompany.Activities, company.Activities);
            mergedCompany.RelatedPersons = MergeLists(mergedCompany.RelatedPersons, company.RelatedPersons);
            mergedCompany.RelatedCompanies = MergeLists(mergedCompany.RelatedCompanies, company.RelatedCompanies);
        }

        return mergedCompany;
    }

    private static string? SelectLonger(string? current, string? newString)
    {
        if (newString == null)
        {
            return current;
        }

        if (current == null)
        {
            return newString;
        }

        return current.Length > newString.Length ? current : newString;
    }

    internal static List<T>? MergeLists<T>(List<T>? current, List<T>? newList) where T : class
    {
        if (newList == null || newList.Count == 0)
        {
            return current;
        }

        if (current == null || current.Count == 0)
        {
            return newList;
        }

        var result = new List<T?>();
        var addedItems = new Dictionary<string, T?>();
        foreach (T? item in current.Concat(newList))
        {
            if (typeof(T).GetProperty("Name")?.GetValue(item) is not string key)
            {
                result.Add(item);
            }
            else if (addedItems.TryGetValue(key, out T? existingItem))
            {
                // If an item with the same name is already in the result, merge them.
                if (existingItem == null)
                {
                    continue;
                }
                result.Remove(existingItem);
                result.Add(MergeObjects(existingItem, item));
            }
            else
            {
                // If the item isn't in the result yet, add it.
                addedItems.Add(key, item);
                result.Add(item);
            }
        }

        return result;
    }

    internal static T? MergeObjects<T>(T? current, T? newObject) where T : class
    {
        if (newObject == null)
        {
            return current;
        }

        if (current == null)
        {
            return newObject;
        }

        Type type = typeof(T);
        var mergedObject = Activator.CreateInstance(type);

        foreach (PropertyInfo prop in type.GetProperties())
        {
            if (prop.PropertyType == typeof(string))
            {
                var currentVal = prop.GetValue(current) as string;
                var newVal = prop.GetValue(newObject) as string;
                prop.SetValue(mergedObject, SelectLonger(currentVal, newVal));
            }
        }

        return mergedObject as T;
    }
}