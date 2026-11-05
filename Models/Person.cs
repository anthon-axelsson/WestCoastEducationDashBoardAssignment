using System;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Models;

public class Person
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("personalNumber")]
    public string PersonalNumber { get; set; } = string.Empty;

    [JsonPropertyName("phoneNumber")]
    public long PhoneNumber { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;

    [JsonPropertyName("postalCode")]
    public int PostalCode { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;
    public virtual string GetDetails()
    {
        return $"{FirstName} {LastName} ({PersonalNumber})";
    }
}