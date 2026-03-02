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
            if (name.Length == 0 || name.IsWhiteSpace())
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

    public bool FindClientById(int id, List<Client> clients)
    {
        var result = clients.Where(c => c.ClientId == id).ToList();
        if (result.Count == 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No clients found");
            Console.ResetColor();
            return false;
        }
        return true;
    }

    public void GetClientFullInfo(int clientId,List<Loan> list)
    {
        //Here we are using LINQ(Language Integrated Query) to find the client loan data
        var result = list.Where(c => c.ClientId == clientId).ToList();
        if (result.Count == 0)
        {
            Console.WriteLine("There are no active loans for the customer");
        }
        else
        {
            var loan = new Loan
            {
                ClientId = clientId,
                AmountRequested = result[0].AmountRequested,
                DurationInMonths = result[0].DurationInMonths,
                AnnualInterestRate =  result[0].AnnualInterestRate,
                monthlyPayment = result[0].monthlyPayment,
            };
            Console.WriteLine($"Client id: {clientId}");
            Console.WriteLine($"Amount requested: {loan.AmountRequested}");
            Console.WriteLine($"Duration in months: {loan.DurationInMonths}");
            Console.WriteLine($"MonthlyPayment: {loan.monthlyPayment}");
        }
    }

    public void GetAllClients(List<Client> list)
    {
        foreach (var client in list)  
        {
            Console.WriteLine("----------");
            Console.WriteLine("Client id: " + client.ClientId);
            Console.WriteLine("Client Name: " + client.FullName);
            Console.WriteLine("Client Monthly Income: " + client.MonthlyIncome);
            if (client.Status)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Client Status: Active");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Client Status: Inactive");
                Console.ResetColor();
            }
            Console.WriteLine("----------");
        }
    }
}