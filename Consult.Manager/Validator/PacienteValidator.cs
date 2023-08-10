using Consult.Core.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consult.Manager.Validator
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-110));
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("[2-9][0-9]{10}").WithMessage("O telefone deve ser no formato [2-9][0-9]{10}");
            RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMorF).WithMessage("O Sexo deve ser M ou F ");
        }

        private bool IsMorF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}
