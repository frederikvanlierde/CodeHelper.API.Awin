using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;

namespace CodeHelper.API.Awin
{
    public class AwinHelperPublisher : AwinHelper
    {
        #region Properties
        public string PublisherID { get; set; } = "";
        #endregion

        #region Constrcutors
        public AwinHelperPublisher() { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Publishers can pull individual transactions, to check the status of the transactions, to create own reports, and to pull additional information that can be shared between publishers and advertisers 
        /// Please note: the maximum date range between startDate and endDate currently supported is 31 days.
        /// </summary>
        /// <param name="startDate">Required: yyyy-MM-ddThh:mm:ss</param>
        /// <param name="endDate">Required: yyyy-MM-ddThh:mm:ss</param>
        /// <param name="timezone">Required: Must be from TimeZones list</param>
        /// <param name="dateType">Optional: transaction (default) or validatione</param>
        /// <param name="advertiserID">Optional : ID of the advertiser you like to get the transaction from (12345 or 12345,67890 for multiple ones)</param>
        /// <param name="transactionStatus">Optional: Filter on the status of the transaction Pending, Approved, Declined, Delete, All</param>
        /// <returns>List<TransactionInfo> : List of the transactions</TransactionInfo></returns>
        public async Task<List<TransactionInfo>> GetTransactions(string startDate, string endDate, string timezone, string dateType = TransActionDateTypes.Transaction, string advertiserID = "", string transactionStatus = TransactionStatusses.All)
        {
            string apiParameters = "startDate=" + startDate + "&endDate=" + endDate + "&dateType=" + dateType + "&timezone=" + timezone;
            if (!string.IsNullOrEmpty(timezone))
                apiParameters += "&timezone=" + timezone;
            if (!string.IsNullOrEmpty(timezone))
                apiParameters += "&advertiserID=" + advertiserID;
            if (!string.IsNullOrEmpty(transactionStatus))
                apiParameters += "&status=" + transactionStatus;

            return await base.GetTransactions(Constants.APIURL_PUBLISHER_TRANSACTIONS.Replace("{PUBLISHERID}", this.PublisherID) + apiParameters);            
        }

        /// <summary>
        /// Publishers can pull individual transactions, to check the status of the transactions, to create own reports, and to pull additional information that can be shared between publishers and advertisers 
        /// </summary>
        /// <param name="ids">Required: numeric transaction ids, comma-separated</param>
        /// <param name="timezone">Optional: Must be from TimeZones list</param>        
        /// <returns>List<TransactionInfo> : List with deatsil of the given transactions ids</TransactionInfo></returns>
        public async Task<List<TransactionInfo>> GetTransactionsByIDs(string ids, string timezone = TimeZones.UTC)
        {
            string apiParameters = "ids=" + ids.Replace(" ","").Trim() + "&timezone=" + timezone;
            return await base.GetTransactionsByIds(Constants.APIURL_PUBLISHER_TRANSACTIONBYIDS.Replace("{PUBLISHERID}", this.PublisherID) + apiParameters);
        }

        /// <summary>
        /// Returns a list of Programs, based on the search options
        /// </summary>
        /// <param name="filterCountryID">Optional: the country code</param>
        /// <param name="relationship">Optional: All (default),Joined, NotJoined, Pending, Rejected, Suspended</param>
        /// /// <param name="includeHidden">Optional: true (default) or fale</param>
        /// <returns>List of type ProgramInfo</returns>
        public async Task<List<Advertiser>> GetPrograms(string filterCountryID ="", string relationship = MembershipTypes.All, bool includeHidden=true)
        {
            string apiParameters = includeHidden ? "includeHidden=true" : "&includeHidden=false";
            apiParameters += string.IsNullOrEmpty(filterCountryID) ? "" : "&countryCode=" + filterCountryID;
            apiParameters += string.IsNullOrEmpty(relationship) ? "" : "&relationship=" + relationship;
            
            return JsonSerializer.Deserialize<List<Advertiser>>(await GetJson(Constants.APIURL_ProgrammeInfo.Replace("{PUBLISHERID}", this.PublisherID) + apiParameters)) ?? new();
        }
        /// <summary>
        /// Returns a list of Promotions, based on the search options
        /// </summary>
        /// <returns>List of type Promotions</returns>
        public async Task<PromotionResults> GetPromotions(PromotionSearchFilter filters)
        {
            return JsonSerializer.Deserialize<PromotionResults>(await GetJsonPost(Constants.APIURL_Promotions.Replace("{PUBLISHERID}", this.PublisherID), filters.GetJsonString())) ?? new();
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
        /// <param name="publisherAccountType">PublisherAccountTypes (string) All ¦ Publisher (default) ¦ Advertiser</param>
        /// <returns>Account Search Results</returns>
        public override async Task<PublisherAccountResult> GetAccounts(string publisherAccountType = PublisherAccountTypes.Publisher)
        {
            return await base.GetAccounts(publisherAccountType);            
        }
        #endregion
        #region Private Methods
        private string GetAPIUrl(string baseAPIUrl, string[]? parameters = null)
        {
            baseAPIUrl = baseAPIUrl.Replace("{PUBLISHERID}", this.PublisherID);
            string _queryString = "?";
            if (parameters != null && parameters.Length > 0)
            {
                PropertyInfo? field;
                List<PropertyInfo> properties = this.GetType().GetProperties().Where(p => p.GetCustomAttribute(typeof(AwinAttribute)) != null).ToList();
                foreach (string _p in parameters)
                {
                    field = properties.SingleOrDefault(p => ((AwinAttribute)p.GetCustomAttribute(typeof(AwinAttribute))).AwinField == _p, null);
                    if (field != null)
                        _queryString += ((AwinAttribute)field.GetCustomAttribute(typeof(AwinAttribute))).AwinField + "=" + field.GetValue(this) + "&";
                }
                if (_queryString.Length > 0)
                    _queryString = _queryString[0..^1];
            }
            return baseAPIUrl + _queryString;
        }
        #endregion

    }
}
