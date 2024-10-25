using Microsoft.EntityFrameworkCore.Migrations; // Tuodaan tarvittavat kirjastot migraatioiden hallintaan.

#nullable disable // Poistaa nullable-ominaisuuden käytöstä tässä tiedostossa.

namespace UsedPhonesShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySetup : Migration // Tämä luokka vastaa tietokantaan tehtävistä muutoksista, jotka liittyvät Identityn käyttöönottoon.
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) // "Up"-metodi suoritetaan, kun migraatio lisätään tietokantaan. Tähän lisätään kaikki muutokset, jotka tehdään tietokantaan.
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) // "Down"-metodi suoritetaan, kun migraatio peruutetaan (migreerataan taaksepäin). Tähän lisätään kaikki muutokset, jotka kumoavat "Up"-metodissa tehdyt muutokset.
        {

        }
    }
}
