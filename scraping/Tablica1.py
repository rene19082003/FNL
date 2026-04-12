import requests
import pyodbc
from bs4 import BeautifulSoup
import time

# URL ligaške tablice
url = 'https://semafor.hns.family/natjecanja/92155304/fnl-2425/'

# Funkcija za dohvat podataka sa stranice
def fetch_table_data():
    headers = {
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
    }
    response = requests.get(url, headers=headers)

    if response.status_code == 200:
        soup = BeautifulSoup(response.text, 'html.parser')
        table = soup.find('div', class_='competition_table type1')

        if table:
            rows = table.find_all('li', class_='row')
            table_data = []

            for row in rows:
                position = int(row.find('div', class_='position').get_text(strip=True))
                club_name = row.find('div', class_='club').get_text(strip=True)
                played = int(row.find('div', class_='played').get_text(strip=True))
                wins = int(row.find('div', class_='wins').get_text(strip=True))
                draws = int(row.find('div', class_='draws').get_text(strip=True))
                losses = int(row.find('div', class_='losses').get_text(strip=True))
                gplus = int(row.find('div', class_='gplus').get_text(strip=True))
                gminus = int(row.find('div', class_='gminus').get_text(strip=True))
                gdiff = int(row.find('div', class_='gdiff').get_text(strip=True))
                points = int(row.find('div', class_='points').get_text(strip=True))

                # Dohvat URL-a slike grba
                logo_div = row.find('div', class_='logo')
                logo_url = logo_div.find('img')['src'] if logo_div else None

                table_data.append((position, logo_url, club_name, played, wins, draws, losses, gplus, gminus, gdiff, points))

            return table_data
        else:
            print("Tablica nije pronađena na stranici.")
            return None
    else:
        print(f"Neuspješno dohvaćanje podataka. Status kod: {response.status_code}")
        return None

# Funkcija za unos podataka u bazu
def update_database(data):
    try:
        conn = pyodbc.connect(r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\Acer\OneDrive\Desktop\FNL\FNL1.accdb')
        cursor = conn.cursor()

        # Brisanje starih podataka
        cursor.execute("DELETE FROM Ligaska_tablica")
        conn.commit()

        # Unos novih podataka u bazu
        for entry in data:
            cursor.execute("""
                INSERT INTO Ligaska_tablica(Pozicija, Logo_URL, Klub, Nastupi, Pobjede, Neriješeni, Porazi, Postignuti_golovi, Primljeni_golovi, Gol_razlika, Bodovi)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)""",
                entry)

        conn.commit()
        cursor.close()
        conn.close()
        print("Podaci uspješno uneseni u bazu!")
    except Exception as e:
        print(f"Greška pri unosu podataka u bazu: {e}")

# Funkcija za provjeru promjena u tablici
def check_and_update_table():
    table_data = fetch_table_data()

    if table_data:
        try:
            conn = pyodbc.connect(r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\Acer\OneDrive\Desktop\FNL\FNL1.accdb')
            cursor = conn.cursor()

            cursor.execute("SELECT Pozicija, Logo_URL, Klub, Nastupi, Pobjede, Neriješeni, Porazi, Postignuti_golovi, Primljeni_golovi, Gol_razlika, Bodovi FROM Ligaska_tablica")
            current_data = cursor.fetchall()
            cursor.close()

            # Ako broj redaka nije isti ili ako su podaci različiti (ignoriše Klub_ID)
            if len(current_data) != len(table_data) or any(row != current_data[i] for i, row in enumerate(table_data)):
                print("Podaci su promijenjeni, ažuriram bazu...")
                update_database(table_data)
            else:
                print("Podaci nisu promijenjeni, nema potrebe za ažuriranjem.")

        except Exception as e:
            print(f"Greška pri provjeri podataka u bazi: {e}")

# Glavni program
while True:
    check_and_update_table()
    time.sleep(600)
