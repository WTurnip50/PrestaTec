using PrestaTec.Core.Entities;
namespace PrestaTec.Core.Manager.Interface;

public interface IClientManager
{
    Client SetNewClient(int id);
    void GetClientInfo(int clientId,List<Loan>list);
}