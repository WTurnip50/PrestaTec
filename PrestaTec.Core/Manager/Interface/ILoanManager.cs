using PrestaTec.Core.Entities;
namespace PrestaTec.Core.Manager.Interface;

public interface ILoanManager
{
    Loan SetNewLoan(Loan loan);
    
}