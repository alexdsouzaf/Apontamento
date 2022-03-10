using BibliotecaPublica.CamadaNotificadora;
using BibliotecaPublica.CamadaNotificadora.Interfaces;
using ControladorProjetos.CamadaModelo.Entidades;
using ControladorProjetos.CamadaNegocio.Intefaces;
using ControladorProjetos.CamadaNegocio.Validadores;
using ControladorProjetos.CamadaRepositorio;
using FluentValidation;
using FluentValidation.Results;

namespace ControladorProjetos.CamadaNegocio.Negocios
{
    public class ApontamentoNegocio
    {
        #region Atributos

        private ConProContexto _contexto;

        private Apontamento _apontamentoAtual;

        private IApontamento _apontamento;
        private INotificacao _notificadora;

        #endregion Atributos

        #region Propriedades

        public IApontamento Apontamento {
            set {
                _apontamento = value;
            }
        }

        public INotificacao Notificadora {
            set {
                _notificadora = value;
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

        public Apontamento Cadastrar( int codigoImplementacao )
        {
            Implementacao implementacao;

            try
            {
                implementacao = _contexto.Set<Implementacao>().Find( codigoImplementacao );

                if ( implementacao == null )
                {
                    _notificadora.Notificacoes.Adicionar( new Notificacao( "404", "Implementação", "Não foi encontrado nenhuma implementação." ) );
                    return null;
                }

                _apontamentoAtual.Implementacao = implementacao;

                _contexto.Set<Apontamento>().Add( _apontamentoAtual );
                _contexto.SaveChanges();

                _apontamentoAtual = null;

                return _apontamentoAtual;
            }
            catch ( Exception ex )
            {
                _notificadora.Notificacoes.Adicionar( new Notificacao( "400", "Exceção", $"{ex}" ) );
                return null;
            }
        }

        public void Alterar()
        {
            _contexto.Set<Apontamento>().Update( _apontamentoAtual );
            _contexto.SaveChanges();

            _apontamentoAtual = null;
        }

        #region Buscas

        public IEnumerable<Apontamento> BuscarTudo()
        {
            return _contexto.Set<Apontamento>();
        }

        public Apontamento BuscarPorCodigo()
        {
            return _contexto.Set<Apontamento>().FirstOrDefault( apontamento => apontamento.CodigoApontamento == _apontamento.CodigoApontamento );
        }

        #endregion Buscas

        public void Excluir()
        {
            _contexto.Set<Apontamento>().Remove( _apontamentoAtual );
            _contexto.SaveChanges();

            _apontamentoAtual = null;
        }

        public bool ValidarApontamento( string tipoValidacao, Apontamento apontamento )
        {
            ValidationResult resultadoValidacao;
            ApontamentoValidador validador = new ApontamentoValidador();

            _apontamentoAtual = apontamento;

            resultadoValidacao = validador.Validate( _apontamentoAtual, opcao => opcao.IncludeRuleSets( tipoValidacao ) );

            if ( !resultadoValidacao.IsValid )
            {
                _notificadora.Notificacoes.AdicionarResultadoValidacao( resultadoValidacao );
                return false;
            }

            return true;
        }

        #endregion Públicos

        #endregion Métodos
    }
}