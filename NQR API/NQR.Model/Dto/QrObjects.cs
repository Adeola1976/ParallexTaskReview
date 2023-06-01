using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class QrObjects
    {
        public string MessageStart { get; set; }
        public string FixedOrDynamic { get; set; }
        public string InstNoPlusforwdNoPlusMerchNo { get; set; }
        //public string MerchantNumber { get; set; }
        // public string ReverseDomnPlusSubMertNoPlusOrderNo { get; set; }
        //public string ReserverDomain { get; set; }
        public string SubMerchntNo { get; set; }
        public string OderNoForDynamice { get; set; }
        public string CountryCode { get; set; }
        public string MerchantCategryCode { get; set; }
        public string CurrencyNumber { get; set; }
        public string MerchantName { get; set; }
        // public string CityName { get; set; }
        public string Amount { get; set; }
        //  public string EndOfMessage { get; set; }
        // public string CRC16 { get; set; }
        public int CanChangeAmount { get; set; }
    }
}
