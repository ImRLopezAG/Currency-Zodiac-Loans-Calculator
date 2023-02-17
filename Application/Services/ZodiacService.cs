using Application.Repositories;
using Application.ViewModels;

namespace Application.Services;

public class ZodiacService
{
  private readonly Dictionary<string, int[]> _zodiacDays = new(){
    { "Aries", new[] { 21, 19 } },
    { "Taurus", new[] { 20, 20 } },
    { "Gemini", new[] { 21, 20 } },
    { "Cancer", new[] { 21, 22 } },
    { "Leo", new[] { 23, 22 } },
    { "Virgo", new[] { 23, 22 } },
    { "Libra", new[] { 23, 22 } },
    { "Scorpio", new[] { 23, 21 } },
    { "Sagittarius", new[] { 22, 21 } },
    { "Capricorn", new[] { 22, 19 } },
    { "Aquarius", new[] { 20, 18 } },
    { "Pisces", new[] { 19, 20 } },
  };
  private readonly Dictionary<string, string[]> _zodiacMonths = new() {
    {"Aries", new[] { "March", "April" } },
    {"Taurus", new[] { "April", "May" } },
    {"Gemini", new[] { "May", "June" } },
    {"Cancer", new[] { "June", "July" } },
    {"Leo", new[] { "July", "August" } },
    {"Virgo", new[] { "August", "September" } },
    {"Libra", new[] { "September", "October" } },
    {"Scorpio", new[] { "October", "November" } },
    {"Sagittarius", new[] { "November", "December" } },
    {"Capricorn", new[] { "December", "January" } },
    {"Aquarius", new[] { "January", "February" } },
    {"Pisces", new[] { "February", "March" } },
  };


  public void AddZodiac(ZodiacVM model)
  {
    string month = model.Month;
    int day = model.Day;
    bool isNull = model.IsNull;
    string message = model.Message;

    try
    {
      var zodiac = _zodiacDays.FirstOrDefault(zd => month == _zodiacMonths[zd.Key][0] && day >= zd.Value[0] || month == _zodiacMonths[zd.Key][1] && day <= zd.Value[1]);
      model.Sign = zodiac.Key ?? "Unknown";
      ZodiacRepository.Instance.Zodiac = model;
    }
    catch (Exception ex)
    {
      ZodiacRepository.Instance.Zodiac = (new ZodiacVM
      {
        IsNull = true,
        Message = ex.Message,
        Sign = "Unknown"
      });
    }
  }

  public ZodiacVM GetZodiac() => ZodiacRepository.Instance.Zodiac;
}
