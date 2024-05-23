namespace Krop.Business.Features.Brands.Dtos
{
    public record class GetBrandComboBoxDTO
    {
        public Guid Id { get; init; }
        public string BrandName { get; set; }
    }
}
