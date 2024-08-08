using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wandermate.backened.Migrations
{
    /// <inheritdoc />
    public partial class reviewssHGCNDVJKKkjdhskkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Hotel_HotelId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "HotelReviews");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_HotelId",
                table: "HotelReviews",
                newName: "IX_HotelReviews_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelReviews",
                table: "HotelReviews",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReviews_Hotel_HotelId",
                table: "HotelReviews",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReviews_Hotel_HotelId",
                table: "HotelReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelReviews",
                table: "HotelReviews");

            migrationBuilder.RenameTable(
                name: "HotelReviews",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_HotelReviews_HotelId",
                table: "Reviews",
                newName: "IX_Reviews_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Hotel_HotelId",
                table: "Reviews",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");
        }
    }
}
