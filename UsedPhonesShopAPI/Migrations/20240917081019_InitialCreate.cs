using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable // Määrittelee, että nullable-huomautuksia ei käytetä tässä tiedostossa.

namespace UsedPhonesShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration // Alustava tietokannan luontimigraatio
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) // Määrittelee toiminnot, jotka suoritetaan tietokannan migraation yhteydessä.
        {
            // Luo taulun nimeltä "AspNetRoles", joka tallentaa käyttäjäroolit.
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    // "Id" on roolin yksilöllinen tunniste (ensisijainen avain).
                    Id = table.Column<string>(type: "TEXT", nullable: false),

                    // "Name" on roolin nimi, maksimipituus 256 merkkiä.
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),

                    // "NormalizedName" on roolin nimi normalisoidussa muodossa, jotta hakeminen on tehokkaampaa.
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),

                    // "ConcurrencyStamp" on tunniste, jota käytetään samanaikaisuuden hallintaan (muutosten konflikti).
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    // Määrittää "Id"-sarakkeen ensisijaiseksi avaimeksi.
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            // Luo taulun nimeltä "AspNetUsers", joka tallentaa käyttäjien tiedot.
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    // "Id" on käyttäjän yksilöllinen tunniste (ensisijainen avain).
                    Id = table.Column<string>(type: "TEXT", nullable: false),

                    // "UserName" on käyttäjän käyttäjänimi.
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),

                    // "NormalizedUserName" on käyttäjänimi normalisoidussa muodossa.
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),

                    // "Email" on käyttäjän sähköpostiosoite.
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),

                    // "NormalizedEmail" on sähköposti normalisoidussa muodossa.
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),

                    // "EmailConfirmed" osoittaa, onko käyttäjä vahvistanut sähköpostinsa.
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),

                    // "PasswordHash" tallentaa käyttäjän salasanan tiivisteen.
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),

                    // "SecurityStamp" on tunniste, jota käytetään turvatarkoituksiin.
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),

                    // "ConcurrencyStamp" on tunniste, jota käytetään samanaikaisuuden hallintaan.
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),

                    // "PhoneNumber" tallentaa käyttäjän puhelinnumeron.
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),

                    // "PhoneNumberConfirmed" osoittaa, onko puhelinnumero vahvistettu.
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),

                    // "TwoFactorEnabled" osoittaa, onko kaksivaiheinen tunnistautuminen käytössä.
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),

                    // "LockoutEnd" määrittelee, milloin käyttäjätilin lukitus päättyy.
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),

                    // "LockoutEnabled" osoittaa, onko tilin lukitus käytössä.
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),

                    // "AccessFailedCount" laskee epäonnistuneet kirjautumisyritykset.
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    // Määrittää "Id"-sarakkeen ensisijaiseksi avaimeksi.
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            // Luo taulun nimeltä "Phones", joka tallentaa puhelintiedot.
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    // "Id" on puhelimen yksilöllinen tunniste (ensisijainen avain).
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),

                    // "Brand" tallentaa puhelimen merkin.
                    Brand = table.Column<string>(type: "TEXT", nullable: false),

                    // "Model" tallentaa puhelimen mallin.
                    Model = table.Column<string>(type: "TEXT", nullable: false),

                    // "Price" tallentaa puhelimen hinnan.
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),

                    // "Condition" tallentaa puhelimen kunnon (esim. uusi, käytetty).
                    Condition = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    // Määrittää "Id"-sarakkeen ensisijaiseksi avaimeksi.
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            // Luo taulun nimeltä "AspNetRoleClaims", joka tallentaa roolien oikeusväitteet (claims).
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    // "Id" on oikeusväitteen yksilöllinen tunniste (ensisijainen avain).
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),

                    // "RoleId" on roolin yksilöllinen tunniste.
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),

                    // "ClaimType" tallentaa väitteen tyypin.
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),

                    // "ClaimValue" tallentaa väitteen arvon.
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    // Määrittää "Id"-sarakkeen ensisijaiseksi avaimeksi ja viittaa "AspNetRoles"-tauluun.
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Luo taulun nimeltä "AspNetUserClaims", joka tallentaa käyttäjien oikeusväitteet (claims).
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    // "Id" on oikeusväitteen yksilöllinen tunniste (ensisijainen avain).
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),

                    // "UserId" on käyttäjän yksilöllinen tunniste.
                    UserId = table.Column<string>(type: "TEXT", nullable: false),

                    // "ClaimType" tallentaa väitteen tyypin.
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),

                    // "ClaimValue" tallentaa väitteen arvon.
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    // Määrittää "Id"-sarakkeen ensisijaiseksi avaimeksi ja viittaa "AspNetUsers"-tauluun.
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Luo taulun "AspNetUserLogins", joka tallentaa käyttäjän kirjautumistiedot eri palveluntarjoajilta.
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    // Määrittää ensisijaiseksi avaimeksi LoginProviderin ja ProviderKeyn.
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    // Viittaa "AspNetUsers"-tauluun.
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Luo taulun "AspNetUserRoles", joka yhdistää käyttäjät ja roolit.
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    // Määrittää ensisijaiseksi avaimeksi UserId:n ja RoleId:n.
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    // Viittaa "AspNetRoles"- ja "AspNetUsers"-tauluihin.
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Luo taulun "AspNetUserTokens", joka tallentaa käyttäjien tunnistetietojen tokenit.
            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    // Määrittää ensisijaiseksi avaimeksi UserId:n, LoginProviderin ja Nimen.
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    // Viittaa "AspNetUsers"-tauluun.
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Lisää indeksit tiettyihin sarakkeisiin hakujen nopeuttamiseksi.
            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) // Määrittelee toiminnot, jotka suoritetaan migraation purkamisen yhteydessä.
        {
            // Poistaa "AspNetRoleClaims"-taulun.
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            // Poistaa "AspNetUserClaims"-taulun.
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            // Poistaa "AspNetUserLogins"-taulun.
            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            // Poistaa "AspNetUserRoles"-taulun.
            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            // Poistaa "AspNetUserTokens"-taulun.
            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            // Poistaa "Phones"-taulun.
            migrationBuilder.DropTable(
                name: "Phones");

            // Poistaa "AspNetRoles"-taulun.
            migrationBuilder.DropTable(
                name: "AspNetRoles");

            // Poistaa "AspNetUsers"-taulun.
            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
