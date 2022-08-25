using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace CodeHelper.API.Awin
{

    public class Advertiser
    {
        #region Properties
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("clickThroughUrl")] public string? ClickThroughUrl { get; set; }
        [JsonPropertyName("displayUrl")] public string? DisplayUrl { get; set; }
        [JsonPropertyName("logoUrl")] public string? LogoUrl { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("currencyCode")] public string? CurrencyCode { get; set; }
        [JsonPropertyName("primaryRegion")] public Region? PrimaryRegion { get; set; }
        [JsonPropertyName("status")] public string? Status { get; set; }
        [JsonPropertyName("validDomains")] public List<ValidDomain>? ValidDomains { get; set; }
        [JsonPropertyName("joined")]        public bool Joined { get; set; }
        #endregion

        #region Constructors
        public Advertiser() { }
        #endregion
    }


}
