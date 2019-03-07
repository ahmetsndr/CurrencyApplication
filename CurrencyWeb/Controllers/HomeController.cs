using Currency.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrencyWeb.Controllers
{
    public class HomeController : Controller
    {
        public CurrencyDBContext context = new CurrencyDBContext();
        
        public ActionResult CurrencyList()
        {
            List<CurrencyWeb.Models.CurrencyWebModel> modelList = new List<CurrencyWeb.Models.CurrencyWebModel>();
            using (SqlConnection connection = new SqlConnection())
            {
                String sql = @"SELECT  * FROM Currencies";
                connection.ConnectionString = @"Data Source=(local)\SQLEXPRESS; Initial Catalog=CurrencyDBConnectionString; Integrated Security=True;";
                DataTable datatable = new DataTable();
                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = new SqlCommand(sql, connection);
                dataadapter.Fill(datatable);

                foreach (DataRow row in datatable.Rows)
                {
                    var currency = new CurrencyWeb.Models.CurrencyWebModel();
                    currency.Id = Convert.ToInt32(row["Id"].ToString());
                    currency.CrossOrder = row["CrossOrder"].ToString();
                    currency.Kod = row["Kod"].ToString();
                    currency.CurrencyCode = row["CurrencyCode"].ToString();
                    currency.CurrencyName = row["CurrencyName"].ToString();
                    currency.Unit = row["Unit"].ToString();
                    currency.Isim = row["Isim"].ToString();
                    currency.ForexBuying = row["ForexBuying"].ToString();
                    currency.ForexSelling = row["ForexSelling"].ToString();
                    currency.BanknoteBuying = row["BanknoteBuying"].ToString();
                    currency.BanknoteSelling = row["BanknoteSelling"].ToString();
                    currency.CrossRateUSD = row["CrossRateUSD"].ToString();
                    currency.CrossRateOther = row["CrossRateOther"].ToString();
                    currency.Date = Convert.ToDateTime(row["Date"].ToString());
                    modelList.Add(currency);
                }
            }
            return View(modelList);
        }

        
        public ActionResult CurrencyEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var currency = context.Currency.SingleOrDefault(m => m.Id == id);
            if (currency == null)
            {
                return HttpNotFound();
            }

            Models.CurrencyWebModel currencyModel = new Models.CurrencyWebModel
            {
                Id = currency.Id,
                Isim = currency.Isim,
                Unit = currency.Unit,
                Kod = currency.Kod,
                CurrencyCode = currency.CurrencyCode,
                CurrencyName = currency.CurrencyName,
                CrossOrder = currency.CrossOrder,
                ForexBuying = currency.ForexBuying,
                ForexSelling = currency.ForexSelling,
                BanknoteBuying = currency.BanknoteBuying,
                BanknoteSelling = currency.BanknoteSelling,
                CrossRateOther = currency.CrossRateOther,
                CrossRateUSD = currency.CrossRateUSD,
                Date = currency.Date
            };
            return View(currencyModel);
        }

        [HttpPost]
        public ActionResult CurrencyEdit([Bind(Include = " Id, Isim, Date, Unit, CrossOrder, CurrencyName, CurrencyCode, ForexBuying, ForexSelling, BanknoteBuying, BanknoteSelling, CrossRateUSD, CrossRateOther, Kod")] Currency.Data.Entities.Currency currency)
        {
            context.Entry(currency).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("CurrencyList");
        }
    }
}