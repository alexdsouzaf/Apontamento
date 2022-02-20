using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControladorProjetos.CamadaModelo.Entidades
{
    [Table("IMPLEMENTACAO")]
    public class Implementacao
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        [Column("COD_PROJETO")]
        [Key]
        public int CodigoImplementacao { get; set; }

        [Column("DES_IMPLEMENTACAO")]
        [Required]
        public string Descricao { get; set; }

        [Column("TEMPO_TOTAL")]
        public TimeSpan TempoTotal { get; set; }

        [Column("COBRADO")]
        public bool Cobrado { get; set; }

        public ICollection<Apontamento> Apontamentos { get; set; }

        #endregion Propriedades

        #region Construtores

        public Implementacao()
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