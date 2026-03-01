using PrestaTec.Core.Entities;
namespace PrestaTec.Core.Service.Interface;

public interface IClientService
{
    Client CreateNewClient(int id);
    void GetClientFullInfo(int clientId, List<Loan>list);
}