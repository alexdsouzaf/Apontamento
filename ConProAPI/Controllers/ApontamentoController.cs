using BibliotecaPublica.CamadaNotificadora;
using BibliotecaPublica.CamadaNotificadora.Interfaces;
using CamadaModelo.Entidades;
using CamadaNegocio.Intefaces;
using CamadaNegocio.Negocios;
using CamadaRepositorio;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ConProAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ApontamentoController : ControllerBase, IApontamento
    {
        private ApontamentoNegocio _negocio;

        #region Propriedades

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

        #region Rotas

        [HttpPost( "IniciarNovoApontamento" )]
        public ActionResult<Apontamento> IniciarNovoApontamento( int codigoImplementacao )
        {
            try
            {
                if ( !_negocio.ValidarNovoApontamento() )
                {
                    return BadRequest( _negocio.Notificacoes );
                }

                Apontamento apontamento = _negocio.Cadastrar( codigoImplementacao );

                return Ok( apontamento );
            }
            catch ( Exception ex )
            {
                return BadRequest( $"{ex}" );
            }
        }

        [HttpPost( "FinalizarApontamentoAberto" )]
        public ActionResult<Apontamento> FinalizarApontamentoAberto( int codigoApontamento, string descricao )
        {
            try
            {
                Apontamento apontamento = _negocio.FecharApontamento( codigoApontamento, descricao );

                if ( !_negocio.ValidarFechamento() )
                {
                    return BadRequest( _negocio.Notificacoes );
                }

                //if ( apontamento == null )
                //{
                //    return NotFound( _negocio.Notificacoes );
                //}

                _negocio.Alterar();

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
                IEnumerable<Apontamento> apontamentos = _negocio.BuscarApontamentoPorImplementacao( codigoImplementacao );

                if ( apontamentos == null )
                {
                    return NotFound( _negocio.Notificacoes );
                }

                return Ok( apontamentos );
            }
            catch ( Exception ex )
            {
                return BadRequest( $"{ex}" );
            }
        }

        #endregion Rotas
    }
}
