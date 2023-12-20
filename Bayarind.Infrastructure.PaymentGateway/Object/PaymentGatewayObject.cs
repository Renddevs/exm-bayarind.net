using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bayarind.Infrastructure.PaymentGateway.Object
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
        public int? serviceCode { get; set; }
        public string currency { get; set; }
        public int? transactionNo { get; set; }
        public int? transactionAmount { get; set; }
        public string transactionFee { get; set; }
        public List<AdditionalFeeObject> additionafee { get; set; }
        public DateTime transactionDate { get; set; }
        public DateTime transactionExpire { get; set; }
        public TransactionFeatureObject transactionFeature { get; set; }
        public List<DiscountObject> discount { get; set; }
        public int? tenor { get; set; }
        public string promoCode { get; set; }
        public string allowedBin { get; set; }
        public int? installmentCode { get; set; }
        public string reward { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string branch { get; set; }
        public string other { get; set; }
        public int? disablePromo { get; set; }
        public string callbackURL { get; set; }
        public string description { get; set; }
        public List<ItemDetailObject> itemDetails { get; set; }
        public string customerAccount { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public string customerPhone { get; set; }
        public string customerBillAddress { get; set; }
        public string customerBillCity { get; set; }
        public string customerBillCountry { get; set; }
        public string customerBillState { get; set; }
        public string customerBillZipCode { get; set; }
        public string customerIp { get; set; }
        public int? cardNo { get; set; }
        public int? cardExpiryYear { get; set; }
        public string cardExpiryMonth { get; set; }
        public string cardSecurityCode { get; set; }
        public string cardType { get; set; }
        public string cardToken { get; set; }
        public string cardTokenUse { get; set; }
        public string authCode { get; set; }
        public string processFDS { get; set; }
        public List<FreeTextObject> freeTexts { get; set; }
        public string additionalData { get; set; }
        public List<SellerDetailObject> sellerDetails { get; set; }
    }

    #region Transaction Fee
    public class AdditionalFeeObject
    {
        public int? price { get; set; }
        public string parentType { get; set; }
        public string parendId { get; set; }
    }
    #endregion

    #region Transaction Feature

    public class DiscountObject
    {
        public int? price { get; set; }
        public string parentType { get; set; }
        public int? parentId { get; set; }
    }
    #endregion

    #region Item Detail
    public class ItemDetailObject
    {
        public string itemId { get; set; }
        public string itemName { get; set; }
        public int? quantity { get; set; }
        public int? price { get; set; }
        public string itemUrl { get; set; }
        public string itemType { get; set; }
        public InstallmentDataObject installmentData { get; set; }
        public string sellerId { get; set; }
        public string name { get; set; }
        public int? qty { get; set; }
        public int? unitPrice { get; set; }
        public int? fee { get; set; }
        public int? category { get; set; }
    }

    public class InstallmentDataObject
    {
        public int? tenor { get; set; }
        public int? merchantId { get; set; }
        public int? codePlan { get; set; }
    }
    #endregion

    #region Free Text
    public class FreeTextObject
    {
        public string indonesian { get; set; }
        public string english { get; set; }
        public int? section { get; set; }
    }
    #endregion

    #region Seller Detail
    public class SellerDetailObject
    {
        public string sellerId { get; set; }
        public string sellerBrandName { get; set; }
        public string sellerName { get; set; }
        public string sellerEmail { get; set; }
        public int? sellerPhone { get; set; }
        public string sellerAddress { get; set; }
        public string sellerCity { get; set; }
        public string sellerCountry { get; set; }
        public string sellerZipCode { get; set; }
        public string sellerUrl { get; set; }
        public string sellerIdNumber { get; set; }
    }
    #endregion


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
        public int? isPromo { get; set; }
        public string promoCode { get; set; }
        public string promoMessage { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public string en { get; set; }
        public int? promoAmmont { get; set; }
        public int? totalAmmount { get; set; }
        public string voucher { get; set; }
        public int? continueIfRuleNotMatch { get; set; }
    }

    public class PaymentFlagRequest
    {
        public string channelId { get; set; }
        public string currency { get; set; }
        public string transactionNo { get; set; }
        public int? transactionAmmount { get; set; }
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
        public int? insertId { get; set; }
        public string paymentReffId { get; set; }
        public string paymentMethod { get; set; }
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
        public int? card_expiry { get; set; }
        public string card_type { get; set; }
        public string card_level { get; set; }
        public int? card_is_corporate { get; set; }
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
        public string flagType { get; set; }
        public string paymentReffId { get; set; }
    }
}
