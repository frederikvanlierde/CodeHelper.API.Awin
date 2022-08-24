using System.Text.Json.Serialization;
namespace CodeHelper.API.Awin
{
    public class Region
    {
        #region Properties
        [JsonPropertyName("name")]          public string? CountryName { get; set; }
        [JsonPropertyName("countryCode")]   public string? CountryCode { get; set; }
        #endregion

        #region Constructors
        public Region() { }
        #endregion
    }
}
