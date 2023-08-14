using Consult.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consult.Manager.Validator
{
    public class AlteraPacienteValidator : AbstractValidator<AlteraPaciente>
    {
        public AlteraPacienteValidator()
        {
          RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0); 
          Include(new NovoPacienteValidator()); 
        }
    }
}
