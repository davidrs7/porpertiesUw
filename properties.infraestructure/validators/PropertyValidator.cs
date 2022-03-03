using FluentValidation;
using properties.core.DTO;

namespace properties.infraestructure.validators
{
    public class PropertyValidator: AbstractValidator<PropertyDto>
    {
        public PropertyValidator()
        {
            RuleFor(property => property.NameProperty)
                   .NotNull()
                   .Length(1, 500);

            RuleFor(property => property.Id)
                   .NotNull();
        }
    }
}
