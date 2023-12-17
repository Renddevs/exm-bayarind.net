using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bayarind.Infrastructure.PaymentGateway.Object
{
    internal class PaymentGatewayObject
    {
        public enum PaymentMethodEnum
        {
            KAS_BAYARIND,
            CREDIT_CARD,
            DEBIT_CARD,
            ONE_KLIK
        }

        public class TransactionRequest
        {
            public string channelId { get; set; }
            public string serviceCode { get; set; }
            public string currency { get; set; }
            public int transactionNo { get; set; }
            public int transactionAmmount { get; set; }
            public int transactionFee { get; set; }
            public DateTime transactionDate { get; set; }
            public DateTime transactionExpire { get; set; }
            public string callbackUrl { get; set; }
            public string description { get; set; }
            public string itemDetails { get; set; }
            public string customerAccount { get; set; }
            public string customerName { get; set; }
            public string customerEmail { get; set; }
            public string customerPhone { get; set; }
            public string customerBillAddress { get; set; }
            public string customerBillCity { get; set; }
            public string customerBillCountry { get; set; }
            public string customerBillState { get; set; }
            public string customerBillZipCode { get; set; } 
            public string authCode { get; set; }
            public string sellerUrl { get; set; }
            public string sellerIdNumber { get; set;}
        }

        public class TransactionResponse
        { 
            public string chanellId { get; set; }
            public string currency { get; set; }
            public string insertStatus { get; set; }
            public string insertMessage { get; set; }
            public string insertId { get; set; }
            public string redirectUrl { get; set; }
            public string redirectData { get; set; }
            public string paymentCode { get; set; }
            public string urlQris { get; set; }
            public string appPaymentUrl { get; set; }
            public string deeplink { get; set; }
            public string additionalData { get; set; }
            //public string promoInfo { get; set; }
            public int isPromo { get; set; }
            public string promoCode { get; set; }
            public string promoMessage { get; set; }
            public string message { get; set; }
            public string id { get; set; }
            public string en { get; set; }
            public int promoAmmont { get; set; }
            public int totalAmmount { get; set; }
            public string voucher { get; set; }
            public int continueIfRuleNotMatch { get; set; }
        }

        public class PaymentFlagRequest 
        {
            public string channelId { get; set; }
            public string currency { get; set; }
            public string transactionNo { get; set; }
            public int transactionAmmount { get; set; }
            public DateTime transactionDate { get; set; }
            public string channelType { get; set; }
            public TransactionFeatureObject transactionFeature { get; set; }
            public string transactionStatus { get; set; }
            public string transactionMessage { get; set; }
            public string customerAccount { get; set; }
            public string cardNo { get; set; }
            public string cardToken { get; set; }
            public string cardTokenUse { get; set; }
            public string flagType { get; set; }
            public int insertId { get; set; }
            public string paymentReffId { get; set; }
            public PaymentMethodEnum paymentMethod { get; set; }
            public string authCode { get; set; }
            public string additionalData { get; set; }
            public string filterCode { get; set; }
        }

        public class TransactionFeatureObject
        {
            public string tag_id { get; set; }
            public string bank_issuer { get; set; }
            public string bank_issuer_country { get; set; }
            public string card_brand { get; set; }
            public int card_expiry { get; set; }
            public string card_type { get; set; }
            public string card_level { get; set; }
            public int card_is_corporate { get; set; }
            public string hashed_card_no { get; set; }
            public string acquirer_type { get; set; }
            public string adapter { get; set; }
            public string adapter_data { get; set; }
            public string promo { get; set; }
        }

        public class PaymentFlagResponse
        { 
            public string channelId { get; set; }
            public string currency { get; set; }
            public string paymentStatus { get; set; }
            public string paymentMessage { get; set; }
            public int flagType { get; set; }
            public string paymentReffId { get; set; }
        }
    }
}
