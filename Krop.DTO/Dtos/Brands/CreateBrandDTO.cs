namespace Krop.DTO.Dtos.Brands
{
    public record  CreateBrandDTO
    {
        public string BrandName{ get; init; }
        public string PhoneNumber{ get; init; }
        public string Email{ get; init; }
    }
}
