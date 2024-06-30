namespace Krop.DTO.Dtos.Products
{
    public record  GetProductComboBoxDTO
    {
        public Guid Id{ get; init; }
        public string ProductName{ get; init; }
        public string ProductCode{ get; init; }
    }
}
