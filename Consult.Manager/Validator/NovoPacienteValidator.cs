using Consult.Core.Shared.ModelViews.Paciente;
using FluentValidation;

namespace Consult.Manager.Validator;

public class NovoPacienteValidator : AbstractValidator<NovoPaciente>
{
    public NovoPacienteValidator()
    {
        RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
        RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
        RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        RuleFor(x => x.Telefones).NotNull().NotEmpty();
        RuleFor(x => x.Sexo).NotNull();
        RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
    }
}