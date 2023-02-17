using Application.Repositories;
using Application.ViewModels;

namespace Application.Services;

public class InterestRateService {

  private readonly Dictionary<string, int> _interestRates = new() {
    { "Personal", 22 },
    { "Automobile", 12 },
    { "Mortgage", 8 },
  };

  public void AddInterestRate(InterestRateVM model) {

    if (model == null) throw new ArgumentNullException(nameof(model));

    int Amount = model.Amount;
    string Type = model.Type;
    int Fees = model.Fees;

    try {
      double rate = (Amount * _interestRates[Type] / 100) + Amount;
      double monthlyRate = rate / Fees;
      double annualRate = monthlyRate * 12;

      InterestRateRepository.Instance.InterestRate = (new InterestRateVM {
        MonthlyRate = monthlyRate,
        Rate = annualRate,
        IsNull = false,
        Message = "Success",
        InterestRate = rate
      });
    } catch (Exception ex) {
      InterestRateRepository.Instance.InterestRate = (new InterestRateVM {
        IsNull = true,
        Message = ex.Message,
        MonthlyRate = 0,
        Rate = 0,
        InterestRate = 0
      });
    }
  }

  public InterestRateVM GetInterestRate() => InterestRateRepository.Instance.InterestRate;

}
