namespace PrestaTec.Core.Entities;

public class Loan
{
    public int ClientId { get; set; }
    public float AmountRequested { get; set; }
    public int DurationInMonths { get; set; }
    public float monthlyPayment { get; set; }
    public float total { get; set; }
    public float AnnualInterestRate { get; set; }//Defined by the system
}