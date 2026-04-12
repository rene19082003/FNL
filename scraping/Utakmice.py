import pyodbc
from bs4 import BeautifulSoup
import requests

# Connect to the Access database
conn = pyodbc.connect(r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\Acer\OneDrive\Dokumenti\FNL1.accdb')
cursor = conn.cursor()

# Scrape the page
url = 'https://semafor.hns.family/natjecanja/92155304/fnl-2425/detaljno/'
response = requests.get(url)
soup = BeautifulSoup(response.text, 'html.parser')

# Loop through matches
matches = soup.find_all('li', class_='row visible')
for match in matches:
    # Get the match data
    domacin = match.find('div', class_='club1').text.strip()
    gost = match.find('div', class_='club2').text.strip()
    golovi_domacin = match.find('div', class_='res1').text.strip()
    golovi_gost = match.find('div', class_='res2').text.strip()
    datum = match.find('div', class_='date').text.strip()
    kolo = match.get('data-round') + '. kolo'
    stadion = match.find('div', class_='facility').text.strip()

    # Check if the match already exists in the database
    cursor.execute("""
        SELECT COUNT(*) FROM utakmice 
        WHERE Domacin = ? AND Gost = ? AND Datum_utakmice = ?
    """, (domacin, gost, datum))
    match_exists = cursor.fetchone()[0]

    if match_exists > 0:
        # If match exists, update the existing record
        cursor.execute("""
            UPDATE utakmice
            SET Golovi_domaci = ?, Golovi_gosti = ?, Kolo = ?, Stadion = ?
            WHERE Domacin = ? AND Gost = ? AND Datum_utakmice = ?
        """, (golovi_domacin, golovi_gost, kolo, stadion, domacin, gost, datum))
    else:
        # If match doesn't exist, insert a new record
        cursor.execute("""
            INSERT INTO utakmice (Domacin, Gost, Golovi_domaci, Golovi_gosti, Datum_utakmice, Kolo, Stadion)
            VALUES (?, ?, ?, ?, ?, ?, ?)
        """, (domacin, gost, golovi_domacin, golovi_gost, datum, kolo, stadion))

# Commit and close connection
conn.commit()
conn.close()
