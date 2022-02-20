namespace ControladorProjetos.CamadaNegocio.Intefaces
{
    public interface IApontamento
    {
        int CodigoApontamento { get; }

        DateTime DataInicio { get; }

        DateTime DataFim { get; }

        string DescricaoRealizado { get; }

        int CodigoImplementacao { get; }
    }
}