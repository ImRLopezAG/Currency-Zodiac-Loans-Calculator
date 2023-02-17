namespace Application.ViewModels;

public class CurrencyVM : BaseVM {
  public double Amount { get; set; }
  public string FromCurrency { get; set; }

  public string ToCurrency { get; set; }

  public double Result { get; set; }

}
