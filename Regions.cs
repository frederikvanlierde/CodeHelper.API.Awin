using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace CodeHelper.API.Awin
{
    
    public class Regions
    {
        [JsonPropertyName("all")]
        public bool All { get; set; }

        [JsonPropertyName("list")]
        public List<Region>? List { get; set; }

        #region constructors
        public Regions() { }
        #endregion
    }
}
