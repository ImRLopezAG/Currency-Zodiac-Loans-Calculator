using Application.Repositories;
using Application.ViewModels;

namespace Application.Services;
public class CurrencyService
{
  private readonly Dictionary<string, int> Coin = new() {
    {"DOM", 1},
    {"USD", 55},
    {"EUR", 60},
  };
  public void AddCurrency(CurrencyVM model)
  {
    double Amount = model.Amount;
    var To = model.ToCurrency;
    bool isNull = model.IsNull;
    string Message = model.Message;
    var From = model.FromCurrency;
    try
    {
      var result = Amount * Coin[From] / Coin[To];
      CurrencyRepository.Instance.Convertion = new CurrencyVM
      {
        Result = result,
        ToCurrency = To,
        FromCurrency = From,
        IsNull = false
      };
    }
    catch (Exception e)
    {
      CurrencyRepository.Instance.Convertion = new CurrencyVM
      {
        Result = 0,
        IsNull = true,
        Message = e.Message
      };
    }
  }
  public CurrencyVM GetCurrency() => CurrencyRepository.Instance.Convertion;
}
