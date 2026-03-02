using PrestaTec.Core.Entities;
using PrestaTec.Core.Manager.Interface;
using PrestaTec.Core.Service.Interface;

namespace PrestaTec.Core.Manager;

public class ClientManager : IClientManager
{
    private readonly IClientService _service;
    public ClientManager(IClientService service)
    {
        _service = service;
    }
    public Client SetNewClient(int id)
    {
        return _service.CreateNewClient(id);
    }

    public void GetClientInfo(int clientId, List<Loan> list)
    {
        _service.GetClientFullInfo(clientId, list);
    }

    public bool FindClientById(int clientId, List<Client> list)
    {
        return _service.FindClientById(clientId, list);
       
    }

    public void ShowAllClients(List<Client> list)
    {
        _service.GetAllClients(list);
    }
}