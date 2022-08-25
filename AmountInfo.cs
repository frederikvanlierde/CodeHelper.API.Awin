using System.Text.Json.Serialization;

namespace CodeHelper.API.Awin
{
    public class AmountInfo
    {
        #region Properties
        [JsonPropertyName("amount")] public double Amount { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; }

        #endregion

        #region Constructors
        public AmountInfo() { }
        #endregion
    }
}
