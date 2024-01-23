using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntertainmentDB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTheModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Origin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Origin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platforms_Companies_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FranchiseId = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Isbn = table.Column<string>(type: "text", nullable: true),
                    Synopsis = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<string>(type: "text", nullable: true),
                    Movie_Synopsis = table.Column<string>(type: "text", nullable: true),
                    Show_Synopsis = table.Column<string>(type: "text", nullable: true),
                    NumberOfSeasons = table.Column<int>(type: "integer", nullable: true),
                    Track_Duration = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FranchisePerson",
                columns: table => new
                {
                    CreatorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    FranchisesCreatedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranchisePerson", x => new { x.CreatorsId, x.FranchisesCreatedId });
                    table.ForeignKey(
                        name: "FK_FranchisePerson_Franchises_FranchisesCreatedId",
                        column: x => x.FranchisesCreatedId,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FranchisePerson_Persons_CreatorsId",
                        column: x => x.CreatorsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserMedia",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavouritesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMedia", x => new { x.ApplicationUserId, x.FavouritesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserMedia_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMedia_Media_FavouritesId",
                        column: x => x.FavouritesId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCompany",
                columns: table => new
                {
                    BooksPublishedId = table.Column<Guid>(type: "uuid", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCompany", x => new { x.BooksPublishedId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_BookCompany_Companies_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCompany_Media_BooksPublishedId",
                        column: x => x.BooksPublishedId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPerson",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPerson", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookPerson_Media_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPerson_Persons_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyGame",
                columns: table => new
                {
                    DevelopersId = table.Column<Guid>(type: "uuid", nullable: false),
                    GamesDevelopedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGame", x => new { x.DevelopersId, x.GamesDevelopedId });
                    table.ForeignKey(
                        name: "FK_CompanyGame_Companies_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyGame_Media_GamesDevelopedId",
                        column: x => x.GamesDevelopedId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyGame1",
                columns: table => new
                {
                    GamesPublishedId = table.Column<Guid>(type: "uuid", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGame1", x => new { x.GamesPublishedId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_CompanyGame1_Companies_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyGame1_Media_GamesPublishedId",
                        column: x => x.GamesPublishedId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMovie",
                columns: table => new
                {
                    MoviesProducedId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProducersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMovie", x => new { x.MoviesProducedId, x.ProducersId });
                    table.ForeignKey(
                        name: "FK_CompanyMovie_Companies_ProducersId",
                        column: x => x.ProducersId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMovie_Media_MoviesProducedId",
                        column: x => x.MoviesProducedId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameMode",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMode", x => new { x.GamesId, x.ModesId });
                    table.ForeignKey(
                        name: "FK_GameMode_Media_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameMode_Modes_ModesId",
                        column: x => x.ModesId,
                        principalTable: "Modes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePerson",
                columns: table => new
                {
                    DirectorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    GamesDirectedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePerson", x => new { x.DirectorsId, x.GamesDirectedId });
                    table.ForeignKey(
                        name: "FK_GamePerson_Media_GamesDirectedId",
                        column: x => x.GamesDirectedId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePerson_Persons_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GamesId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Media_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTrack",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoundtrackId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTrack", x => new { x.GamesId, x.SoundtrackId });
                    table.ForeignKey(
                        name: "FK_GameTrack_Media_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTrack_Media_SoundtrackId",
                        column: x => x.SoundtrackId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMedia",
                columns: table => new
                {
                    GenresId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMedia", x => new { x.GenresId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_GenreMedia_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaTag",
                columns: table => new
                {
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTag", x => new { x.MediaId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_MediaTag_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePerson",
                columns: table => new
                {
                    MoviesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StarsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePerson", x => new { x.MoviesId, x.StarsId });
                    table.ForeignKey(
                        name: "FK_MoviePerson_Media_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePerson_Persons_StarsId",
                        column: x => x.StarsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePerson1",
                columns: table => new
                {
                    MoviesWrittenId = table.Column<Guid>(type: "uuid", nullable: false),
                    WritersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePerson1", x => new { x.MoviesWrittenId, x.WritersId });
                    table.ForeignKey(
                        name: "FK_MoviePerson1_Media_MoviesWrittenId",
                        column: x => x.MoviesWrittenId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePerson1_Persons_WritersId",
                        column: x => x.WritersId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePerson2",
                columns: table => new
                {
                    DirectorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MoviesDirectedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePerson2", x => new { x.DirectorsId, x.MoviesDirectedId });
                    table.ForeignKey(
                        name: "FK_MoviePerson2_Media_MoviesDirectedId",
                        column: x => x.MoviesDirectedId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePerson2_Persons_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTrack",
                columns: table => new
                {
                    MoviesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoundtrackId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTrack", x => new { x.MoviesId, x.SoundtrackId });
                    table.ForeignKey(
                        name: "FK_MovieTrack_Media_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTrack_Media_SoundtrackId",
                        column: x => x.SoundtrackId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonShow",
                columns: table => new
                {
                    ShowsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StarsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonShow", x => new { x.ShowsId, x.StarsId });
                    table.ForeignKey(
                        name: "FK_PersonShow_Media_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonShow_Persons_StarsId",
                        column: x => x.StarsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonShow1",
                columns: table => new
                {
                    CreatorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowsCreatedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonShow1", x => new { x.CreatorsId, x.ShowsCreatedId });
                    table.ForeignKey(
                        name: "FK_PersonShow1_Media_ShowsCreatedId",
                        column: x => x.ShowsCreatedId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonShow1_Persons_CreatorsId",
                        column: x => x.CreatorsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonTrack",
                columns: table => new
                {
                    ArtistsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TracksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTrack", x => new { x.ArtistsId, x.TracksId });
                    table.ForeignKey(
                        name: "FK_PersonTrack_Media_TracksId",
                        column: x => x.TracksId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTrack_Persons_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Synopsis = table.Column<string>(type: "text", nullable: false),
                    SeasonNumber = table.Column<int>(type: "integer", nullable: false),
                    NumberOfEpisodes = table.Column<int>(type: "integer", nullable: false),
                    ShowId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Media_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowTrack",
                columns: table => new
                {
                    ShowsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoundtrackId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTrack", x => new { x.ShowsId, x.SoundtrackId });
                    table.ForeignKey(
                        name: "FK_ShowTrack_Media_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowTrack_Media_SoundtrackId",
                        column: x => x.SoundtrackId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Synopsis = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    EpisodeNumber = table.Column<int>(type: "integer", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMedia_FavouritesId",
                table: "ApplicationUserMedia",
                column: "FavouritesId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCompany_PublishersId",
                table: "BookCompany",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPerson_BooksId",
                table: "BookPerson",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGame_GamesDevelopedId",
                table: "CompanyGame",
                column: "GamesDevelopedId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGame1_PublishersId",
                table: "CompanyGame1",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMovie_ProducersId",
                table: "CompanyMovie",
                column: "ProducersId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_FranchisePerson_FranchisesCreatedId",
                table: "FranchisePerson",
                column: "FranchisesCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMode_ModesId",
                table: "GameMode",
                column: "ModesId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePerson_GamesDirectedId",
                table: "GamePerson",
                column: "GamesDirectedId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTrack_SoundtrackId",
                table: "GameTrack",
                column: "SoundtrackId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMedia_MediaId",
                table: "GenreMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_FranchiseId",
                table: "Media",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_TagsId",
                table: "MediaTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePerson_StarsId",
                table: "MoviePerson",
                column: "StarsId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePerson1_WritersId",
                table: "MoviePerson1",
                column: "WritersId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePerson2_MoviesDirectedId",
                table: "MoviePerson2",
                column: "MoviesDirectedId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTrack_SoundtrackId",
                table: "MovieTrack",
                column: "SoundtrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonShow_StarsId",
                table: "PersonShow",
                column: "StarsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonShow1_ShowsCreatedId",
                table: "PersonShow1",
                column: "ShowsCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTrack_TracksId",
                table: "PersonTrack",
                column: "TracksId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_DeveloperId",
                table: "Platforms",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ShowId",
                table: "Seasons",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTrack_SoundtrackId",
                table: "ShowTrack",
                column: "SoundtrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserMedia");

            migrationBuilder.DropTable(
                name: "BookCompany");

            migrationBuilder.DropTable(
                name: "BookPerson");

            migrationBuilder.DropTable(
                name: "CompanyGame");

            migrationBuilder.DropTable(
                name: "CompanyGame1");

            migrationBuilder.DropTable(
                name: "CompanyMovie");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "FranchisePerson");

            migrationBuilder.DropTable(
                name: "GameMode");

            migrationBuilder.DropTable(
                name: "GamePerson");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GameTrack");

            migrationBuilder.DropTable(
                name: "GenreMedia");

            migrationBuilder.DropTable(
                name: "MediaTag");

            migrationBuilder.DropTable(
                name: "MoviePerson");

            migrationBuilder.DropTable(
                name: "MoviePerson1");

            migrationBuilder.DropTable(
                name: "MoviePerson2");

            migrationBuilder.DropTable(
                name: "MovieTrack");

            migrationBuilder.DropTable(
                name: "PersonShow");

            migrationBuilder.DropTable(
                name: "PersonShow1");

            migrationBuilder.DropTable(
                name: "PersonTrack");

            migrationBuilder.DropTable(
                name: "ShowTrack");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
