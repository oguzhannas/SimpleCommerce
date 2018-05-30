using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimpleCommerce.Data.Migrations
{
    public partial class AddSlides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Slide",
                table: "Slide");

            migrationBuilder.RenameTable(
                name: "Slide",
                newName: "Slides");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slides",
                table: "Slides",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Slides",
                table: "Slides");

            migrationBuilder.RenameTable(
                name: "Slides",
                newName: "Slide");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slide",
                table: "Slide",
                column: "Id");
        }
    }
}
