using FluentAssertions;
using Services;

namespace UnitTests.Core.Services;

using Xunit;
using Domain.Models;
using System.Collections.Generic;

public class CompanyHelperTests
{
    [Theory]
    [InlineData("123", "ABC", "UK", "Type1", "Active", 
                "456", "DEF", "US", "Type2", "Inactive", 
                "789", "GHI", "DE", "Type3", "Inactive", 
                "321", "JKL", "CA", "Type4", "Active",
                "654", "MNO", "AU", "Type5", "Active",
                "654", "MNO", "AU", "Type5", "Inactive")]
    public void MergeCompanyData_Should_Merge_Companies(
        string company1Number, string company1Name, string company1Jurisdiction, string company1Type, string company1Status,
        string company2Number, string company2Name, string company2Jurisdiction, string company2Type, string company2Status,
        string company3Number, string company3Name, string company3Jurisdiction, string company3Type, string company3Status,
        string company4Number, string company4Name, string company4Jurisdiction, string company4Type, string company4Status,
        string company5Number, string company5Name, string company5Jurisdiction, string company5Type, string company5Status,
        string expectedNumber, string expectedName, string expectedJurisdiction, string expectedType, string expectedStatus)
    {
        // Arrange
        var companyData = new List<Company>
        {
            new()
                { CompanyNumber = company1Number, CompanyName = company1Name, JurisdictionCode = company1Jurisdiction, CompanyType = company1Type, Status = company1Status },
            new()
                { CompanyNumber = company2Number, CompanyName = company2Name, JurisdictionCode = company2Jurisdiction, CompanyType = company2Type, Status = company2Status },
            new()
                { CompanyNumber = company3Number, CompanyName = company3Name, JurisdictionCode = company3Jurisdiction, CompanyType = company3Type, Status = company3Status },
            new()
                { CompanyNumber = company4Number, CompanyName = company4Name, JurisdictionCode = company4Jurisdiction, CompanyType = company4Type, Status = company4Status },
            new()
                { CompanyNumber = company5Number, CompanyName = company5Name, JurisdictionCode = company5Jurisdiction, CompanyType = company5Type, Status = company5Status },
        };

        // Act
        Company result = CompanyHelper.MergeCompanyData(companyData);

        // Assert
        result.Should().NotBeNull();
        result.CompanyNumber.Should().Be(expectedNumber);
        result.CompanyName.Should().Be(expectedName);
        result.JurisdictionCode.Should().Be(expectedJurisdiction);
        result.CompanyType.Should().Be(expectedType);
        result.Status.Should().Be(expectedStatus);
    }
    
    [Fact]
    public void MergeLists_Should_Correctly_Merge()
    {
        // Arrange
        var currentList = new List<RelatedPerson>
        {
            new()
                { Name = "Jim", DateFrom = "2001", Type = "Director" },
            new()
                { Name = "Pam", DateFrom = "2002", Type = "Director" },
        };
        var newList = new List<RelatedPerson>
        {
            new()
                { Name = "Jim", DateTo = "2003", Type = "Director23" },
            new()
                { Name = "Michael", DateFrom = "2004", Type = "Owner" },
        };

        // Act
        var result = CompanyHelper.MergeLists(currentList, newList);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);

        RelatedPerson jim = result.First(x => x.Name == "Jim");
        jim.DateFrom.Should().Be("2001");
        jim.DateTo.Should().Be("2003");
        jim.Type.Should().Be("Director23");

        RelatedPerson pam = result.First(x => x.Name == "Pam");
        pam.DateFrom.Should().Be("2002");
        pam.Type.Should().Be("Director");

        RelatedPerson michael = result.First(x => x.Name == "Michael");
        michael.DateFrom.Should().Be("2004");
        michael.Type.Should().Be("Owner");
    }

    [Fact]
    public void MergeObjects_Should_Correctly_Merge()
    {
        // Arrange
        RelatedPerson current = new()
            { Name = "Jim", DateFrom = "2001", Type = "Director" };
        RelatedPerson newObject = new()
            { Name = "Jim", DateTo = "2003", Type = "Director" };

        // Act
        RelatedPerson? result = CompanyHelper.MergeObjects(current, newObject);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Jim");
        result.DateFrom.Should().Be("2001");
        result.DateTo.Should().Be("2003");
        result.Type.Should().Be("Director");
    }

}