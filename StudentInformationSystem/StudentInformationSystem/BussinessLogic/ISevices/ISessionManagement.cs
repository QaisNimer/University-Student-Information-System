namespace StudentInformationSystem.BussinessLogic.ISevices
{
    public interface ISessionManagement
    {
        void StoreSession(string Key, string Value);
        string GetSession(string Key);
        void RemoveSession();
    }
}
