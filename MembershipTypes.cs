using System;
namespace CodeHelper.API.Awin
{
    public struct MembershipTypes
    {
        #region Properties
        public const string All = "all";
        public const string Pending = "pending";
        public const string Suspended = "suspended";
        public const string Rejected = "rejected";
        public const string Joined = "joined";
        public const string NotJoined = "notJoined";
        #endregion
    }
}