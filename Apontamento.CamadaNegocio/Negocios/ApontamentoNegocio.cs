using BibliotecaPublica.CamadaNotificadora.Interfaces;
using ControladorProjetos.CamadaNegocio.Intefaces;
using ControladorProjetos.CamadaModelo.Entidades;
using ControladorProjetos.CamadaRepositorio;
using FluentValidation.Results;
using ControladorProjetos.CamadaNegocio.Validadores;
using FluentValidation;

namespace ControladorProjetos.CamadaNegocio.Negocios
{
    public class ApontamentoNegocio
    {
        #region Atributos

        private ApontamentoContexto _contexto;

        private Apontamento _apontamentoAtual;

        private readonly IApontamento _apontamento;
        private readonly INotificacao _notificadora;

        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores

        public ApontamentoNegocio( IApontamento interfaceImplementacao, INotificacao interfaceNotificadora, ApontamentoContexto contexto )
        {
            _apontamento = interfaceImplementacao;
            _notificadora = interfaceNotificadora;
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

        public void Cadastrar()
        {
            _contexto.Set<Apontamento>().Add( _apontamentoAtual );
            _contexto.SaveChanges();

            _apontamentoAtual = null;
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

        public bool ValidarApontamento( string tipoApontamento )
        {
            ValidationResult resultadoValidacao;
            ApontamentoValidador validador = new ApontamentoValidador();

            _apontamentoAtual = new Apontamento();

            _apontamentoAtual.DataInicio = _apontamento.DataInicio;
            _apontamentoAtual.Implementacao = ( new ImplementacaoNegocio() ).BuscarPorCodigo( _apontamento.CodigoImplementacao );

            resultadoValidacao = validador.Validate( _apontamentoAtual, opcao => opcao.IncludeRuleSets( tipoApontamento ) );

            if ( !resultadoValidacao.IsValid )
            {
                _notificadora.Notificacoes.AdicionarResultadoValidacao( resultadoValidacao );
                _notificadora.Notificar();

                return false;
            }

            return true;
        }

        #endregion Públicos

        #endregion Métodos
    }
}