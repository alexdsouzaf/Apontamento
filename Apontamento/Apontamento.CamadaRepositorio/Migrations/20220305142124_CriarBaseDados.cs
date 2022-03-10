using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControladorProjetos.CamadaRepositorio.Migrations
{
    public partial class CriarBaseDados : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "IMPLEMENTACAO",
                columns: table => new
                {
                    COD_PROJETO = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    DES_IMPLEMENTACAO = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    TEMPO_TOTAL = table.Column<TimeSpan>( type: "time", nullable: false ),
                    COBRADO = table.Column<bool>( type: "bit", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_IMPLEMENTACAO", x => x.COD_PROJETO );
                } );

            migrationBuilder.CreateTable(
                name: "APONTAMENTO",
                columns: table => new
                {
                    COD_APONTAMENTO = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    DATA_INICIO = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    DATA_FIM = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    DES_REALIZADO = table.Column<string>( type: "nvarchar(max)", nullable: true ),
                    COD_IMPLEMENTACAO = table.Column<int>( type: "int", nullable: false ),
                    TEMPO = table.Column<TimeSpan>( type: "time", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_APONTAMENTO", x => x.COD_APONTAMENTO );
                    table.ForeignKey(
                        name: "FK_APONTAMENTO_IMPLEMENTACAO_COD_IMPLEMENTACAO",
                        column: x => x.COD_IMPLEMENTACAO,
                        principalTable: "IMPLEMENTACAO",
                        principalColumn: "COD_PROJETO",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateIndex(
                name: "IX_APONTAMENTO_COD_IMPLEMENTACAO",
                table: "APONTAMENTO",
                column: "COD_IMPLEMENTACAO" );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "APONTAMENTO" );

            migrationBuilder.DropTable(
                name: "IMPLEMENTACAO" );
        }
    }
}
