using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование"),
                    Icon = table.Column<string>(type: "text", nullable: true, comment: "Иконка")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Имя"),
                    LastName = table.Column<string>(type: "text", nullable: false, comment: "Фамилия"),
                    Patronymic = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true, comment: "Email"),
                    SocialNetworks = table.Column<string[]>(type: "text[]", nullable: true, comment: "Социальные сети"),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false, comment: "Номер телефона")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grounds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование"),
                    Photos = table.Column<string[]>(type: "text[]", nullable: false, comment: "Фотографии"),
                    GeneralDescription = table.Column<string>(type: "text", nullable: false, comment: "Общее описание"),
                    Price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Цена за один timeSlot"),
                    OwenerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grounds_Profiles_OwenerId",
                        column: x => x.OwenerId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroundParameter",
                columns: table => new
                {
                    GroundsId = table.Column<long>(type: "bigint", nullable: false),
                    ParametersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundParameter", x => new { x.GroundsId, x.ParametersId });
                    table.ForeignKey(
                        name: "FK_GroundParameter_Grounds_GroundsId",
                        column: x => x.GroundsId,
                        principalTable: "Grounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroundParameter_Parameters_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Interval = table.Column<TimeSpan>(type: "interval", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    GroundId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlot_Grounds_GroundId",
                        column: x => x.GroundId,
                        principalTable: "Grounds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroundParameter_ParametersId",
                table: "GroundParameter",
                column: "ParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Grounds_Name",
                table: "Grounds",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grounds_OwenerId",
                table: "Grounds",
                column: "OwenerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_GroundId",
                table: "TimeSlot",
                column: "GroundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroundParameter");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Grounds");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
