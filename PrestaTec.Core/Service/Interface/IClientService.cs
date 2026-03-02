using PrestaTec.Core.Entities;
namespace PrestaTec.Core.Service.Interface;

public interface IClientService
{
    Client CreateNewClient(int id);
    bool FindClientById(int id,List<Client> clients);
    void GetClientFullInfo(int clientId, List<Loan>list);
    void GetAllClients(List<Client> list);
}