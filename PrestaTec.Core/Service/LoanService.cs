using PrestaTec.Core.Entities;
using PrestaTec.Core.Service.Interface;

namespace PrestaTec.Core.Service;

public class LoanService : ILoanService
{
    public Loan SetNewLoan(int clientId,List<Client>clients)
    {
        int months = 0;
        float loanAmount = 0, maxLoan,monthlyPayment = 0,monthlyInterestRate, total;
        bool flag = false;
        var result = clients.Where(client => client.ClientId == clientId).ToList();
            while (flag!=true)
            {
                Console.WriteLine("Enter your loan quantity: ");
                Single.TryParse(Console.ReadLine(),out loanAmount);
                if (loanAmount > 0)
                {
                    maxLoan = loanAmount * 10;
                    if (loanAmount >= maxLoan)
                    {
                        Console.WriteLine($"Loan amount exceeds maximum: {maxLoan}");
                    }
                    else
                    {
                        while (flag!=true)
                        {
                            Console.WriteLine("Months to pay: ");
                            months = Convert.ToInt32(Console.ReadLine());
                            if (loanAmount <= 10000 && loanAmount >0)
                            {
                                if (months > 0 && months < 12)
                                {
                                    monthlyInterestRate = 0.08f / 12;
                                    total = loanAmount + (loanAmount * monthlyInterestRate *months);
                                    monthlyPayment = total / months;
                                    flag = true;
                                    break;
                                }
                            }

                            if (loanAmount > 10000 && loanAmount <= 20000)
                            {
                                if (months > 0 && months < 24)
                                {
                                    monthlyInterestRate = 0.08f / 12;
                                    total = loanAmount + (loanAmount * monthlyInterestRate *months);
                                    monthlyPayment = total / months;
                                    flag = true;
                                    break;
                                }
                            }
                            if (loanAmount > 20000)
                            {
                                if (months > 0 && months < 36)
                                {
                                    monthlyInterestRate = 0.08f / 12;
                                    total = loanAmount + (loanAmount * monthlyInterestRate *months);
                                    monthlyPayment = total / months;
                                    flag = true;
                                    break;
                                }
                            }
                            Console.WriteLine("Months exceded");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You don't have enough loan amount");
                }
            }

            var loan = new Loan
            {
                ClientId = clientId,
                monthlyPayment = monthlyPayment,
                DurationInMonths = months,
                AmountRequested = loanAmount,
                AnnualInterestRate = 0.08f
            };
        return loan;
    }
}