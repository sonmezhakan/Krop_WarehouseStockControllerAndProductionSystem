using FluentValidation;
using Krop.DTO.Dtos.Productions;

namespace Krop.Business.Features.Productions.Validations
{
    public class CreateProductionValidator:AbstractValidator<CreateProductionDTO>
    {
        public CreateProductionValidator()
        {
            
        }
    }
}
