﻿using ControladorProjetos.CamadaModelo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControladorProjetos.CamadaRepositorio
{
    public class ApontamentoContexto : DbContext
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        public DbSet<Implementacao> Implementacoes { get; set; }
        public DbSet<CamadaModelo.Entidades.Apontamento> Apontamentos { get; set; }

        #endregion Propriedades

        #region Construtores

        public ApontamentoContexto(DbContextOptions opcoes) : base(opcoes)
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