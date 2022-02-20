using ControladorProjetos.CamadaModelo.Entidades;
using FluentValidation;

namespace ControladorProjetos.CamadaNegocio.Validadores
{
    internal class ImplementacaoValidador : AbstractValidator<Implementacao>
    {
        public ImplementacaoValidador()
        {
            RuleFor( implementacao => implementacao.Descricao ).MinimumLength( 30 ).WithMessage( "Descrição está muito curta. Deve ter mais que 30 caracteres" );
            RuleFor( implementacao => implementacao.Descricao ).MaximumLength( 1000 ).WithMessage( "Descrição está muito longa. Deve ter menos que 1000 caracteres" );
            RuleFor( implementacao => implementacao.TempoTotal ).LessThan( 0 ).WithMessage( "Tempo total não pode ser menor que 0 horas" );
        }
    }
}