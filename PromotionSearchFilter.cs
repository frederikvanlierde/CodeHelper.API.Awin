using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;
namespace CodeHelper.API.Awin
{
    public class PromotionSearchFilter : BaseAwinClass
    {
        #region Properties
        [JsonPropertyName("filters")] public PromotionFilters Filters { get; set; } = new();
        [JsonPropertyName("pagination")] public Pagination Pagination { get; set; } = new();
        #endregion

        #region Constructors
        public PromotionSearchFilter() { }
        #endregion

        #region Public Methods
        public HttpContent GetJsonString()
        {
            return new StringContent(JsonSerializer.Serialize(this), System.Text.Encoding.UTF8, "application/json");
        }
        #endregion
    }
}
