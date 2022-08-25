# CodeHelper.API.Awin
The Awin API helps businesses save time by automating their daily tasks. It provides advertiser-specific endpoints as well as publisher-specific endpoints.For more information and a list of endpoints available, please see the detailed documentation pages below.

## Question?
* AWin API <https://wiki.awin.com/index.php/API>
* Frederik van Lierde <https://twitter.com/@frederik_vl/>
* GitHub <https://github.com/frederikvanlierde/CodeHelper.API.Awin>
* NuGet <https://www.nuget.org/packages/CodeHelper.API.Awin>

## Version
* 1.1.0 : Get Transactions, Get Transaction by IDS (+ split of AwinHelper into AwinHelperPublisher and AwinHelperAdvertiser)
* 1.0.0 : Get Accounts, Get Promotions, Get Programs

## Methods

* AwinHelperAdvertiser.GetTransactionsByIds(string ids, string timezone = TimeZones.UTC) : Pull a list of transactions deatils for the given IDs
* AwinHelperAdvertiser.GetTransactions(string startDate, string endDate, string timezone, string dateType = TransActionDateTypes.Transaction, string publisherID = "", string transactionStatus = TransactionStatusses.All) : Pull a list of transactions
* AwinHelper.GetAccounts(string publisherAccountType = PublisherAccountTypes.Advertiser) : Returns a list of your Accounts

* AwinHelperPublisher.GetTransactionsByIds(string ids, string timezone = TimeZones.UTC) : Pull a list of transactions deatils for the given IDs
* AwinHelperPublisher.GetTransactions(string startDate, string endDate, string timezone, string dateType = TransActionDateTypes.Transaction, string advertiserID = "", string transactionStatus = TransactionStatusses.All) : Pull a list of transactions
* AwinHelperPublisher.GetPrograms(string filterCountryID ="", string relationship = MembershipTypes.All, bool includeHidden=true) : Returns a list of Prorgrammes All, Joined, NotJoined
* AwinHelperPublisher.GetPromotionsAsync(PromotionSearchFilter filters) : Returns a list of Promotions, based on the search options
* AwinHelper.GetAccounts(string publisherAccountType = PublisherAccountTypes.Publisher) : Returns a list of your Accounts

* AwinHelper.GetAccounts(string publisherAccountType = PublisherAccountTypes.All) : Returns a list of your Accounts


## Authentication
The Awin API provides access to a range of information from your publisher or advertiser accounts. To make sure your data is safe, all of our API endpoints require an oauth2 access token. This token is not linked to a certain publisher or advertiser account, but to your own personal user account. 

To obtain your token visit <https://ui.awin.com/awin-api> or click on the "API credentials" link in your user menu:

## Usage
To guarantee smooth operation for all our publishers and advertisers, we currently have a throttling in place that limits the number of API requests to 20 API calls per minute per user.

## Upgrade from V1.0.0 to V1.1.0
In version 1.0.0, only AwinHelper class was available.   In V1.1.0 We have split into AwinHelperPublisher and AwinHelperAdvertsier.
As i V1.0.0 we only had methods for Publishers, you need only chaneg your code from **AwinHelper** to **AwinHelperPublisher**
