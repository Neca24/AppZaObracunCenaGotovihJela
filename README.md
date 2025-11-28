# AppZaObracunCenaGotovihJela

Ovo je ASP.NET Core MVC aplikacija razvijena u skladu sa Clean Architecture principima, koja omogućava vođenje evidencije i obračun cene koštanja gotovih jela. Sistem omogućava unos artikala, definisanje receptura i automatski proračun cene po porciji na osnovu utrošenih sastojaka, kao ukupnu cenu za traženi broj porcija. Aplikacija je dizajnirana da bude laka za korišćenje i responzivna, sa jasnom podelom na slojeve. 

## Tehnologije
- ASP.NET Core MVC
- Entity Framework (Code-First)
- SQL Server
- Clean Architecture
- Bootstrap 5
- HTML
- CSS
- JavaScript
- C#

## Arhitektura projekta
Projekat koristi Clean Architecture podeljen na:

- **Domain** – entiteti
- **Application** – DTO-ovi, interfejsi, maperi
- **Infrastructure** – EF Core implementacije, DbContext, servisi
- **WebUI** – MVC kontroleri, pogledi i UI

Ovako definisana struktura omogućava jasnu modularnost, testabilnost i lako održavanje.

## Pokretanje projekta
1. Klonirati repozitorijum
2. Pokrenuti rešenje u Visual Studiu 2022
3. Potrebno je pokrenuti skriptu za bazu podataka
4. Podesiti Connection String u appsettings.json
5. Pokrenuti WebUI projekat
