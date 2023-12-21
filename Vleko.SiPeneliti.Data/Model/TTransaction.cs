using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Vleko.Bayarind.Data.Model 
{
    public partial class TTransaction : IEntity
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public int? ServiceCode { get; set; }
        public string Currency { get; set; }
        public int? TransactionNo { get; set; }
        public int? TransactionAmmoun { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? TransactionExpire { get; set; }
        public string Description { get; set; }
        public string CallbackUrl { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }
        public string AuthCode { get; set; }
        public int? ProcessFds { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionMessage { get; set; }
        public string FlagType { get; set; }
    }
}
