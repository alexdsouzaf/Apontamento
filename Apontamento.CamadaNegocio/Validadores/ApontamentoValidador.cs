using CamadaModelo.Entidades;
using FluentValidation;

namespace CamadaNegocio.Validadores
{
    public class ApontamentoValidador : AbstractValidator<Apontamento>
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores

        public ApontamentoValidador()
        {
            RuleSet( "Novo", () =>
             {
                 RuleFor( apontamento => apontamento.Implementacao ).NotNull().WithMessage( "Apontamneto deve estar vinculado à uma implementação." );
                 RuleFor( apontamento => apontamento.DataInicio ).Equal( new DateTime() ).WithMessage( "Data de início é inválida." );
             } );

            RuleSet( "Finalizacao", () =>
            {
                RuleFor( apontamento => apontamento.DescricaoRealizado ).NotEmpty().WithMessage( "A descrição do que foi realizado deve ser informado." );
                RuleFor( apontamento => apontamento.DescricaoRealizado ).MinimumLength( 15 ).WithMessage( "A descrição do que foi realizado está muito curta. Mínimo 15 caracteres" );
                RuleFor( apontamento => apontamento.DescricaoRealizado ).MinimumLength( 1000 ).WithMessage( "A descrição do que foi realizado está muito longa. Máximo 1000 caracteres" );

                RuleFor( apontamento => apontamento.DataFim ).Equal( new DateTime() ).WithMessage( "Data de finalização é inválida." );
                RuleFor( apontamento => apontamento.DataFim ).Equal( item => item.DataInicio ).WithMessage( "Data de finalização não pode ser igual a data de início." );

                RuleFor( apontamento => apontamento.Tempo ).Equal( new TimeSpan() ).WithMessage( "Não foi possível obter o tempo do apontamento." );
            } );
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Privados

        #region Protegidos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #region Públicos



        #endregion Públicos

        #endregion Métodos
    }
}