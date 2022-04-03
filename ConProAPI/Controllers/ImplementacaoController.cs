using ControladorProjetos.CamadaModelo.Entidades;
using ControladorProjetos.CamadaNegocio.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace ConProAPI.Controllers
{
    [Route( "implementacao" )]
    public class ImplementacaoController : ControllerBase
    {
        private ImplementacaoNegocio _negocio;

        public ImplementacaoController( ImplementacaoNegocio negocio )
        {
            _negocio = negocio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Implementacao>> BuscarTudo()
        {
            try
            {
                IEnumerable<Implementacao> implementacoes = _negocio.BuscarTudo();

                if ( implementacoes == null )
                {
                    return NotFound( "Não há implementações cadastradas." );
                }

                return Ok( implementacoes );
            }
            catch ( Exception ex )
            {
                return BadRequest( $"{ex}" );
            }
        }

        [HttpPost( "IniciarNovaImplementacao" )]
        public ActionResult IniciarNovaImplementacao( [FromBody] Implementacao implementacao )
        {
            try
            {
                if ( !_negocio.ValidarImplementacao( implementacao ) )
                {
                    return BadRequest( _negocio.Notificacoes );
                }

                _negocio.Cadastrar();
            }
            catch ( Exception ex )
            {
                return BadRequest( $"{ex}" );
            }

            return Ok( implementacao );
        }
    }
}