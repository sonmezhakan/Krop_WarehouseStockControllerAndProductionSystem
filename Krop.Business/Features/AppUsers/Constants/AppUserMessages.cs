namespace Krop.Business.Features.AppUsers.Constants
{
    public class AppUserMessages
    {
        public const string AppUserNotFound = "Kullanıcı Bulunamadı!";

        public const string AppUserNameExists = "Kullanıcı Adı Mevcut!";
        public const string AppUserEmailExists = "Email Adresi Mevcut!";
        public const string AppUserPhoneNumberExists = "Telefon Numarası Mevcut!";
        public const string AppUserNationalNumberExists = "Kimlik Numarası Mevcut!";

        public const string AppUserIdNotEmptyAndNull = "Id Boş Olamaz!";
        public const string AppUserPasswordNotEmptyAndNull = "Şifre Boş Olamaz!";
        public const string AppUserPasswordMinAndMaxLenght = "Şifre Minimum 3, Maksimum 64 Karakter Olabilir!\n Şifrenizde 1 Büyük, 1 Küçük, 1 Rakam ve 1 Sembol Kullanılmalıdır!";

        public const string AppUserLoginError = "Kullanıcı Adı veya Şifre Hatalı!";
        public const string AppUserEmailNotConfirm = "Hesabını Mail Adresiniz Üzerinden Aktifleştiriniz!";

        public const string UserNameNotNull = "Kullanıcı Adı Boş Olamaz!";
        public const string UserNameMinAndMaxLenght = "Kullanıcı Adı Minimum 3, Maksimum 64 Karakter Olabilir!";

        public const string EmailNotNull = "Email Adresi Boş Olamaz!";
        public const string EmailNotFormatted = "Email Formatı Uygun Değil!";
        public const string EmailMinAndMaxLenght = "Email Adresi Minimum 7, Maksimum 128 Karakter Olabilir!";

        public const string CountryMaxLenght = "Ülke Adı En Fazla 64 Karakter Olabilir!";
        public const string CityMaxLenght = "Şehir Adı En FAzla 64 Karakter Olabilir!";
        public const string Address = "Adres En Fazla 255 Karakter Olabilir!";

        public const string FirstNameNotNull = "Ad Boş Olamaz!";
        public const string FirstNameMinAndMaxLenght = "Ad Minimum 3, Maksimum 128 Karakter Olabilir!";

        public const string LastNameNotNull = "Soyad Boş Olamaz!";
        public const string LastNameMinAndMaxLenght = "Soyad Minimum 3, Maksiumum 128 Karakter Olabilir!";

        public const string NationalNumberMaxLenght = "Kimlik Numarası En Fazla 11 Karakter Olabilir!";

        public const string EmailConfirmed = "Email Onaylanmış!";
    }
}
