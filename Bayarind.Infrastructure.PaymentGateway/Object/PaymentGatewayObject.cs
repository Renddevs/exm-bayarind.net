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
        public class InsertTransactionObject
        {
            public string channelId { get; set; }
            public string serviceCode { get; set; }
            public string currency { get; set; }
            public int transactionNo { get; set; }
            public decimal transactionAmmount { get; set; }
            public decimal transactionFee { get; set; }
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
    }
}
