namespace CamadaNegocio.Intefaces
{
    public interface IImplementacao
    {
        int CodigoImplementacao { get; }

        string Descricao { get; }

        bool Cobrado { get; }
    }
}