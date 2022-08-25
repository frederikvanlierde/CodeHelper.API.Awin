# CodeHelper.API.Awin
The Awin API helps businesses save time by automating their daily tasks. It provides advertiser-specific endpoints as well as publisher-specific endpoints.For more information and a list of endpoints available, please see the detailed documentation pages below.

## Question?
* AWin API <https://wiki.awin.com/index.php/API>
* Frederik van Lierde <https://twitter.com/@frederik_vl/>
* GitHub <https://github.com/frederikvanlierde/CodeHelper.API.Awin>
* NuGet <https://www.nuget.org/packages/CodeHelper.API.Awin>

## Version
* 1.0.0 : Get Accounts, Get Promotions, Get Programs

## Methods
* AwinHelper.GetProgramsAsync() : Returns a list of Prorgrammes All, Joined, NotJoined
* AwinHelper.GetPromotionsAsync(PromotionSearchFilter filters) : Returns a list of Promotions, based on the search options
* AwinHelper.GetAccountsAsync(string publisherAccountType = PublisherAccountTypes.All) : Returns a list of your Accounts

## Authentication
The Awin API provides access to a range of information from your publisher or advertiser accounts. To make sure your data is safe, all of our API endpoints require an oauth2 access token. This token is not linked to a certain publisher or advertiser account, but to your own personal user account. 

To obtain your token visit <https://ui.awin.com/awin-api> or click on the "API credentials" link in your user menu:

## Usage
To guarantee smooth operation for all our publishers and advertisers, we currently have a throttling in place that limits the number of API requests to 20 API calls per minute per user.
