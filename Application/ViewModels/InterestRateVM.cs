namespace Application.ViewModels;

public class InterestRateVM : BaseVM {
  public double InterestRate { get; set; }

  public int Amount { get; set; }
  public string Type { get; set; }

  public int Fees { get; set; }

  public double Rate { get; set; }

  public double MonthlyRate { get; set; }

}
