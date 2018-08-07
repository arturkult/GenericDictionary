using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dictionaries.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnotherClassSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotherClassSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasicClassSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicClassSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassWithDependencySet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DependencyId = table.Column<int>(nullable: true),
                    AnotherDependencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassWithDependencySet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassWithDependencySet_AnotherClassSet_AnotherDependencyId",
                        column: x => x.AnotherDependencyId,
                        principalTable: "AnotherClassSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassWithDependencySet_BasicClassSet_DependencyId",
                        column: x => x.DependencyId,
                        principalTable: "BasicClassSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassWithDependencySet_AnotherDependencyId",
                table: "ClassWithDependencySet",
                column: "AnotherDependencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWithDependencySet_DependencyId",
                table: "ClassWithDependencySet",
                column: "DependencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassWithDependencySet");

            migrationBuilder.DropTable(
                name: "AnotherClassSet");

            migrationBuilder.DropTable(
                name: "BasicClassSet");
        }
    }
}
