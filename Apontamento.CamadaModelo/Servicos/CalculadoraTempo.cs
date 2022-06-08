namespace CamadaModelo.Servicos
{
    public static class CalculadoraTempo
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

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

        public static TimeSpan CalcularTempo( DateTime dataInicial, DateTime dataFinal )
        {
            if ( dataInicial > dataFinal )
            {
                return dataInicial - dataFinal;
            }

            return dataFinal - dataInicial;
        }

        #endregion Públicos

        #endregion Métodos
    }
}