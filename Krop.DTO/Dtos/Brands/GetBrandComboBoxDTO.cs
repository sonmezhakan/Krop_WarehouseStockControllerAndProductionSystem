namespace Krop.DTO.Dtos.Brands
{
    public record class GetBrandComboBoxDTO
    {
        public Guid Id { get; init; }
        public string BrandName { get; set; }
    }
}
