using System.Text.Json.Serialization;
namespace CodeHelper.API.Awin
{
    public  class PublisherAccountResult
    {
        #region 
        [JsonPropertyName("userId")]    public int UserId { get; set; }
        [JsonPropertyName("accounts")] public List<Account> Accounts { get; set; } = new();
        #endregion

        #region Constructors
        public PublisherAccountResult() { }
        #endregion
    }
}
