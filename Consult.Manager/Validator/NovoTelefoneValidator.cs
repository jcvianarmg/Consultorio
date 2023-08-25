using Consult.Core.Shared.ModelViews;
using FluentValidation;

namespace Consult.Manager.Validator
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
            RuleFor(p => p.Numero).Matches("[1-9][0-9]{10}").WithMessage("O telefone deve ter o formato [2-9][0-9]{10}");
        }
    }
}
