using CamadaModelo.Entidades;
using CamadaNegocio.Validadores;
using CamadaRepositorio;
using FluentValidation;
using FluentValidation.Results;

namespace CamadaNegocio.Negocios
{
    public class ApontamentoNegocio
    {
        #region Atributos

        private ConProContexto _contexto;

        private Apontamento _apontamentoAtual;

        private string _notificacoes;

        #endregion Atributos

        #region Propriedades

        public string Notificacoes {
            get {
                return _notificacoes;
            }

            set {
                _notificacoes = value;
            }
        }

        #endregion Propriedades

        #region Construtores

        public ApontamentoNegocio( ConProContexto contexto )
        {
            _contexto = contexto;
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos

        private void AdicionarNotificacoes( ValidationResult resultado )
        {
            _notificacoes = string.Empty;

            foreach ( ValidationFailure item in resultado.Errors )
            {
                _notificacoes += $"- {item.ErrorMessage}";
            }
        }

        private bool ValidarApontamento( string tipoValidacao, Apontamento apontamento )
        {
            ValidationResult resultadoValidacao;
            ApontamentoValidador validador = new ApontamentoValidador();

            if ( _apontamentoAtual != apontamento )
            {
                _apontamentoAtual = apontamento;
            }

            resultadoValidacao = validador.Validate( _apontamentoAtual, opcao => opcao.IncludeRuleSets( tipoValidacao ) );

            if ( !resultadoValidacao.IsValid )
            {
                AdicionarNotificacoes( resultadoValidacao );
                return false;
            }

            return true;
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

        #region CRUD

        public Apontamento Cadastrar( int codigoImplementacao )
        {
            Implementacao implementacao;

            try
            {
                implementacao = _contexto.Set<Implementacao>().Find( codigoImplementacao );

                if ( implementacao == null )
                {
                    _notificacoes = "- Não foi encontrado nenhuma implementação.";
                    return null;
                }

                _apontamentoAtual.Implementacao = implementacao;

                _contexto.Set<Apontamento>().Add( _apontamentoAtual );
                _contexto.SaveChanges();

                _apontamentoAtual = null;

                return _apontamentoAtual;
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public void Alterar()
        {
            _contexto.Set<Apontamento>().Update( _apontamentoAtual );
            _contexto.SaveChanges();
        }

        #region Buscas

        public IEnumerable<Apontamento> BuscarTudo()
        {
            return _contexto.Set<Apontamento>();
        }

        public Apontamento BuscarPorCodigo( int codigo )
        {
            return _contexto.Set<Apontamento>().FirstOrDefault( apontamento => apontamento.CodigoApontamento == codigo );
        }

        public IEnumerable<Apontamento> BuscarApontamentoPorImplementacao( int codigoImplementacao )
        {
            ImplementacaoNegocio implementacaoNegocio = new ImplementacaoNegocio( _contexto );

            try
            {
                Implementacao implementacao = implementacaoNegocio.BuscarPorCodigo( codigoImplementacao );

                if ( implementacao == null )
                {
                    _notificacoes = "Nenhuma implementação com esse código foi localizado.";
                    return null;
                }

                if ( implementacao.Apontamentos == null )
                {
                    implementacao.Apontamentos = _contexto.Set<Apontamento>().Where( apontamento => apontamento.Implementacao.CodigoImplementacao == codigoImplementacao ).ToList();
                }

                if ( !implementacao.Apontamentos.Any() )
                {
                    _notificacoes = "Não existe apontamentos para essa implementação.";
                    return null;
                }

                return implementacao.Apontamentos;
            }
            catch ( Exception )
            {

                throw;
            }
        }

        #endregion Buscas

        public void Excluir()
        {
            _contexto.Set<Apontamento>().Remove( _apontamentoAtual );
            _contexto.SaveChanges();

            _apontamentoAtual = null;
        }

        #endregion CRUD

        public Apontamento FecharApontamento( int codigoApontamento, string descricao )
        {
            try
            {
                _apontamentoAtual = _contexto.Set<Apontamento>().FirstOrDefault( apontamento => apontamento.CodigoApontamento == codigoApontamento );

                if ( _apontamentoAtual == null )
                {
                    _notificacoes = "Não foi localizado nenhum apontamento com esse código.";
                    return null;
                }

                _apontamentoAtual.DataFim = DateTime.Now;
                _apontamentoAtual.DescricaoRealizado = descricao;
                _apontamentoAtual.CalcularTempoApontamento();

                //Alterar();

                return _apontamentoAtual;
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public bool ValidarNovoApontamento()
        {
            return ValidarApontamento( "NovoApontamento", new Apontamento( DateTime.Now ) );
        }

        public bool ValidarFechamento()
        {
            //Apontamento apontamento = BuscarPorCodigo( codigo );

            if ( _apontamentoAtual == null )
            {
                _notificacoes = "Não há nenhum apontamento com esse código";
                return false;
            }

            return ValidarApontamento( "FecharApontamento", _apontamentoAtual );
        }

        #endregion Públicos

        #endregion Métodos
    }
}