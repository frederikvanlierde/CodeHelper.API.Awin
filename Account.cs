using System.Text.Json.Serialization;
namespace CodeHelper.API.Awin
{
    public class Account
    {
        #region Properties
        [JsonPropertyName("accountId")]     public int AccountId { get; set; }
        [JsonPropertyName("accountName")] public string AccountName { get; set; } = "";
        [JsonPropertyName("accountType")] public string AccountType { get; set; } = "";
        [JsonPropertyName("userRole")] public string UserRole { get; set; } = "";
        #endregion

        #region Constructors
        public Account() { }
        #endregion
    }


}
