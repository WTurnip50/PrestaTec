using PrestaTec.Core.Entities;
using PrestaTec.Core.Manager.Interface;
using PrestaTec.Core.Service.Interface;

namespace PrestaTec.Core.Manager;

public class LoanManager : ILoanManager
{
    private readonly ILoanService _service;

    public LoanManager(ILoanService service)
    {
        _service = service;
    }
    
    public Loan SetNewLoan(Loan loan)
    {
        return _service.SetNewLoan(loan);
    }
}