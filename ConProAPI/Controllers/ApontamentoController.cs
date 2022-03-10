using BibliotecaPublica.CamadaNotificadora;
using BibliotecaPublica.CamadaNotificadora.Interfaces;
using ControladorProjetos.CamadaModelo.Entidades;
using ControladorProjetos.CamadaNegocio.Intefaces;
using ControladorProjetos.CamadaNegocio.Negocios;
using ControladorProjetos.CamadaRepositorio;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ConProAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ApontamentoController : ControllerBase, IApontamento, INotificacao
    {
        private ConProContexto _contexto;
        private ApontamentoNegocio _negocio;

        #region Propriedades

        #region INotificacao

        public NotificacaoColecao Notificacoes => throw new NotImplementedException();

        #endregion INotificacao

        #region IApontamento

        public int CodigoApontamento => throw new NotImplementedException();

        public DateTime DataInicio => throw new NotImplementedException();

        public DateTime DataFim => throw new NotImplementedException();

        public string DescricaoRealizado => throw new NotImplementedException();

        public int CodigoImplementacao => throw new NotImplementedException();

        #endregion IApontamento

        #endregion Propriedades

        //public ApontamentoController( ConProContexto contexto )
        //{
        //    _contexto = contexto;
        //}

        public ApontamentoController( ApontamentoNegocio apontamentoNegocio )
        {
            _negocio = apontamentoNegocio;
        }

        #region INotificacao

        public void AdicionarNotificacoes( ValidationResult resultado )
        {
            Notificacoes.AdicionarResultadoValidacao( resultado );
        }

        public bool TemNotificacao()
        {
            return Notificacoes.TemNotificacao;
        }

        public void Notificar()
        {

        }

        #endregion INotificacao

        #region Rotas

        [HttpPost( "IniciarNovoApontamento" )]
        public ActionResult<Apontamento> IniciarNovoApontamento( int codigoImplementacao )
        {
            Implementacao implementacao;

            try
            {
                //implementacao = _contexto.Set<Implementacao>().Find( codigoImplementacao );

                //if ( implementacao == null )
                //{
                //    return BadRequest( "Não foi encontrado nenhuma implementação." );
                //}

                //apontamento.Implementacao = implementacao;

                //_contexto.Set<Apontamento>().Add( apontamento );
                //_contexto.SaveChanges();

                //return Ok( apontamento );

                if ( !_negocio.ValidarApontamento( "NovoApontamento", new Apontamento( DateTime.Now ) ) )
                {
                    return BadRequest( Notificacoes.ToString() );
                }

                Apontamento apontamento = _negocio.Cadastrar( codigoImplementacao );

                return Ok( apontamento );
            }
            catch ( Exception ex )
            {
                return BadRequest( $"{ex}" );
            }
        }

        [HttpGet( "BuscarApontamentosPorImplementacao" )]
        public ActionResult<IEnumerable<Apontamento>> BuscarApontamentoPorImplementacao( int codigoImplementacao )
        {
            try
            {
                Implementacao implementacao = _contexto.Set<Implementacao>().Find( codigoImplementacao );

                if ( implementacao == null )
                {
                    return NotFound( "Nenhuma implementação com esse código foi localizado." );
                }

                if ( implementacao.Apontamentos == null )
                {
                    implementacao.Apontamentos = _contexto.Set<Apontamento>().Where( apontamento => apontamento.Implementacao.CodigoImplementacao == codigoImplementacao ).ToList();
                }

                if ( !implementacao.Apontamentos.Any() )
                {
                    return NotFound( "Não existe apontamentos para essa implementação." );
                }

                return Ok( implementacao.Apontamentos );
            }
            catch ( Exception ex )
            {
                return BadRequest( $"{ex}" );
            }
        }

        #endregion Rotas
    }
}
