using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class relacaoInvoiceItemInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoice_InvoiceId1",
                table: "InvoiceItem");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItem_InvoiceId1",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "InvoiceId1",
                table: "InvoiceItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId1",
                table: "InvoiceItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId1",
                table: "InvoiceItem",
                column: "InvoiceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoice_InvoiceId1",
                table: "InvoiceItem",
                column: "InvoiceId1",
                principalTable: "Invoice",
                principalColumn: "Id");
        }
    }
}
