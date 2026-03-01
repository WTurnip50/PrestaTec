using PrestaTec.Core.Entities;

namespace PrestaTec.Core.Service.Interface;

public interface ILoanService
{
    Loan SetNewLoan(Loan loan, int clientId);
    
}