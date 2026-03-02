using System;
using System.Collections.Generic;
using PrestaTec.Core.Entities;
using PrestaTec.Core.Manager;
using PrestaTec.Core.Service;
namespace PrestaTec.App;

public static class Program
{
    public static void Main(string[] args)
    {
        List<Client> clients = new List<Client>();
        List<Loan> loans = new List<Loan>();
        int option = 0;
        int clientid;
        
        var clientService = new ClientService();
        var clientManager = new ClientManager(clientService);
        var loanService = new LoanService();
        var loanManager = new LoanManager(loanService);
        
        
        while (option != 5)
        {
           System.Console.WriteLine("Choose an option:");
           System.Console.WriteLine("1.Add a client");
           System.Console.WriteLine("2.Take a loan");
           System.Console.WriteLine("3.Get loan information");
           System.Console.WriteLine("4.Get client information");
           System.Console.WriteLine("5.Exit");
           option = Convert.ToInt32(Console.ReadLine());
           if (option == 1)
           {
               System.Console.WriteLine("Create a new client");
               //Calls New Client Service Method, and adds to clients list
               if (clients.Count < 1)
               {
                   Console.Clear();
                   var add = clientManager.SetNewClient(0);
                   add.Status = true;
                   clients.Add(add);
               }
               else
               {
                   Console.Clear();
                   clients.Add(clientManager.SetNewClient(clients.Count+1));
               }
           }

           if (option == 2)
           {
               //Calls new Loan Service Method and adds to loans list
               if (clients.Count < 1)
               {
                   Console.Clear();
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Please add a client");
                   Console.ForegroundColor = ConsoleColor.White;
               }
               else
               {
                   Console.Clear();
                   Console.WriteLine("Enter your id: ");
                   clientid = Convert.ToInt32(Console.ReadLine());
                   if (clientManager.FindClientById(clientid, clients))
                   {
                       if (clients[clientid].Status)
                       {
                           Console.WriteLine("Add a new loan");
                           loans.Add(loanManager.SetNewLoan(clients, clientid));
                           clients[clientid].Status = false;   
                       }
                       else
                       {
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.WriteLine("Client already has a loan");
                       }
                   }
               }
           }

           if (option == 3)
           {
               if (clients.Count < 1 && loans.Count < 1)
               {
                   Console.Clear();
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Please add a client or a new loan");
                   Console.ResetColor();
               }
               else
               {
                   System.Console.WriteLine("Get client loan information");
                   Console.WriteLine("Enter your id: "); 
                   try
                   {
                       clientid = Convert.ToInt32(Console.ReadLine());
                       if (clientManager.FindClientById(clientid, clients))
                       {
                           Console.WriteLine("Your loan information is");
                           clientManager.GetClientInfo(clientid, loans);
                       }
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine(e.Message);
                       Console.WriteLine(e);
                       throw;
                   } 
               }
           }

           if (option == 4)
           {
               //Sends Clients and loans List, Shows all info related to each client
               if (clients.Count < 1 && loans.Count < 1)
               {
                   Console.Clear();
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Please add a client or a new loan");
                   Console.ResetColor();
               }
               else
               {
                   Console.Clear();
                   Console.WriteLine("Showing all client information");
                   clientManager.ShowAllClients(clients);
               }
           }

           if (option == 5)
           {
               Console.Clear();
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Press any key to exit...");
               break;
           }
        }
    }
}

