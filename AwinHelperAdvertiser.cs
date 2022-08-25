using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeHelper.API.Awin
{
    public class AwinHelperAdvertiser : AwinHelper
    {
        #region Properties
        public string AdvertiserID { get; set; } = "";
        #endregion

        #region Constrcutors
        public AwinHelperAdvertiser() { }
        #endregion
        #region Public Methods
        /// <summary>
        /// Advertisers  can pull individual transactions, to check the status of the transactions, to create own reports, and to pull additional information that can be shared between publishers and advertisers 
        /// </summary>
        /// <param name="ids">Required: numeric transaction ids, comma-separated</param>
        /// <param name="timezone">Optional: Must be from TimeZones list</param>        
        /// <returns>List<TransactionInfo> : List with deatsil of the given transactions ids</TransactionInfo></returns>
        public async Task<List<TransactionInfo>> GetTransactionsByIDs(string ids, string timezone = TimeZones.UTC)
        {
            string apiParameters = "ids=" + ids.Replace(" ", "").Trim() + "&timezone=" + timezone;
            return await base.GetTransactionsByIds(Constants.APIURL_ADVERTISER_TRANSACTIONS.Replace("{ADVERTISERID}", this.AdvertiserID) + apiParameters);
        }
        /// <summary>
        /// Advertisers can pull individual transactions, to check the status of the transactions, to create own reports, and to pull additional information that can be shared between publishers and advertisers 
        /// Please note: the maximum date range between startDate and endDate currently supported is 31 days.
        /// </summary>
        /// <param name="startDate">Required: yyyy-MM-ddThh:mm:ss</param>
        /// <param name="endDate">Required: yyyy-MM-ddThh:mm:ss</param>
        /// <param name="timezone">Required: Must be from TimeZones list</param>
        /// <param name="dateType">Optional: transaction (default) or validatione</param>
        /// <param name="publisherID">Optional : ID of the publisher you like to get the transactions from (12345 or 12345,67890 for multiple ones)</param>
        /// <param name="transactionStatus">Optional: Filter on the status of the transaction Pending, Approved, Declined, Delete, All</param>
        /// <returns>List<TransactionInfo> : List of the transactions</TransactionInfo></returns>
        public async Task<List<TransactionInfo>> GetTransactions(string startDate, string endDate, string timezone, string dateType = TransActionDateTypes.Transaction, string publisherID = "", string transactionStatus = TransactionStatusses.All)
        {
            string apiParameters = "startDate=" + startDate + "&endDate=" + endDate + "&dateType=" + dateType + "&timezone=" + timezone;
            if (!string.IsNullOrEmpty(timezone))
                apiParameters += "&timezone=" + timezone;
            if (!string.IsNullOrEmpty(timezone))
                apiParameters += "&publisherID=" + publisherID;
            if (!string.IsNullOrEmpty(transactionStatus))
                apiParameters += "&status=" + transactionStatus;

            return await base.GetTransactions(Constants.APIURL_ADVERTISER_TRANSACTIONS.Replace("{ADVERTISERID}", this.AdvertiserID) + apiParameters);
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
        /// <param name="publisherAccountType">PublisherAccountTypes (string) All ¦ Publisher ¦ Advertiser (default)</param>
        /// <returns>Account Search Results</returns>
        public override async Task<PublisherAccountResult> GetAccounts(string publisherAccountType = PublisherAccountTypes.Advertiser)
        {
            return await base.GetAccounts(publisherAccountType);
        }
        #endregion
    }
}
