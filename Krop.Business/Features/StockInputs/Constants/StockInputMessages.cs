namespace Krop.Business.Features.StockInputs.Constants
{
    public class StockInputMessages
    {
        public const string ProductNotNull = "Ürün Boş Olamaz!";
        public const string BranchNotNull = "Şube Boş Olamaz!";
        public const string SupplierNotNull = "Tedarikçi Boş Olamaz!";
        public const string EmployeeNotNull = "Çalışan Değilsiniz!";

        public const string InvoiceNumberMaxLenght = "Fatura Numarası En Fazla 32 Karakter Olabilir!";
        public const string DescriptionMaxLenght = "Açıklama En Fazla 1000 Karakter Olabilir!";

        public const string QuantityMaxLenght = "Adet Minimum 1, Maksimum 2147483647 Olarak Girilebilir!";

        public const string StockInputNotFound = "Böyle Bir Stok Girişi Bulunamadı!";

    }
}
