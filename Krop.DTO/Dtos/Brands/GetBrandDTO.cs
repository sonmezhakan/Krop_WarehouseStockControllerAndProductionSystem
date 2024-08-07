﻿namespace Krop.DTO.Dtos.Brands
{
    public record GetBrandDTO
    {
        public Guid Id{ get; init; }
        public string BrandName{ get; init; }
        public string PhoneNumber{ get; init; }
        public string Email{ get; init; }
    }
}
