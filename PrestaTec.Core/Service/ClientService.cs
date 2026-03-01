using PrestaTec.Core.Entities;
using PrestaTec.Core.Service.Interface;

namespace PrestaTec.Core.Service;

public class ClientService : IClientService
{
    public Client CreateNewClient(int id)
    {
        string? name = "";
        float monthlyIncome = 0;
        bool flag = false;
        while (flag != true)
        {
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            if (name.Length == 0)
            {
                Console.WriteLine("Name cannot be empty");
                name = "";
            }
            else
            {
                while (flag!=true)
                {
                    Console.WriteLine("Enter your monthly income: ");
                    Single.TryParse(Console.ReadLine(), out monthlyIncome);
                    if (monthlyIncome <= 0)
                    {
                        Console.WriteLine("Monthly income cannot be negative or zero");
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
        }
        Console.Clear();
        var newClient = new Client
        {
            ClientId = id,
            FullName = name,
            MonthlyIncome = monthlyIncome,
            Status = true
        };
        return newClient;
    }

    public void GetClientFullInfo(int clientId,List<Loan> list)
    {
        //Here we are using LINQ(Language Integrated Query) to find the client loan data
        var result = list.Where(c => c.ClientId == clientId).ToList();
        if (result.Count == 0)
        {
            Console.WriteLine("No clients found");
        }
        else
        {
            var loan = new Loan
            {
                ClientId = clientId,
                AmountRequested = result[0].AmountRequested,
                DurationInMonths = result[0].DurationInMonths,
                AnnualInterestRate =  result[0].AnnualInterestRate,
            };
            Console.WriteLine($"Client id: {clientId}");
            Console.WriteLine($"Amount requested: {loan.AmountRequested}");
            Console.WriteLine($"Duration in months: {loan.DurationInMonths}");
        }
    }
}