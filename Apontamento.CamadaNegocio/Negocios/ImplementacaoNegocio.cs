using CamadaModelo.Entidades;
using CamadaNegocio.Intefaces;
using CamadaNegocio.Validadores;
using CamadaRepositorio;
using FluentValidation.Results;

namespace CamadaNegocio.Negocios
{
    public class ImplementacaoNegocio
    {
        #region Atributos

        private string _notificacoes;
        
        private ConProContexto _contexto;

        private Implementacao _implementacaoAtual;

        private readonly IImplementacao _implementacao;


        #endregion Atributos

        #region Propriedades

        public string Notificacoes {
            get {
                return _notificacoes;
            }
        }

        #endregion Propriedades

        #region Construtores

        public ImplementacaoNegocio( ConProContexto contexto )
        {
            _contexto = contexto;
        }

        //public ImplementacaoNegocio( IImplementacao interfaceImplementacao, INotificacao interfaceNotificadora, ConProContexto contexto )
        //{
        //    _implementacao = interfaceImplementacao;
        //    _notificadora = interfaceNotificadora;
        //    _contexto = contexto;
        //}

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos

        private void AdicionarValidacoes( ValidationResult resultado )
        {
            _notificacoes = string.Empty;

            foreach ( ValidationFailure falha in resultado.Errors )
            {
                _notificacoes += $"- {falha.ErrorMessage}\n";
            }
        }

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

        public void Cadastrar()
        {
            _contexto.Set<Implementacao>().Add( _implementacaoAtual );
            _contexto.SaveChanges();

            _implementacaoAtual = null;
        }

        public void Alterar()
        {
            _contexto.Set<Implementacao>().Update( _implementacaoAtual );
            _contexto.SaveChanges();

            _implementacaoAtual = null;
        }

        #region Buscas

        public IEnumerable<Implementacao> BuscarTudo()
        {
            return _contexto.Set<Implementacao>();
        }

        public Implementacao BuscarPorCodigo()
        {
            return _contexto.Set<Implementacao>().FirstOrDefault( implementacao => implementacao.CodigoImplementacao == _implementacao.CodigoImplementacao );
        }

        public Implementacao BuscarPorCodigo( int codigo )
        {
            return _contexto.Set<Implementacao>().FirstOrDefault( implementacao => implementacao.CodigoImplementacao == codigo );
        }

        #endregion Buscas

        public void Excluir()
        {
            _contexto.Set<Implementacao>().Remove( _implementacaoAtual );
            _contexto.SaveChanges();

            _implementacaoAtual = null;
        }

        public bool ValidarImplementacao( Implementacao implementacao )
        {
            ValidationResult resultadoValidacao;
            ImplementacaoValidador validador = new ImplementacaoValidador();

            resultadoValidacao = validador.Validate( implementacao );

            if ( !resultadoValidacao.IsValid )
            {
                AdicionarValidacoes( resultadoValidacao );
                return false;
            }

            _implementacaoAtual = implementacao;

            return true;
        }

        #endregion Públicos

        #endregion Métodos
    }
}