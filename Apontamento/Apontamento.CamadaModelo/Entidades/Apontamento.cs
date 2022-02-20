using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControladorProjetos.CamadaModelo.Entidades
{
    [Table("APONTAMENTO")]
    public class Apontamento
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        [Column("COD_APONTAMENTO")]
        [Key]
        public int CodigoApontamento { get; set; }

        [Required]
        [Column("DATA_INICIO")]
        public DateTime DataInicio { get; set; }

        [Column("DATA_FIM")]
        public DateTime DataFim { get; set; }

        [Column("DES_REALIZADO")]
        [Required]
        public string DescricaoRealizado { get; set; }

        [ForeignKey("COD_IMPLEMENTACAO")]
        public Implementacao Implementacao { get; set; } 

        [Column("TEMPO")]
        public TimeSpan Tempo { get; set; }

        #endregion Propriedades

        #region Construtores

        public Apontamento()
        {

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