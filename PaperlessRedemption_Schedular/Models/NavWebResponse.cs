using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRedemption_Schedular.Models
{
    public  class NavWebResponse
    {
        public string No { get; set; }
        public string AccountNo{ get; set; }
        public string ClientID{ get; set; }
        public string ClientName { get; set; }
        public string FundCode { get; set; }
        public string Price { get; set; }
        public string NoOfUnits { get; set; }
        public string Amount { get; set; }
        public string DividendPaid { get; set; }
        public string TotalAmountPayable { get; set; }
        public string ValueDate { get; set; }
        public string TransactionDate { get; set; }
        public List<string>BankName { get; set; }
        public List<string> BankSortCode { get; set; }
        public string BankAccountNo { get; set; }
        public string BankAccountName { get; set; }
        public string NetAmountPayable { get; set; }
        public string RedemptionType { get; set; }
    }

    public class Parent
    {
        public List<NavWebResponse> Lines { get; set; }
        public string  Text { get; set; }
    }
}
