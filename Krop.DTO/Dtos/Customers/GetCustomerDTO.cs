﻿using Krop.Entities.Enums;

namespace Krop.DTO.Dtos.Customers
{
    public record  GetCustomerDTO
    {
        public Guid Id{ get; init; }
        public InvoiceEnum Invoice{ get; init; }
        public string CompanyName{ get; init; }
        public string ContactName{ get; init; }
        public string ContactTitle{ get; init; }
        public string PhoneNumber{ get; init; }
        public string Email{ get; init; }
        public string Country{ get; init; }
        public string City{ get; init; }
        public string Addres{ get; init; }

    }
}
