namespace Krop.Business.Features.ProductReceipts.Constants
{
    public class ProductReceiptMessages
    {
        public const string ProduceProductIdNotNull = "Reçetesi Oluşturulacak Ürün Boş Olamaz!";
        public const string ProductIdNotNull = "Reçeteye Eklenecek Ürün Boş Olamaz!";
        public const string QuantityNotNull = "Adet Boş Olamaz!";
        public const string ProductReceiptExists = "Reteçeye Bu Ürün Daha Önceden Eklenmiş!";
        public const string ProductreceiptNotFound = "Reçetede Ürün Bulunamadı!";
        public const string ProductExists = "Reçetesine Eklenecek Ürün İle Reçeteye Eklenecek Ürün Aynı Olamaz!";
        public const string QuantityMinAndMaxLenght = "1 ile 2147483647 Arasında Miktar Girilebilir!";
    }
}
