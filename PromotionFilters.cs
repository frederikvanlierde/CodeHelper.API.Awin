using System;
namespace CodeHelper.API.Awin
{
    public class PromotionFilters
    {
        #region Properties
        [Awin("advertiserIds")] public string[]? AdvertiserIds { get; set; }
        [Awin("exclusiveOnly")] public bool ExclusiveOnly { get; set; } = false;
        [Awin("membership")] public string Membership { get; set; } = MembershipTypes.All;
        [Awin("regionCodes")] public string[]? RegionCodes { get; set; }
        [Awin("status")] public PromotionStatusses Status { get; set; } = PromotionStatusses.active;
        [Awin("type")] public PromotionTypes PromotionType { get; set; } = PromotionTypes.All;
        [Awin("updatedSince")] public DateTime? UpdatedSince { get; set; }

        #endregion

        #region Constructors
        public PromotionFilters() { }
        #endregion

        
    }
}
