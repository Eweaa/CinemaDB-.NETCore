using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema_DB.Migrations
{
    /// <inheritdoc />
    public partial class testingmanytomanyrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                table: "ActorMovie");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "ActorMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "ActorsId",
                table: "ActorMovie",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MovieId");

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1L, 2L },
                    { 1L, 4L },
                    { 1L, 5L },
                    { 1L, 6L },
                    { 2L, 7L }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie");

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1L, 4L });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1L, 5L });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1L, 6L });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2L, 7L });

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ActorMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "ActorMovie",
                newName: "ActorsId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesId");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Name" },
                values: new object[] { 9L, 1L, "Taxi Driver" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie",
                column: "ActorsId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                table: "ActorMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
