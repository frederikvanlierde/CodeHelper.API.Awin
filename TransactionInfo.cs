using System.Text.Json.Serialization;
using System;
namespace CodeHelper.API.Awin
{
    public class TransactionInfo
    {
        #region Properties
        [JsonPropertyName("id")] public int TransactionId { get; set; }
        [JsonPropertyName("url")] public string  Url { get; set; }
        [JsonPropertyName("advertiserId")] public int AdvertiserId { get; set; }
        [JsonPropertyName("commissionSharingPublisherId")] public string CommissionSharingPublisherId { get; set; }
        [JsonPropertyName("commissionSharingSelectedRatePublisherId")] public string CommissionSharingSelectedRatePublisherId { get; set; }
        [JsonPropertyName("campaign")] public string Campaign { get; set; }
        [JsonPropertyName("siteName")] public string SiteName { get; set; }
        [JsonPropertyName("commissionStatus")] public string CommissionStatus { get; set; }

        [JsonPropertyName("commissionAmount")] public AmountInfo CommissionAmount { get; set; } = new();
        [JsonPropertyName("saleAmount")] public AmountInfo SaleAmount { get; set; } = new();
        [JsonPropertyName("ipHash")] public string IPHash { get; set; }
        [JsonPropertyName("customerCountry")] public string CustomerCountry { get; set; }
        [JsonPropertyName("clickDate")] public DateTime ClickDate { get; set; }
        [JsonPropertyName("transactionDate")] public DateTime TransactionDate { get; set; }
        [JsonPropertyName("validationDate")] public DateTime? ValidationDate { get; set; }
        [JsonPropertyName("type")] public string CommissionType { get; set; }
        [JsonPropertyName("declineReason")] public string DeclineReason { get; set; }
        [JsonPropertyName("voucherCodeUsed")] public bool VoucherCodeUsed { get; set; }
        [JsonPropertyName("voucherCode")] public string VoucherCode { get; set; }
        [JsonPropertyName("amended")] public bool Amended { get; set; }
        [JsonPropertyName("amendReason")] public string AmendReason { get; set; }
        [JsonPropertyName("clickDevice")] public string clickDevice { get; set; }
        [JsonPropertyName("transactionDevice")] public string transactionDevice { get; set; }
        [JsonPropertyName("publisherUrl")] public string PublisherUrl { get; set; }
        [JsonPropertyName("advertiserCountry")] public string AdvertiserCountry { get; set; }
        [JsonPropertyName("orderRef")] public string OrderRef { get; set; }
        #endregion

        #region Constructors
        public TransactionInfo() { }
        #endregion
    }
}
