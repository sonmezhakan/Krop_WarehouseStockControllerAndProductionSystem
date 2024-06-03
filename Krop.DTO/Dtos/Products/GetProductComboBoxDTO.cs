namespace Krop.DTO.Dtos.Products
{
    public record class GetProductComboBoxDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
