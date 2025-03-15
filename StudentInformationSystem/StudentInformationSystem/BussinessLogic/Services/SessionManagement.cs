using StudentInformationSystem.BussinessLogic.ISevices;
using System.Text;

namespace StudentInformationSystem.BussinessLogic.Services
{
    public class SessionManagement: ISessionManagement
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string classname ;
        

        public SessionManagement(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this.classname = "SessionManagement";


        }

        public string GetSession(string Key)
        {
            string returnValue = string.Empty;
            try
            {
                Byte[] value;
                _httpContextAccessor.HttpContext.Session.TryGetValue(Key, out value);
                returnValue = Encoding.Default.GetString(value);
            }
            catch (Exception ex)
            {
            }
            return returnValue;
        }

        public void StoreSession(string Key, string Value)
        {
            _httpContextAccessor.HttpContext.Session.Set(Key, Encoding.UTF8.GetBytes(Value));
        }

        public void RemoveSession()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
