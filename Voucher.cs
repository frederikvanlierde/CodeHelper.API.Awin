using System.Text.Json.Serialization;
namespace CodeHelper.API.Awin
{
    public class VoucherInfo
    {
        #region Properties
        [JsonPropertyName("code")]          public string Code { get; set; }
        [JsonPropertyName("exclusive")]     public bool Exclusive { get; set; }
        [JsonPropertyName("attributable")]  public bool Attributable { get; set; }
        #endregion

        #region Constructors
        public VoucherInfo() { }
        #endregion
    }
}
