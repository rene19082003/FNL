import pyodbc
import requests
from bs4 import BeautifulSoup

# Spoji se na Access bazu
conn = pyodbc.connect(r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\Acer\OneDrive\Desktop\FNL\FNL1.accdb')

cursor = conn.cursor()

# Wikipedia URL
url = "https://hr.wikipedia.org/wiki/Hvarska_nogometna_liga"

# Povuci HTML sadržaj
response = requests.get(url)
soup = BeautifulSoup(response.text, 'html.parser')

# Nađi prvu tablicu s klasom "wikitable"
table = soup.find('table', {'class': 'wikitable'})

# Prođi sve redove tablice
rows = table.find_all('tr')[1:]  # preskoči zaglavlje

# SQL upit
insert_query = """
    INSERT INTO Prvaci (Ime, Sezona)
    VALUES (?, ?)
"""

for row in rows:
    cols = row.find_all('td')
    if len(cols) >= 2:
        sezona = cols[0].get_text(strip=True)
        pobjednik = cols[1].get_text(strip=True)

        # Preskoči redove gdje nema podatka o pobjedniku
        if pobjednik in ['?', 'nije igrano', 'neslužbeno prvenstvo']:
            continue

        try:
            cursor.execute(insert_query, (pobjednik, sezona))
        except Exception as e:
            print(f"Greška kod unosa: {e}, sezona: {sezona}, pobjednik: {pobjednik}")

# Spremi promjene i zatvori konekciju
conn.commit()
cursor.close()
conn.close()

print("Podaci su uspješno uneseni.")
