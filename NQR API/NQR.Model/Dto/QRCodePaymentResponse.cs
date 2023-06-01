using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class QRCodePaymentResponse
    {

        public string? ReturnCode { get; set; }

        public string? SessionID { get; set; }

        public string? NameEnquiryRef { get; set; }

        public string? DestinationInstitutionCode { get; set; }

        public string? ChannelCode { get; set; }

        public string? BeneficiaryAccountName { get; set; }

        public string? BeneficiaryAccountNumber { get; set; }

        public string? BeneficiaryKYCLevel { get; set; }

        public string? BeneficiaryBankVerificationNumber { get; set; }

        public string? OriginatorAccountName { get; set; }

        public string? OriginatorAccountNumber { get; set; }

        public string? OriginatorBankVerificationNumber { get; set; }

        public string? OriginatorKYCLevel { get; set; }

        public string? TransactionLocation { get; set; }

        public string? Narration { get; set; }

        public string? PaymentReference { get; set; }

        public string? Amount { get; set; }

        public string? InstitutionNumber { get; set; }

        public string? Mch_no { get; set; }

        public string? Sub_mch_no { get; set; }

        public string? PayerBankNumber { get; set; }

        public string? PayerAccountName { get; set; }

        public string? PayerAccountNumber { get; set; }

        public string? PayerAccountBVN { get; set; }

        public string? PayerAccountLevel { get; set; }

        public string? MerchantBankNumber { get; set; }

        public string? MerchantAccountName { get; set; }

        public string? MerchantAccountNumber { get; set; }

        public string? MerchantAccountBVN { get; set; }

        public string? MerchantAccountLevel { get; set; }
    }

}
