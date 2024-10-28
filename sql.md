---

# System.Data.SQLite Lunttilappu

### Peruskomponentit SQLite-tietokannan käyttämiseen C#:ssa

---

## 1. SQLiteConnection
**Yhteyden luominen ja hallinta SQLite-tietokantaan.**
```csharp
var connection = new SQLiteConnection("Data Source=tietokanta.db;Version=3;");
connection.Open();    // Avaa tietokantayhteyden
connection.Close();   // Sulkee tietokantayhteyden
connection.Dispose(); // Vapauttaa yhteyden muistista
```

---

## 2. SQLiteCommand
**SQL-komentojen luominen ja suorittaminen.**
```csharp
var command = new SQLiteCommand("SQL_LAUSE", connection);

// Komennon suorittaminen:
command.ExecuteNonQuery();  // Suorittaa ilman tulosjoukkoa, esim. INSERT, UPDATE, DELETE
command.ExecuteScalar();    // Suorittaa ja palauttaa yhden arvon, esim. COUNT, MAX
command.ExecuteReader();    // Suorittaa ja palauttaa tulosjoukon, esim. SELECT
command.Dispose();          // Vapauttaa komennon muistista
```

---

## 3. SQLiteDataReader
**Tulosjoukon lukeminen rivi kerrallaan.**
```csharp
var reader = command.ExecuteReader();
while (reader.Read())
{
    var value = reader["columnName"]; // Sarakkeen arvo nimellä
    var intValue = reader.GetInt32(0); // Sarakkeen arvo indeksillä
}
reader.Close(); // Sulkee lukijan
```

**Tarkista `NULL` arvot:**
```csharp
bool isNull = reader.IsDBNull(0); // Tarkistaa, onko arvo NULL
```

---

## 4. Parametrit komentoihin
**Tietoturvallinen tapa lisätä parametreja SQL-komentoihin (estää SQL-injektioita).**
```csharp
command.Parameters.AddWithValue("@parametri", arvo);
```

---

## 5. SQLiteTransaction
**Transaktioiden hallinta tietokannassa.**
```csharp
var transaction = connection.BeginTransaction();  // Aloittaa transaktion

// Transaktion vahvistaminen:
transaction.Commit();

// Transaktion peruuttaminen:
transaction.Rollback();

transaction.Dispose(); // Vapauttaa transaktion muistista
```

---

## 6. SQLiteException
**Poikkeusten hallinta tietokantavirheiden varalta.**
```csharp
try
{
    // tietokantaoperaatiot
}
catch (SQLiteException ex)
{
    Console.WriteLine($"Tietokantavirhe: {ex.Message}");
}
```

---

## 7. Esimerkki SQL-kyselystä
```csharp
using (var connection = new SQLiteConnection("Data Source=tietokanta.db;Version=3;"))
{
    connection.Open();
    string sql = "SELECT nimi FROM Lemmikit WHERE id = @id";

    using (var command = new SQLiteCommand(sql, connection))
    {
        command.Parameters.AddWithValue("@id", 1);

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader["nimi"]);
            }
        }
    }
}
```

---

### Yhteenveto

- **Yhteyden hallinta**: `SQLiteConnection`
- **Kyselyiden suorittaminen**: `SQLiteCommand` (ja sen funktiot `ExecuteNonQuery`, `ExecuteScalar`, `ExecuteReader`)
- **Tulosjoukon lukeminen**: `SQLiteDataReader`
- **Transaktiot**: `SQLiteTransaction` (tarvittaessa)
- **Virheiden hallinta**: `SQLiteException`

--- 

