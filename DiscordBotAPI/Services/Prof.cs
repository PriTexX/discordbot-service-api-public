using System.ServiceModel;
using StudProf;

namespace DiscordBotAPI.services;

public class Prof : IDisposable
{
    internal WebExchangeLKPortTypeClient Client1C { get; set; }
    internal void Connection()
    {
        BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
        basicHttpBinding.MaxReceivedMessageSize = 65535 * 3000;
        basicHttpBinding.SendTimeout = new TimeSpan(0, 60, 0);
        basicHttpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
        basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
        EndpointAddress endpointAddress = new EndpointAddress("http://111.12.1.11/test/LK.1cws?");
        Client1C = new WebExchangeLKPortTypeClient(basicHttpBinding, endpointAddress);
        Client1C.ClientCredentials.UserName.UserName = "testUserName";
        Client1C.ClientCredentials.UserName.Password = "testPassword";
    }

    public void Dispose()
    {
        Client1C.Close();
    }

    public GetUsersComposition GetStudentData(string personGuid)
    {
        var data = Client1C.GetUsers(personGuid, null, null, null);
        var student = data.First(d => d.СтатусСтудента.Наименование == "Является студентом");
        return student;
    }
}