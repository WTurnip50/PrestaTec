namespace PrestaTec.Core.Entities;

public class Client
{
    public int ClientId { get; set; }
    public string? FullName { get; set; }
    public float MonthlyIncome { get; set; }
    public bool Status { get; set; }//If true Loan is enabled
    
}