using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPayLite.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDocumentProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Document_value",
                table: "Clients",
                newName: "DocumentValue");

            migrationBuilder.RenameColumn(
                name: "Document_type",
                table: "Clients",
                newName: "DocumentType");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Clients_DocumentValue",
                table: "Clients",
                column: "DocumentValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Clients_DocumentValue",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "DocumentValue",
                table: "Clients",
                newName: "Document_value");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "Clients",
                newName: "Document_type");
        }
    }
}
