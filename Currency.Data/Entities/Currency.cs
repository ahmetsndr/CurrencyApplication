using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data.Entities 
{
    [Table("Currencies")]
    public class Currency
    {
        [Key]
        [Column("ID", TypeName = "INTEGER")]
        int id;

        [Column("ID", TypeName = "VARCHAR")]
        string crossOrder;

        [Column("ID", TypeName = "VARCHAR")]
        string kod;

        [Column("ID", TypeName = "VARCHAR")]
        string currencyCode;

        [Column("ID", TypeName = "VARCHAR")]
        string unit;

        [Column("ID", TypeName = "VARCHAR")]
        string isim;

        [Column("ID", TypeName = "VARCHAR")]
        string currencyName;

        [Column("ID", TypeName = "VARCHAR")]
        string forexBuying;

        [Column("ID", TypeName = "VARCHAR")]
        string forexSelling;

        [Column("ID", TypeName = "VARCHAR")]
        string banknoteBuying;

        [Column("ID", TypeName = "VARCHAR")]
        string banknoteSelling;

        [Column("ID", TypeName = "VARCHAR")]
        string crossRateUSD;

        [Column("ID", TypeName = "VARCHAR")]
        string crossRateOther;

        [Column("ID", TypeName = "DateTime2")]
        DateTime date;

        public int Id { get => id; set => id = value; }
        public string CrossOrder { get => crossOrder; set => crossOrder = value; }
        public string Kod { get => kod; set => kod = value; }
        public string CurrencyCode { get => currencyCode; set => currencyCode = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Isim { get => isim; set => isim = value; }
        public string CurrencyName { get => currencyName; set => currencyName = value; }
        public string ForexBuying { get => forexBuying; set => forexBuying = value; }
        public string ForexSelling { get => forexSelling; set => forexSelling = value; }
        public string BanknoteBuying { get => banknoteBuying; set => banknoteBuying = value; }
        public string BanknoteSelling { get => banknoteSelling; set => banknoteSelling = value; }
        public string CrossRateUSD { get => crossRateUSD; set => crossRateUSD = value; }
        public string CrossRateOther { get => crossRateOther; set => crossRateOther = value; }
        public DateTime Date { get => date; set => date = value; }

    }
}
