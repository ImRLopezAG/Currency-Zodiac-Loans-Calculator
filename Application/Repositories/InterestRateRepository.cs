using Application.ViewModels;

namespace Application.Repositories;

public class InterestRateRepository {
  private InterestRateRepository() {
  }

  public static InterestRateRepository Instance { get; } = new();

  public InterestRateVM InterestRate = new();
}
