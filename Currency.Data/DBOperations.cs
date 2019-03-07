using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data
{
    public class DBOperations
    {
        CurrencyDBContext context;

        public int saveCurrency(CurrencyDTO a)
        {
            context = new CurrencyDBContext();
            Currency.Data.Entities.Currency currency = new Currency.Data.Entities.Currency()
            {
                Isim = a.Isim,
                Unit = a.Unit,
                Kod = a.Kod,
                CurrencyCode = a.CurrencyCode,
                CurrencyName = a.CurrencyName,
                CrossOrder = a.CrossOrder,
                ForexBuying = a.ForexBuying,
                ForexSelling = a.ForexSelling,
                BanknoteBuying = a.BanknoteBuying,
                BanknoteSelling = a.BanknoteSelling,
                CrossRateOther = a.CrossRateOther,
                CrossRateUSD = a.CrossRateUSD,
                Date = DateTime.Now,
            };
            context.Currency.Add(currency);
            return context.SaveChanges(); 
        }
    }
}
