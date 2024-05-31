namespace Krop.Business.Features.StockTransfers.Constants
{
    public class StockTransferMessages
    {
        public const string StockTransferNotFound = "Transfer İşlemi Bulunamadı!";
        public const string StockTransferNotNull = "İşlem Yapılacak Transferi Seçiniz!";
        public const string SenderBranchNotNull = "Transfer Yapan Şube Boş Olamaz!";
        public const string SentBranchNotNull = "Transfer Yapılan Şube Boş Olamaz!";
        public const string ProductNotNull = "Ürün Boş Olamaz!";
        public const string SenderAppUserNotNull = "Transfer Yapan Kullanıcı Boş Olamaz!";
        public const string QuantityNotNull = "Transfer Edilen Miktar Boş Olamaz!";
        public const string QuantityMaxLenght = "Transfer Edilen Miktar Minimum 1, Maksimum 2147483647 Olabilir!";
        public const string InoviceNumberMaxLenght = "Fatura Numarası En Fazla 32 Karakter Olabilir!";
        public const string DescriptionMaxLenght = "Açıklama En Fazla 1000 Karakter Olabilir!";
        public const string SenderAndSentBranchExists = "Gönderen Şube Gönderilen Şube İle Aynı Olamaz!";
    }
 }
