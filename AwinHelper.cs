using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeHelper.API.Awin
{
    public class AwinHelper
    {
        #region Properties
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
        public virtual async Task<PublisherAccountResult> GetAccounts(string publisherAccountType = PublisherAccountTypes.All)
        {
            string apiParameters = string.IsNullOrEmpty(publisherAccountType) ? "" : "type=" + publisherAccountType;
            return JsonSerializer.Deserialize<PublisherAccountResult>(await GetJson(Constants.APIURL_Accounts + apiParameters)) ?? new();
        }        

        public void Dispose()
        {
            _httpClient.Dispose();
        }
        #endregion

        #region Private Methods        
        private void SetAuthorizationHeader()
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.APIToken);
        }

        #endregion

        #region Protected Methods
        protected async Task<List<TransactionInfo>> GetTransactions(string apiUrl)
        {
            return JsonSerializer.Deserialize<List<TransactionInfo>>(await GetJson(apiUrl)) ?? new();
        }
        protected async Task<List<TransactionInfo>> GetTransactionsByIds(string apiUrl)
        {
            return JsonSerializer.Deserialize<List<TransactionInfo>>(await GetJson(apiUrl)) ?? new();
        }
        protected async Task<string> GetJson(string apiURL)
        {
            SetAuthorizationHeader();
            var _task = await _httpClient.GetAsync(apiURL);
            return await _task.Content.ReadAsStringAsync();
        }

        protected async Task<string> GetJsonPost(string apiURL, HttpContent data)
        {
            SetAuthorizationHeader();
            var _task = await _httpClient.PostAsync(apiURL, data);

            return await _task.Content.ReadAsStringAsync();
        }     
        #endregion
    }
}
