# FNL – Aplikacija za praćenje nogometne statistike

Ovaj projekt je završni rad koji prikazuje izradu malog informacijskog sustava za lokalnu nogometnu ligu. Sustav se sastoji od tri glavna dijela:

- Python web scraping za prikupljanje podataka s interneta
- Microsoft Access baza podataka za pohranu podataka
- C# Windows Forms desktop aplikacija za prikaz informacija

## 1. Uvod

Cilj projekta je omogućiti praćenje rezultata, tablica, igrača, klubova i povijesnih podataka bez ručnog unošenja svih informacija. Podaci se prikupljaju s web stranica, spremaju u lokalnu bazu, a zatim se prikazuju u jednostavnom Windows sučelju.

## 2. Cilj projekta

Glavni cilj je napraviti aplikaciju koja:

- automatski prikuplja nogometne podatke
- pohranjuje ih u relacijsku bazu
- prikazuje ih putem desktop aplikacije
- omogućuje jednostavno ažuriranje baze podataka

## 3. Korištene tehnologije

Python
- koristi se za dohvat i obradu podataka s interneta

requests
- šalje HTTP zahtjeve prema web stranicama

BeautifulSoup
- parsira HTML sadržaj i pronalazi potrebne podatke

pyodbc
- povezuje Python s MS Access bazom

Microsoft Access
- lokalna baza podataka u kojoj se spremaju tablice

C# i Windows Forms
- GUI aplikacija koja čita podatke iz baze i prikazuje ih korisniku

Visual Studio 2022
- razvojno okruženje za C# Windows Forms aplikaciju

## 4. Struktura projekta

Projekt je podijeljen u dvije glavne mape:

- `scraping/` – Python skripte koje skupljaju podatke
- `FNL/` – C# Windows Forms aplikacija i Access baza

U bazi `FNL1.accdb` nalaze se tablice za:
- igrače
- klubove
- utakmice
- statistiku
- ligašku tablicu
- povijesne prvake

## 5. Python skripte

Glavne skripte za prikupljanje podataka:

- `igraci1.py` – podaci o igračima i statistici
- `Tablica1.py` – ligaška tablica
- `Utakmice.py` – raspored i rezultati
- `statistika.py` – detaljni zapisnici utakmica
- `prvaci.py` – povijesni prvaci lige

Skripte preuzimaju HTML stranice, parsiraju podatke i upisuju ih u Access bazu.

## 6. Baza podataka

Pravila baze:
- svaki entitet ima svoju tablicu
- podaci se povezuju pomoću ID-eva
- baza omogućuje brzi pristup podacima za GUI

Korišten je Access zbog jednostavne lokalne primjene i podrške za ODBC.

## 7. Desktop aplikacija

Glavna aplikacija u `FNL/` sadrži više formi:

- Glavni izbornik
- Ligaška tablica
- Raspored i rezultati
- Zapisnik utakmice
- Prikaz igrača
- Klubovi
- Povijest lige
- Povijesni prvaci

Podaci se dohvaćaju iz baze te se prikazuju u tablicama, tekstualnim poljima i slikama.

## 8. Pokretanje

Za pokretanje projekta potrebni su:
- Windows
- Visual Studio 2022
- .NET 8 SDK
- Microsoft Access Database Engine
- Python 3
- `requests`, `beautifulsoup4`, `pyodbc`

Pokretanje aplikacije:

1. Otvori `FNL.sln` u Visual Studiu
2. Pokreni projekt `FNL`

Pokretanje Python skripti:

```powershell
python .\scraping\Tablica1.py
python .\scraping\Utakmice.py
python .\scraping\igraci1.py
python .\scraping\statistika.py
python .\scraping\prvaci.py
```

Prije pokretanja provjeri `accdb` putanju u Python skriptama.

## 9. Zaključak

Projekt dokazuje kako se može izgraditi lokalni sustav za praćenje nogometnih podataka kombinacijom Pythona, Access baze i C# WinForms aplikacije. Sustav je napravljen za jednu lokalnu ligu, ali se lako može prilagoditi drugim natjecanjima promjenom izvora podataka.

This README is written as an anonymous English version of the project documentation. It does not include names, mentor information, index numbers, defense dates, or any other personal academic data.

## 1. Introduction

In the last several decades, software systems have become essential for collecting, storing, searching, filtering, and presenting information. Sports statistics applications are one example of this development because they allow users to follow competitions without manually searching through many different sources.

Football is especially suitable for this type of application. A single league contains a large amount of useful data: clubs, players, fixtures, match results, goals, cards, substitutions, league tables, and historical winners. The goal of this project is to combine these data points into one simple desktop system.

The application focuses on one local football league, but the concept can be adapted to other competitions. If the data source, database records, and display logic are adjusted, the same structure can be reused for another league or even another sport.

## 2. Project Goal

The main goal of the project is to build a desktop application for tracking football statistics and to connect it with a local database. The system also demonstrates how data can be refreshed from internet sources through web scraping.

The project covers these tasks:

- describing the main technologies used in the application
- collecting football data from online sources
- storing collected data in a Microsoft Access database
- connecting the database with a C# Windows Forms application
- displaying league, player, club, match, and historical statistics
- creating a user interface that is simple enough for everyday use

## 3. Technologies Used

### Python

Python is used for the data collection part of the project. It is suitable for this task because it has readable syntax, strong support for working with text and web content, and many libraries that simplify repetitive data processing.

In this project, Python scripts are used to request web pages, parse HTML content, extract the needed values, and write the results into the database.

### Requests

The `requests` library is used to send HTTP requests and download web page content. It allows the scraping scripts to access pages that contain league tables, match details, player profiles, and other football information.

### BeautifulSoup

The `BeautifulSoup` library is used to parse HTML. After a page is downloaded, BeautifulSoup helps locate specific elements inside the HTML structure, such as player names, match results, table rows, club logos, and statistics.

### PyODBC

The `pyodbc` module is used to connect Python scripts with the Microsoft Access database. It allows the scripts to insert new records, update existing data, and refresh tables after new information is collected.

### Microsoft Access

Microsoft Access is used as the local relational database. It stores the data that is collected through Python scripts and later displayed inside the desktop application.

The database contains information such as:

- players and player statistics
- clubs and club details
- league standings
- matches and results
- match reports
- historical champions

### C# and Windows Forms

The graphical user interface is implemented in C# using Windows Forms. This technology is used to create a Windows desktop application with multiple screens, buttons, text fields, tables, images, and navigation between forms.

C# is responsible for reading data from the database, creating objects from database records, and displaying those objects in the correct form.

### Visual Studio

Visual Studio is used for developing and running the Windows Forms application. The solution file and project files are included in the repository.

## 4. Practical Implementation

The practical part of the project is divided into three connected layers:

- data collection through Python web scraping scripts
- data storage in the Microsoft Access database
- data presentation in the C# Windows Forms application

Each layer has a separate role, but the application works only when they are connected. The scraping scripts collect and update the data, the database stores it, and the user interface displays it.

## 5. Web Scraping Layer

The scraping layer is located in the `scraping/` directory. It contains Python scripts that collect different categories of football data.

Main scraping scripts:

- `igraci1.py` collects player information and player statistics
- `Tablica1.py` collects the league table
- `Utakmice.py` collects fixtures and match results
- `statistika.py` collects extended match statistics and match reports
- `prvaci.py` collects historical champion information

The scripts use a browser-like request header when downloading pages. This improves reliability when accessing web pages that expect normal browser traffic. After the HTML content is downloaded, the scripts extract the required data and store it in the database.

Some scripts currently contain absolute paths to the database file. If the project is moved to another computer, those paths may need to be updated before running the scripts.

## 6. Database Layer

The database file is `FNL1.accdb`. It is used as the central storage point for all collected information.

The database keeps the application independent from the scraping process. Once the data is stored, the desktop application can read it without needing to scrape the web every time it starts. This makes the application faster and easier to use.

The C# application accesses the database through `OleDb`, while the Python scripts use `pyodbc`.

## 7. Desktop Application Layer

The desktop application is located in the `FNL/` project directory. It is a Windows Forms application built with C#.

The application contains several forms, each responsible for one part of the system:

- `Form1` is the main menu
- `Form2` displays the league table
- `Form3` displays fixtures and match results
- `Form4` displays a detailed match report
- `Form5` displays players and player statistics
- `Form6` displays clubs and club information
- `Form7` displays league history and informational content
- `Form9` displays historical champions and title rankings

The helper class `funkcije.cs` contains methods that read data from the database and return it as lists of objects. Model classes such as `Igraci.cs`, `Klubovi.cs`, `Utakmica.cs`, and `Zapisnik.cs` represent the main data entities used inside the interface.

## 8. Repository Structure

```text
FNL/
|- FNL.sln
|- FNL1.accdb
|- README.md
|- scraping/
|  |- igraci1.py
|  |- prvaci.py
|  |- statistika.py
|  |- Tablica1.py
|  `- Utakmice.py
`- FNL/
   |- FNL.csproj
   |- Form1.cs
   |- Form2.cs
   |- Form3.cs
   |- Form4.cs
   |- Form5.cs
   |- Form6.cs
   |- Form7.cs
   |- Form9.cs
   |- funkcije.cs
   |- Igraci.cs
   |- Klubovi.cs
   |- Utakmica.cs
   `- Zapisnik.cs
```

## 9. Running the Application

### Requirements

- Windows operating system
- Visual Studio 2022
- .NET 8 SDK
- Microsoft Access Database Engine or compatible Access drivers
- Python 3
- Python packages: `requests`, `beautifulsoup4`, `pyodbc`

### Desktop Application

Open `FNL.sln` in Visual Studio 2022 and run the `FNL` project.

The project can also be built from the command line:

```powershell
dotnet build .\FNL\FNL.csproj
```

### Scraping Scripts

The scraping scripts can be run from the repository root:

```powershell
python .\scraping\Tablica1.py
python .\scraping\Utakmice.py
python .\scraping\igraci1.py
python .\scraping\statistika.py
python .\scraping\prvaci.py
```

Before running the scripts on another machine, check the database path inside the Python files.

## 10. Conclusion

The project shows how a small information system can be built by combining multiple technologies. Python is used for collecting and preparing data, Microsoft Access is used for storing the data, and C# Windows Forms is used for presenting the final result to the user.

The application is designed around one football league, but the structure is flexible enough for future changes. With different data sources and adjustments to the database and interface, the same idea could be expanded to other seasons, leagues, or sports.

Possible improvements include removing absolute database paths from the scraping scripts, adding automatic scheduled updates, supporting multiple seasons, improving filtering options, and separating the data collection logic into a more reusable service.
