using PrestaTec.Core.Entities;

namespace PrestaTec.Core.Service.Interface;

public interface ILoanService
{
    Loan SetNewLoan(int clientId,List<Client>clients);
    
    
}