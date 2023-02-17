using Application.ViewModels;

namespace Application.Repositories;

public class CurrencyRepository {
  private CurrencyRepository() {
  }
  public static CurrencyRepository Instance { get; } = new();

  public CurrencyVM Convertion = new();
}
