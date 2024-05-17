namespace Krop.Business.Features.Brands.Dtos
{
    public record class CreateBrandDTO
    {
        public string BrandName { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
    }
}
