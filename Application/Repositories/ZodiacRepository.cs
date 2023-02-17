using Application.ViewModels;

namespace Application.Repositories;

public class ZodiacRepository {
  private ZodiacRepository() {
  }

  public static ZodiacRepository Instance { get; } = new();

  public ZodiacVM Zodiac = new();
}
