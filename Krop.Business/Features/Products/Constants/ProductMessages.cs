namespace Krop.Business.Features.Products.Constants
{
    public class ProductMessages
    {
        public const string ProductNotFound = "Ürün Bulunamadı!";
        public const string ProductNameExists = "Ürün Adı Mevcut!";
        public const string ProductCodeExists = "Ürün Kodu Mevcut!";

        public const string ProductIdNotEmptyAndNull = "Id Boş Olamaz!";

        public const string ProductNameNotNull = "Ürün Adı Boş Olamaz!";
        public const string ProductNameMinAndMaxLenght = "Ürün Adı Minimum 3, Maksimum 255 Karakter Olabilir!";

        public const string ProductCodeNotNull = "Ürün Kodu Boş Olamaz!";
        public const string ProductCodeMinAndMaxLenght = "Ürün Kodu Minimum 3, Maksimum 255 Karakter Olabilir!";

        public const string CategoryNotNull = "Kategori Boş Olamaz!";
        public const string ProductDescriptionMaxLenght = "Açıklama En Fazla 1000 Karakter Olabilir!";

    }
}
