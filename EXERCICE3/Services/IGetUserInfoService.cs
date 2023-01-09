namespace EXERCICE3.Services
{
    public interface IGetUserInfoService
    {
        string GetUserName(string name);
        string  GetPasswordHash(string password);
    }
}
