using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    public partial class initialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalmaListesi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalmaListesi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sanatci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KurulusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanatci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CikisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SanatciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Sanatci_SanatciId",
                        column: x => x.SanatciId,
                        principalTable: "Sanatci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sarki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    SanatciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sarki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sarki_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sarki_Sanatci_SanatciId",
                        column: x => x.SanatciId,
                        principalTable: "Sanatci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalmaListesiSarkilari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalmaListesiId = table.Column<int>(type: "int", nullable: false),
                    SarkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalmaListesiSarkilari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalmaListesiSarkilari_CalmaListesi_CalmaListesiId",
                        column: x => x.CalmaListesiId,
                        principalTable: "CalmaListesi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalmaListesiSarkilari_Sarki_SarkiId",
                        column: x => x.SarkiId,
                        principalTable: "Sarki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_SanatciId",
                table: "Album",
                column: "SanatciId");

            migrationBuilder.CreateIndex(
                name: "IX_CalmaListesiSarkilari_CalmaListesiId",
                table: "CalmaListesiSarkilari",
                column: "CalmaListesiId");

            migrationBuilder.CreateIndex(
                name: "IX_CalmaListesiSarkilari_SarkiId",
                table: "CalmaListesiSarkilari",
                column: "SarkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Sarki_AlbumId",
                table: "Sarki",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Sarki_SanatciId",
                table: "Sarki",
                column: "SanatciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalmaListesiSarkilari");

            migrationBuilder.DropTable(
                name: "CalmaListesi");

            migrationBuilder.DropTable(
                name: "Sarki");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Sanatci");
        }
    }
}
