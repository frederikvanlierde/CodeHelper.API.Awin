using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace CodeHelper.API.Awin
{
    public class PromotionResults
    {
        #region Properties
        [JsonPropertyName("data")]          public List<PromotionInfo>? Promotions { get; set; }
        [JsonPropertyName("pagination")]    public Pagination? Pagination { get; set; }
        #endregion

        #region Constructors
        public PromotionResults() { }
        #endregion
    }
}
