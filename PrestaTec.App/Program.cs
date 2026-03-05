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
        float maxLoan;
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
                string? name = "";
                float monthlyIncome = 0;
                bool flag = false;
                Console.Clear();
                System.Console.WriteLine("Create a new client");
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
                        while (flag != true)
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

                var clientData = new Client
                {
                    ClientId = clients.Count,
                    FullName = name,
                    MonthlyIncome = monthlyIncome,
                    Status = true
                };
                clients.Add(clientManager.SetNewClient(clientData));
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

                            int months;
                            float loanAmount,  monthlyPayment = 0;
                            bool flag = false;
                            while (flag != true)
                            {
                                Console.WriteLine("Enter your loan quantity: ");
                                Single.TryParse(Console.ReadLine(), out loanAmount);
                                float income = clients[clientid].MonthlyIncome;
                                maxLoan = (income * 10); 
                                if (loanAmount > 0)
                                {
                                    Console.WriteLine($"loan {loanAmount}");
                                    
                                    if (loanAmount > maxLoan)
                                    {
                                        Console.WriteLine($"Loan amount exceeds maximum: {maxLoan}");
                                    }
                                    else
                                    {
                                        try
                                        {
                                            Console.WriteLine("Months to pay: ");
                                            months = Convert.ToInt32(Console.ReadLine());
                                            Loan loandata = new Loan { DurationInMonths = months, ClientId = clientid, AmountRequested = loanAmount };
                                            var obj = loanManager.SetNewLoan(loandata);
                                            if (obj != null)
                                            {
                                                loans.Add(obj);
                                                flag = true;
                                                clients[clientid].Status = false;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e);
                                            throw;
                                        }
                                        
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Loan amount cannot be negative or zero");
                                }
                            }
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