namespace PrestaTec.Core.Entities;

public class Loan
{
    public float AmountRequested { get; set; }
    public int DurationInMonths { get; set; }
    public float AnnualInterestRate { get; set; }//Defined by the system
}