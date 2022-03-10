using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControladorProjetos.CamadaModelo.Entidades
{
    [Table( "APONTAMENTO" )]
    public class Apontamento
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        [Column( "COD_APONTAMENTO" )]
        [Key]
        public int CodigoApontamento { get; set; }

        [Required]
        [Column( "DATA_INICIO" )]
        public DateTime DataInicio { get; set; }

        [JsonIgnore]
        [Column( "DATA_FIM" )]
        public DateTime DataFim { get; set; }

        [Column( "DES_REALIZADO" )]
        public string DescricaoRealizado { get; set; }

        [ForeignKey( "COD_IMPLEMENTACAO" )]
        public Implementacao Implementacao { get; set; }

        [JsonIgnore]
        [Column( "TEMPO" )]
        public TimeSpan Tempo { get; set; }

        #endregion Propriedades

        #region Construtores

        //internal Apontamento()
        //{

        //}

        public Apontamento( Implementacao implementacao )
        {
            Implementacao = implementacao;
        }

        public Apontamento( DateTime dataInicio )
        {
            DataInicio = dataInicio;
            DescricaoRealizado = string.Empty;
        }

        public Apontamento( int codigoApontamento, DateTime dataInicio, DateTime dataFim, string descricaoRealizado, Implementacao implementacao, TimeSpan tempo )
        {
            CodigoApontamento = codigoApontamento;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DescricaoRealizado = descricaoRealizado;
            Implementacao = implementacao;
            Tempo = tempo;
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

        #endregion Métodos
    }
}