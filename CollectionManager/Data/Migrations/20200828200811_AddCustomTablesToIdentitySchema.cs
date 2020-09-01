using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionManager.Data.Migrations
{
    public partial class AddCustomTablesToIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    ImageReference = table.Column<string>(nullable: false),
                    CustomFieldsNames_NumberFieldName1 = table.Column<string>(nullable: true),
                    CustomFieldsNames_NumberFieldName2 = table.Column<string>(nullable: true),
                    CustomFieldsNames_NumberFieldName3 = table.Column<string>(nullable: true),
                    CustomFieldsNames_StringFieldName1 = table.Column<string>(nullable: true),
                    CustomFieldsNames_StringFieldName2 = table.Column<string>(nullable: true),
                    CustomFieldsNames_StringFieldName3 = table.Column<string>(nullable: true),
                    CustomFieldsNames_MultilineStringFieldName1 = table.Column<string>(nullable: true),
                    CustomFieldsNames_MultilineStringFieldName2 = table.Column<string>(nullable: true),
                    CustomFieldsNames_MultilineStringFieldName3 = table.Column<string>(nullable: true),
                    CustomFieldsNames_DateFieldName1 = table.Column<string>(nullable: true),
                    CustomFieldsNames_DateFieldName2 = table.Column<string>(nullable: true),
                    CustomFieldsNames_DateFieldName3 = table.Column<string>(nullable: true),
                    CustomFieldsNames_BooleanFieldName1 = table.Column<string>(nullable: true),
                    CustomFieldsNames_BooleanFieldName2 = table.Column<string>(nullable: true),
                    CustomFieldsNames_BooleanFieldName3 = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collections_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 35, nullable: false),
                    CustomFieldsValues_NumberFieldValue1 = table.Column<long>(nullable: true),
                    CustomFieldsValues_NumberFieldValue2 = table.Column<long>(nullable: true),
                    CustomFieldsValues_NumberFieldValue13 = table.Column<long>(nullable: true),
                    CustomFieldsValues_StringFieldValue1 = table.Column<string>(nullable: true),
                    CustomFieldsValues_StringFieldValue2 = table.Column<string>(nullable: true),
                    CustomFieldsValues_StringFieldValue3 = table.Column<string>(nullable: true),
                    CustomFieldsValues_MultilineStringFieldValue1 = table.Column<string>(nullable: true),
                    CustomFieldsValues_MultilineStringFieldValue2 = table.Column<string>(nullable: true),
                    CustomFieldsValues_MultilineStringFieldValue3 = table.Column<string>(nullable: true),
                    CustomFieldsValues_DateFieldValue1 = table.Column<DateTime>(nullable: true),
                    CustomFieldsValues_DateFieldValue2 = table.Column<DateTime>(nullable: true),
                    CustomFieldsValues_DateFieldValue3 = table.Column<DateTime>(nullable: true),
                    CustomFieldsValues_BooleanFieldValue1 = table.Column<bool>(nullable: true),
                    CustomFieldsValues_BooleanFieldValue2 = table.Column<bool>(nullable: true),
                    CustomFieldsValues_BooleanFieldValue3 = table.Column<bool>(nullable: true),
                    CollectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(maxLength: 300, nullable: false),
                    DateOfAdding = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupporterId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 15, nullable: false),
                    TaggedItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Items_TaggedItemId",
                        column: x => x.TaggedItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_OwnerId",
                table: "Collections",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_TopicId",
                table: "Collections",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ItemId",
                table: "Comments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionId",
                table: "Items",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ItemId",
                table: "Likes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TaggedItemId",
                table: "Tags",
                column: "TaggedItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
