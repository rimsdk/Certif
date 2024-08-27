using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Certif.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AllCertifs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    certifName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    certifUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false),
                    CertifPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllCertifs", x => x.id);
                    table.ForeignKey(
                        name: "FK_AllCertifs_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    certifName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uploadCertiftifUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DepartementId = table.Column<int>(type: "int", nullable: false),
                    achievementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertifPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificats", x => x.id);
                    table.ForeignKey(
                        name: "FK_Certificats_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request_Certifs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    decisionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    required = table.Column<bool>(type: "bit", nullable: false),
                    CertificatId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    AllCertifId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Certifs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Request_Certifs_AllCertifs_AllCertifId",
                        column: x => x.AllCertifId,
                        principalTable: "AllCertifs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Certifs_Certificats_CertificatId",
                        column: x => x.CertificatId,
                        principalTable: "Certificats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_certifId = table.Column<int>(type: "int", nullable: true),
                    DepartementId = table.Column<int>(type: "int", nullable: true),
                    phoneNumer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Users_Request_Certifs_Request_certifId",
                        column: x => x.Request_certifId,
                        principalTable: "Request_Certifs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllCertifs_DepartementId",
                table: "AllCertifs",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificats_DepartementId",
                table: "Certificats",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificats_userId",
                table: "Certificats",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Certifs_AllCertifId",
                table: "Request_Certifs",
                column: "AllCertifId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Certifs_CertificatId",
                table: "Request_Certifs",
                column: "CertificatId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Certifs_ReceiverId",
                table: "Request_Certifs",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Certifs_SenderId",
                table: "Request_Certifs",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartementId",
                table: "Users",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Request_certifId",
                table: "Users",
                column: "Request_certifId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificats_Users_userId",
                table: "Certificats",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Certifs_Users_ReceiverId",
                table: "Request_Certifs",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Certifs_Users_SenderId",
                table: "Request_Certifs",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllCertifs_Departements_DepartementId",
                table: "AllCertifs");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificats_Departements_DepartementId",
                table: "Certificats");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departements_DepartementId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificats_Users_userId",
                table: "Certificats");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Certifs_Users_ReceiverId",
                table: "Request_Certifs");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Certifs_Users_SenderId",
                table: "Request_Certifs");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Request_Certifs");

            migrationBuilder.DropTable(
                name: "AllCertifs");

            migrationBuilder.DropTable(
                name: "Certificats");
        }
    }
}
