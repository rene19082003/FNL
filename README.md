# FNL – Football Statistics Tracking Application

This repository contains a student project that implements a desktop application for tracking a local football league. The system connects three main parts:

- Python web scraping for data collection
- Microsoft Access database for data storage
- C# Windows Forms desktop application for data presentation

## 1. Introduction

The goal of the project is to provide a solution for tracking match results, league standings, player stats, club information, and historical champions without manual data entry. Data is collected from the web, stored in a local database, and displayed in a Windows application.

## 2. Project Goal

The main objective is to create an application that:

- automatically collects football data
- stores it in a relational database
- displays data through a desktop interface
- enables data refresh from online sources

## 3. Technologies Used

- Python 3
- requests
- BeautifulSoup
- pyodbc
- Microsoft Access
- C#
- Windows Forms
- Visual Studio 2022
- .NET 8 SDK

## 4. Project Structure

- `scraping/` – Python scripts that collect data from web pages
- `FNL/` – C# Windows Forms application and Access database
- `FNL1.accdb` – main database file
- `README.md` – project documentation

## 5. Python Scripts

The main scraping scripts are:

- `igraci1.py` – player data and statistics
- `Tablica1.py` – league table data
- `Utakmice.py` – fixtures and match results
- `statistika.py` – match reports and detailed statistics
- `prvaci.py` – historical champions

These scripts download HTML pages, extract required values, and insert or update records in the Access database.

## 6. Database Layer

The database file `FNL1.accdb` stores all football data. It contains separate tables for:

- players
- clubs
- matches
- match statistics
- league table
- historical champions

The Access database provides local storage and enables the C# application to read data quickly.

## 7. Desktop Application Layer

The desktop application is built in the `FNL/` project folder using C# and Windows Forms.

The application includes multiple forms:

- main menu
- league table
- fixtures and results
- match report
- players and player statistics
- clubs
- league history
- historical champions

The data access logic is implemented in `funkcije.cs`. Model classes such as `Igraci.cs`, `Klubovi.cs`, `Utakmica.cs`, and `Zapisnik.cs` represent data entities.

## 8. Running the Application

### Requirements

- Windows operating system
- Visual Studio 2022
- .NET 8 SDK
- Microsoft Access Database Engine or compatible Access drivers
- Python 3
- Python packages: `requests`, `beautifulsoup4`, `pyodbc`

### Desktop Application

Open `FNL.sln` in Visual Studio 2022 and run the `FNL` project.

You can also build from the command line:

```powershell
dotnet build .\FNL\FNL.csproj
```

### Scraping Scripts

Run the Python scripts from the repository root:

```powershell
python .\scraping\Tablica1.py
python .\scraping\Utakmice.py
python .\scraping\igraci1.py
python .\scraping\statistika.py
python .\scraping\prvaci.py
```

Check the database file path inside the scripts before running them on another machine.

## 9. Key Notes

- If `FNL1.accdb` is not in the same folder, update the database path in Python scripts.
- The application depends on up-to-date database content.
- The scraping code uses a browser-like User-Agent header for more reliable requests.
- The project is currently designed for one local league but can be adapted to other competitions.

## 10. Conclusion

This project demonstrates how to connect web scraping, local database storage, and a desktop GUI into one functional system. The solution combines Python for data gathering, Microsoft Access for storage, and C# WinForms for presentation.

The architecture is designed for one football league, but the same structure can be reused for other seasons, leagues, or sports with minimal changes.
