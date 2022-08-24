using System.Text.Json.Serialization;
namespace CodeHelper.API.Awin
{
    public class Pagination
    {
        #region Properties
        [JsonPropertyName("page")]      public int Page { get; set; } = 1;
        [JsonPropertyName("pageSize")]  public int PageSize { get; set; }
        [JsonPropertyName("total")]     public int Total { get; set; }
        #endregion 

        #region constructors
        public Pagination() { }
        #endregion
    }
}
