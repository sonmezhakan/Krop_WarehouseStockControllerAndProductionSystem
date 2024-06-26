﻿namespace Krop.DTO.Dtos.StockInputs
{
    public record  GetStockInputListDTO
    {
        private bool _productionStatu{ get; init; }

        public Guid Id { get; init; }
        public string BranchName { get; init; }
        public string ProductName { get; init; }
        public string ProductCode{ get; init; }
        public string CompanyName { get; init; }
        public string InvoiceNumber { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
        public string Description { get; init; }
        public DateTime InputDate { get; init; }
        public string UserName { get; init; }
        public Guid ProductionId{ get; init; }
        public bool ProductionStatu
        {
            get
            {
                return _productionStatu;
            }

            init
            {
                if (ProductionId != Guid.Empty)
                    _productionStatu = true;
                else
                    _productionStatu = false;
            }
        }
    }
}
