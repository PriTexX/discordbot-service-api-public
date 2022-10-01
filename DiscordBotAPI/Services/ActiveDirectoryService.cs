using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.Versioning;

namespace DiscordBotAPI.services;

[SupportedOSPlatform("windows")]
public class ActiveDirectoryService : IActiveDirectoryService
{
    public string? LoginUser(string login, string password)
    {

        var insPrincipalContext =
            new PrincipalContext(ContextType.Domain, "test.domain.ru", "readad@test.ru", "test");
        if (insPrincipalContext.ValidateCredentials(login, password))
        {
            //Обрезание имени если нужно
            var loginName = login.IndexOf('@') != -1 ? login.Split("@")[0] : login;

            var user = new UserPrincipal(insPrincipalContext);
            var search = (DirectorySearcher)new PrincipalSearcher(user).GetUnderlyingSearcher();

            search.Filter = $"(&(sAMAccountType=805306368)(samaccountname={loginName}))";
            
            search.PropertiesToLoad.Clear();
            search.PropertiesToLoad.Add("employeenumber");
            
            var searchUser = search.FindOne();
            var guid = searchUser?.Properties["employeenumber"][0].ToString();
            
            return guid;
        }

        return null;
    }
}