using PrestaTec.Core.Entities;
namespace PrestaTec.Core.Service.Interface;

public interface IClientService
{
    Client CreateNewClient(Client client);
    bool FindClientById(int id,List<Client> clients);
    void GetClientFullInfo(int clientId, List<Loan>list);
    void GetAllClients(List<Client> list);
}