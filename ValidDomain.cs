using System.Text.Json.Serialization;
namespace CodeHelper.API.Awin
{
    public class ValidDomain
    {
        #region Properties
        [JsonPropertyName("domain")] public string? Domain { get; set; }
        #endregion

        #region Constructors
        public ValidDomain() { }
        #endregion
    }
}
