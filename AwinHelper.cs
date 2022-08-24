using System.Text.Json;
using System.Reflection;
using System;

namespace CodeHelper.API.Awin
{
    public class AwinHelper
    {
        #region Properties
        public string PublisherID { get; set; } = "";
        public string APIToken { get; set; } = "";

        [Awin("countryCode")]   public string SearchCountrID { get; set; } = "";
        [Awin("relationship")]  public string SearchRelationship { get; set; } = "";
        [Awin("includeHidden")] public string SearchIncludeHidden { get; set; } = "";
        [Awin("pagination")]    public int SearchPagination { get; set; } = 1;
        [Awin("updatedSince")] public string SearchUpdatedSince { get; set; } = ""; 


        private readonly HttpClient _httpClient = new();
        #endregion

        #region Constructors
        public AwinHelper() { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a list of Prorgrammes, based on the search options
        /// </summary>
        /// <returns>List of type ProgramInfo</returns>
        public async Task<List<Advertiser>> GetProgramsAsync()
        {
            string[] apiParameters = new string[] { "countryCode" };            
            return JsonSerializer.Deserialize<List<Advertiser>>(await GetJson(Constants.APIURL_ProgrammeInfo, apiParameters)) ?? new();
        }
        /// <summary>
        /// Returns a list of Promotions, based on the search options
        /// </summary>
        /// <returns>List of type Promotions</returns>
        public async Task<PromotionResults> GetPromotionsAsync(PromotionSearchFilter filters)
        {            
            return JsonSerializer.Deserialize<PromotionResults>(await GetJsonPost(Constants.APIURL_Promotions, filters.GetJson())) ?? new();
        }

        /// <summary>
        /// Returns a list of Accounts
        /// 
        /// With the API authenticating on user-level, you don’t have to integrate the API authentication for each individual account you have. You can use “GET accounts” to pull an up-to-date list of accounts and automatically do your needed requests for every account you have.
        /// Please note: if you add or remove your user account to or from a publisher or advertiser account, it may take up to 10 minutes until this change in access rights takes effect in the API.
        /// 
        /// Who can use it
        /// Every user that has at least one publisher or advertiser account.Please note: to use one of the other endpoints/methods to retrieve account data, you need to at least have "viewer" access to the account.
        /// </summary>
        /// <param name="publisherAccountType">PublisherAccountTypes (string) All ¦ Publisher ¦ Advertiser</param>
        /// <returns>Account Search Results</returns>
        public async Task<PublisherAccountResult> GetAccountsAsync(string publisherAccountType = PublisherAccountTypes.All)
        {
            string[] apiParameters = new string[] { "publisherAccountType" };
            return JsonSerializer.Deserialize<PublisherAccountResult>(await GetJson(Constants.APIURL_Accounts, apiParameters)) ?? new();
        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }
        #endregion

        #region Private Methods
        private async Task<string> GetJsonPost(string apiBaseUrl, HttpContent data)
        {
            SetAuthorizationHeader();
            var _task = await _httpClient.PostAsync(GetAPIUrl(apiBaseUrl), data);

            return await _task.Content.ReadAsStringAsync();
        }
        private async Task<string> GetJson(string apiBaseUrl, string[] apiParameters)
        {
            SetAuthorizationHeader();
            var _task = await _httpClient.GetAsync(GetAPIUrl(apiBaseUrl, apiParameters));
            
            return await _task.Content.ReadAsStringAsync();
        }
        private void SetAuthorizationHeader()
        { 
            if(!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.APIToken);
        }
        private string GetAPIUrl(string baseAPIUrl, string[]? parameters = null)
        {
            baseAPIUrl = baseAPIUrl.Replace("{PUBLISHERID}", this.PublisherID);
            string _queryString = "?";
            if(parameters!= null && parameters.Length > 0)
            {
                PropertyInfo? field;
                List<PropertyInfo> properties = this.GetType().GetProperties().Where(p => p.GetCustomAttribute(typeof(AwinAttribute)) != null).ToList();
                foreach (string _p in parameters)
                {
                    field = properties.SingleOrDefault(p => ((AwinAttribute)p.GetCustomAttribute(typeof(AwinAttribute))).AwinField == _p,null);
                    if (field != null)
                        _queryString += ((AwinAttribute)field.GetCustomAttribute(typeof(AwinAttribute))).AwinField + "=" + field.GetValue(this) + "&";
                }
                if (_queryString.Length > 0)
                    _queryString =  _queryString[0..^1];
            }
            return baseAPIUrl + _queryString;
        }
        #endregion    
    }
}
