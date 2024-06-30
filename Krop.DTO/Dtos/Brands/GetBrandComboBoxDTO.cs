namespace Krop.DTO.Dtos.Brands
{
    public record  GetBrandComboBoxDTO
    {
        public Guid Id{ get; init; }
        public string BrandName{ get; init; }
    }
}
