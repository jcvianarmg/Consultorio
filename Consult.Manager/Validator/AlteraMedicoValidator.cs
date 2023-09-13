using Consult.Core.Shared.ModelViews.Medico;
using FluentValidation;

namespace Consult.Manager.Validator;

public class AlteraMedicoValidator : AbstractValidator<AlteraMedico>
{
    public AlteraMedicoValidator(IEspecialidadeRepository repository)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoMedicoValidator(repository));
    }
}