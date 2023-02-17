$(document).ready(function() {
  const month = $('#month');
  const day = $('#day');
  const fees = $('#fees');
  const type = $('#type');
  const interest = $('#interest');

  const MonthDays = {
    January: 31,
    February: 28,
    March: 31,
    April: 30,
    May: 31,
    June: 30,
    July: 31,
    August: 31,
    September: 30,
    October: 31,
    November: 30,
    December: 31,
  };

  const Loan = {
    Personal: '22%',
    Automobile: '18%',
    Mortgage: '12%',
  };

  for (let m in MonthDays) {
    month.append(new Option(m, m));
  }

  for (let i = 12; i <= 120; i += 6) {
    fees.append(new Option(i + ' months', i));
  }

  for (let t in Loan) {
    type.append(new Option(t, t));
  }

  month.change(function() {
    if (month.val() != 'none') {
      day.empty();
      day.append(new Option('Select a day', 'none'));
      for (let i = 1; i <= MonthDays[month.val()]; i++) {
        day.append(new Option(i, i));
      }
    }
  });

  type.change(function() {
    if (type.val() != 'none') {
      const value = Loan[type.val()];
      const exactValue = `interest ${value}`;
      interest.val(`${value != undefined ? exactValue : ''}`);
    } else {
      interest.val('');
    }
  });
});
