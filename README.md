# GymPortal

## Projektbeskrivning

GymPortal är en webbapplikation byggd i ASP.NET Core MVC där användare kan registrera konto, logga in, skapa medlemskap, boka träningspass och hantera sin profil.

Projektet är uppbyggt med en struktur inspirerad av Domain-Driven Design (DDD) och Clean Architecture där ansvar delas upp mellan flera projekt/lager.

---

# Funktioner

## Konto och autentisering

* Registrera konto
* Logga in / logga ut
* ASP.NET Core Identity
* Redigera profil
* Ta bort konto

## Medlemskap

* Skapa medlemskap
* Visa aktivt medlemskap
* Kontroll av medlemskapsstatus

## Träningspass

* Visa träningspass
* Boka träningspass
* Avboka träningspass
* Skydd mot dubbelbokning

## Min sida

* Visa användaruppgifter
* Visa medlemskap
* Visa bokningar

## Databas

* Entity Framework Core
* SQL Server
* Code First
* DbContext
* Migrationer

## Tester

* Enhetstester för medlemskap

---

# Tekniker

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* Razor Views
* xUnit
* GitHub

---

# Projektstruktur

## GymPortal.Web

Innehåller controllers, views och frontend.

## GymPortal.Domain

Innehåller entiteter och domänlogik.

## GymPortal.Infrastructure

Innehåller databas och Identity.

## GymPortal.Application

Används för applikationslogik.

## GymPortal.Tests

Innehåller tester.

---

# AI-Användning

AI användes främst som stöd för frontend och designrelaterade delar av projektet.

Det användes bland annat för:

* hjälp med att strukturera CSS
* layout och spacing utifrån Figma-designen
* förbättring av responsivitet och UI
* strukturering av vissa Razor Views
* mindre felsökning i controllers och validering

Den största delen av AI-användningen handlade alltså om att effektivisera designarbetet och frontend-strukturen snarare än att automatiskt bygga hela backend-logiken.

Backend, routing, databasrelationer och Identity-funktionalitet har testats, justerats och anpassats manuellt under utvecklingen.

All kod har granskats och modifierats för att passa projektets struktur och krav.

---

# Starta projektet

## Kör migrationer

```bash
Add-Migration InitialCreate
Update-Database
```

## Starta projektet

```bash
dotnet run
```

---

# Självutvärdering

## Vad som fungerade bra

Jag tycker att jag lyckades bygga de viktigaste funktionerna i systemet såsom registrering, inloggning, medlemskap och bokning av träningspass. Jag lyckades även få applikationen att följa designen från Figma relativt bra.

En stor hjälp under frontend-arbetet var användning av AI som stöd för layout, CSS-struktur och vissa designrelaterade delar. Det gjorde det lättare att arbeta snabbare med spacing, sektioner och struktur i Razor Views.

Jag tycker också att projektstrukturen blev tydligare än tidigare projekt eftersom jag arbetade med flera lager istället för att lägga all kod i samma projekt.

---

## Utmaningar

Det svåraste var:

* routing och controllers
* att förstå Identity
* kopplingar mellan användare och databasen
* Entity Framework migrations
* att få views och controllers att fungera tillsammans

Jag hade också problem med vissa felmeddelanden och routes i början men lärde mig felsöka dem steg för steg.

---

## Vad jag lärde mig

Under projektet lärde jag mig:

* hur ASP.NET MVC är uppbyggt
* hur controllers och views samarbetar
* hur databaser används med EF Core
* hur autentisering fungerar med Identity
* hur man skyddar sidor med Authorize
* grundläggande Clean Architecture och DDD

Jag blev också bättre på Git och versionshantering.

---

## Vad som hade kunnat förbättras

Om jag hade haft mer tid hade jag velat:

* lägga till fler tester
* förbättra validering och felhantering
* göra bokningssystemet mer avancerat
* förbättra responsiv design för mobil
* lägga till adminfunktioner

---

## Sammanfattning

Projektet hjälpte mig att förstå hur en större ASP.NET Core-applikation byggs upp från backend till frontend. Jag känner att jag fått bättre förståelse för MVC, databaser och autentisering samt hur olika delar i ett system kopplas ihop.
