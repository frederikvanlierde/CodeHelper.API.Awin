using System.Text.Json;
using System.Net.Http;
namespace CodeHelper.API.Awin
{
    public class BaseAwinClass
    {
        #region Constructors
        public BaseAwinClass() { }
        #endregion

        #region Public Methods
        public HttpContent GetJson()
        {
            return new StringContent(JsonSerializer.Serialize(this), System.Text.Encoding.UTF8, "application/json");
        }
        #endregion
    }
}
