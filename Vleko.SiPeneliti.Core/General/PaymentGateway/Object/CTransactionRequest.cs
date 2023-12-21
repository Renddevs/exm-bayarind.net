using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Vleko.Bayarind.Core.Helper;
using Vleko.Bayarind.Data.Model;

namespace Vleko.Bayarind.Core.PaymentGateway
{
    public class CTransactionRequest
    {
        public string channelId { get; set; }
        public string bankId { get; set; }
        public int serviceCode { get; set; }
        public string currency { get; set; }
        public int transactionNo { get; set; }
        public int transactionAmount { get; set; }
        public DateTime transactionDate { get; set; }
        public DateTime transactionExpire {get; set;}
        public string description { get; set; }
        public string callbackURL { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public string customerPhone { get; set; }
        public string customerAddress { get; set; }
    }
}
