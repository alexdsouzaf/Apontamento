using BibliotecaPublica.CamadaNotificadora.Interfaces;
using ControladorProjetos.CamadaModelo.Entidades;
using ControladorProjetos.CamadaNegocio.Intefaces;
using ControladorProjetos.CamadaNegocio.Validadores;
using ControladorProjetos.CamadaRepositorio;
using FluentValidation.Results;

namespace ControladorProjetos.CamadaNegocio.Negocios
{
    public class ImplementacaoNegocio
    {
        #region Atributos

        private ConProContexto _contexto;

        private Implementacao _implementacaoAtual;

        private readonly IImplementacao _implementacao;
        private readonly INotificacao _notificadora;

        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores

        public ImplementacaoNegocio()
        {

        }

        public ImplementacaoNegocio( IImplementacao interfaceImplementacao, INotificacao interfaceNotificadora, ConProContexto contexto )
        {
            _implementacao = interfaceImplementacao;
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

        public Implementacao BuscarPorCodigo(int codigo)
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

        public bool ValidarImplementacao()
        {
            ValidationResult resultadoValidacao;
            ImplementacaoValidador validador = new ImplementacaoValidador();

            _implementacaoAtual = new Implementacao();

            _implementacaoAtual.Descricao = _implementacao.Descricao;
            _implementacaoAtual.Cobrado = _implementacao.Cobrado;
            _implementacaoAtual.TempoTotal = new TimeSpan();

            resultadoValidacao = validador.Validate( _implementacaoAtual );

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