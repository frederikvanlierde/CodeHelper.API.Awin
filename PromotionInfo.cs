using System.Text.Json.Serialization;

namespace CodeHelper.API.Awin
{
    public class PromotionInfo
    {
        #region Properties
        [JsonPropertyName("promotionId")]   public int PromotionId { get; set; }

        [JsonPropertyName("type")]      public string? Type { get; set; }

        [JsonPropertyName("advertiser")]public Advertiser? AdvertiserInfo { get; set; }

        [JsonPropertyName("title")]     public string? Title { get; set; }

        [JsonPropertyName("description")]   public string? Description { get; set; }

        [JsonPropertyName("terms")]     public string? Terms { get; set; }

        [JsonPropertyName("startDate")] public string? StartDate { get; set; }

        [JsonPropertyName("endDate")]   public string? EndDate { get; set; }

        [JsonPropertyName("url")]       public string? Url { get; set; }

        [JsonPropertyName("urlTracking")]   public string? UrlTracking { get; set; }

        [JsonPropertyName("dateAdded")] public string? DateAdded { get; set; }

        [JsonPropertyName("campaign")]  public string? Campaign { get; set; }

        [JsonPropertyName("regions")]   public Regions? Regions { get; set; }

        [JsonPropertyName("voucher")]   public VoucherInfo? Voucher { get; set; }
        #endregion

        #region Constructors
        public PromotionInfo() { }
        #endregion
    }
}
