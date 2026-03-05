using PrestaTec.Core.Entities;
namespace PrestaTec.Core.Manager.Interface;

public interface IClientManager
{
    Client SetNewClient(Client client);
    void GetClientInfo(int clientId,List<Loan>list);
    public bool FindClientById(int clientId, List<Client> list);
    void ShowAllClients(List<Client> list);
}