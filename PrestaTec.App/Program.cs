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
                   clients.Add(clientManager.SetNewClient(0));
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
                   System.Console.WriteLine("Get a loan");
               }
           }

           if (option == 3)
           {
               if (clients.Count < 1 && loans.Count < 1)
               {
                   Console.Clear();
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Please add a client or a new loan");
                   Console.ForegroundColor = ConsoleColor.White;
               }
               else
               {
                   System.Console.WriteLine("Get client loan information");
                   Console.WriteLine("Enter your id: "); 
                   try
                   {
                       clientid = Convert.ToInt32(Console.ReadLine());
                       clientManager.GetClientInfo(clientid, loans);
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
               System.Console.WriteLine("Get all client information");
               //Sends Clients and loans List, Shows all info related to each client
               
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

