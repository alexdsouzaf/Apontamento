using ControladorProjetos.CamadaModelo.Entidades;
using ControladorProjetos.CamadaRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace ConProAPI.Controllers
{
    [Route( "implementacao" )]
    public class ImplementacaoController : ControllerBase
    {
        private ConProContexto _contexto;

        public ImplementacaoController( ConProContexto contexto )
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Implementacao>> BuscarTudo()
        {
            return _contexto.Set<Implementacao>();
        }

        [HttpPost( "IniciarNovaImplementacao" )]
        public ActionResult IniciarNovaImplementacao( [FromBody] Implementacao implementacao )
        {
            try
            {
                _contexto.Set<Implementacao>().Add( implementacao );
                _contexto.SaveChanges();
            }
            catch ( Exception ex )
            {
                return BadRequest( $"{ex}" );
            }

            return Ok( implementacao );
        }

        //public ActionResult IniciarNovoApontamento( int codigoImplementacao )
        //{
        //    Implementacao implementacao;
        //    Apontamento apontamento = new Apontamento( DateTime.Now );
        //    try
        //    {
        //        implementacao = _contexto.Set<Implementacao>().Find( codigoImplementacao );

        //        if ( implementacao == null )
        //        {
        //            NotFound( "Não foi encontrado nenhuma implementação" );
        //        }

        //        implementacao.Apontamentos = BuscarApontamentoPorImplementacao( codigoImplementacao ).Value as ICollection<Apontamento>;
        //        implementacao.Apontamentos.Add( apontamento );

        //        return Ok( )
        //    }
        //    catch ( Exception ex )
        //    {

        //        throw;
        //    }

        //}
    }
}