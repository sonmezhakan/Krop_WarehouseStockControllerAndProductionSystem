namespace Krop.Business.Features.Products.Dtos
{
    public record class GetProductComboBoxDTO
    {
        public Guid Id { get; set; }
        public  string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
