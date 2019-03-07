using Currency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyService
{
    class Program
    {
        static void Main(string[] args)
        {
            Timers();
        }

        public static void Timers()
        {
            Timer t = new Timer(TimerCallback, null, 0, 1000 * 60 * 5);
            Console.ReadLine();
        }

        private static void TimerCallback(object state)
        {
            Console.Write(" " + DateTime.Now);
            // XML dosyasından okunan verileri CurrentcyDTO nesnesine çevirir ve liste olarak döner
            List<Currency.Data.CurrencyDTO> currencyList = GetToday();
            Currency.Data. DBOperations dbOperation = new Currency.Data.DBOperations();
            try
            {
                foreach (var a in currencyList)
                {
                    dbOperation.saveCurrency(a);
                }
                Console.WriteLine("  Successful..");
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occurred during the operation. {0}", e.Message);
            }
        }

        public static List<CurrencyDTO> GetToday()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            var Tarih_Date_Nodes = xml.SelectSingleNode("//Tarih_Date"); // Count değerini almak için ana boğumu seç.
            var CurrencyNodes = Tarih_Date_Nodes.SelectNodes("//Currency"); // ana boğum altındaki currency boğumunu seçiyoruz.

            List<CurrencyDTO> dovizler = new List<CurrencyDTO>();
            for (int i = 0; i < 12; i++)  //ilk 12 kur verisini alıyoruz.
            {
                var cn = CurrencyNodes[i];

                dovizler.Add(new CurrencyDTO
                {
                    CrossOrder = cn.Attributes["CrossOrder"].Value,
                    Kod = cn.Attributes["Kod"].Value,
                    CurrencyCode = cn.Attributes["CurrencyCode"].Value,
                    Unit = cn.ChildNodes[0].InnerXml,
                    Isim = cn.ChildNodes[1].InnerXml,
                    CurrencyName = cn.ChildNodes[2].InnerXml,
                    ForexBuying = cn.ChildNodes[3].InnerXml,
                    ForexSelling = cn.ChildNodes[4].InnerXml,
                    BanknoteBuying = cn.ChildNodes[5].InnerXml,
                    BanknoteSelling = cn.ChildNodes[6].InnerXml,
                    CrossRateUSD = cn.ChildNodes[7].InnerXml,
                    CrossRateOther = cn.ChildNodes[8].InnerXml
                });
            }
            return dovizler;
        }
    }
}
