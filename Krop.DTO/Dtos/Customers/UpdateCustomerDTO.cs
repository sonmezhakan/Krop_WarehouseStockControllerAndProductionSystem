﻿using Krop.Entities.Enums;

namespace Krop.DTO.Dtos.Customers
{
    public record class UpdateCustomerDTO
    {
        public Guid Id { get; init; }
        public string CompanyName { get; init; }
        public string? ContactName { get; init; }
        public string? ContactTitle { get; init; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Country { get; init; }
        public string? City { get; init; }
        public string? Addres { get; init; }
        public InvoiceEnum Invoice { get; init; }
    }
}