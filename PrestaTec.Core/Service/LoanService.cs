using PrestaTec.Core.Entities;
using PrestaTec.Core.Service.Interface;

namespace PrestaTec.Core.Service;

public class LoanService : ILoanService
{
    public Loan SetNewLoan(Loan loan)
    {
        float monthlyInterestRate;
        float total = 0;
        float montlyPayment = 0;
        int months = 0;
        if (loan.AmountRequested > 0 && loan.AmountRequested <=10000)
        {
            if (loan.DurationInMonths > 0 && loan.DurationInMonths <= 12)
            {
                months = loan.DurationInMonths;
                monthlyInterestRate = 0.08f / 12;
                total = loan.AmountRequested + ( loan.AmountRequested * monthlyInterestRate * loan.DurationInMonths);
                montlyPayment = total / loan.AmountRequested;
            }
            else
            {
                Console.WriteLine("Months exceded");
                return null;
            }
        }
        else if (loan.AmountRequested > 0 && loan.AmountRequested <=20000)
        {
            if (loan.DurationInMonths > 0 && loan.DurationInMonths <= 24)
            {
                months = loan.DurationInMonths;
                monthlyInterestRate = 0.08f / 12;
                total = loan.AmountRequested + ( loan.AmountRequested * monthlyInterestRate * loan.DurationInMonths);
                montlyPayment = total / loan.AmountRequested;
            }else
            {
                Console.WriteLine("Months exceded");
                return null;
            }
        }
        else if (loan.AmountRequested > 20000)
        {
            if (loan.DurationInMonths > 0 && loan.DurationInMonths <= 36)
            {
                months = loan.DurationInMonths;
                monthlyInterestRate = 0.08f / 12;
                total = loan.AmountRequested + ( loan.AmountRequested * monthlyInterestRate * loan.DurationInMonths);
                montlyPayment = total / loan.AmountRequested;
            }else
            {
                Console.WriteLine("Months exceded");
                return null;
            }
        }

        var newloan = new Loan
        {
            ClientId = loan.ClientId,
            monthlyPayment = montlyPayment,
            total = total,
            DurationInMonths = months,
            AmountRequested = loan.AmountRequested,
            AnnualInterestRate = 0.08f
        };
        return newloan;
    }
}