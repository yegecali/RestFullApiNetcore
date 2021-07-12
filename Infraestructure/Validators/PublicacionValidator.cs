using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Validators
{
    public class PublicacionValidator : AbstractValidator<PublicacionDto>
    {
        public PublicacionValidator()
        {
            RuleFor(publicacion => publicacion.Descripcion)
                .NotNull()
                .Length(10, 500);
            RuleFor(fecha => fecha.Fecha)
                .NotNull()
                .LessThan(DateTime.Now);
        }
    }
}
