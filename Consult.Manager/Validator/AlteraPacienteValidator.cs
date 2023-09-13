using Consult.Core.Shared.ModelViews.Paciente;
using FluentValidation;

namespace Consult.Manager.Validator;

public class AlteraPacienteValidator : AbstractValidator<AlteraPaciente>
{
    public AlteraPacienteValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoPacienteValidator());
    }
}