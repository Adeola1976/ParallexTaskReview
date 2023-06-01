using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRedemption_Schedular.Models
{
    public class AutoMatchTransaction
    {
        public class AutoMatchStpPaymentTransaction
        {
            public int id { get; set; }
            public string customerReference { get; set; }
            public string customerName { get; set; }
            public string transactionReference { get; set; }
            public string narration { get; set; }
            public string amount { get; set; }
            public string amountRaised { get; set; }
            public string source { get; set; }
            public int payableBankConfigId { get; set; }
            public DateTime? filedToBankAt { get; set; }
            public DateTime transactionDate { get; set; }
            public string status { get; set; }
            public DateTime? responseReceivedAt { get; set; }
            public string paymentResponseMessage { get; set; }
            public int paymentStatus { get; set; }
            public int isFiledToBank { get; set; }
            public string currency { get; set; }
            public int isValidForPayOut { get; set; }
            public int isCustomerBalanceSufficient { get; set; }
            public string customerBankCode { get; set; }
            public string customerBankAccountNo { get; set; }
            public string customerBankName { get; internal set; }
            public string disburstmentAccountNo { get; set; }
            public string disburstmentBank { get; set; }
            public int isRequiredApproval { get; set; }
            public int isApprovedForPayment { get; set; }
            public string approvedBy { get; set; }
            public int? activityNotification { get; set; }
            public int isActive { get; set; }

        }
    }
}
