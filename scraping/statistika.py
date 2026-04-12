import requests
from bs4 import BeautifulSoup
import pyodbc
import time

# Povezivanje s bazom podataka
conn_str = r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\Acer\OneDrive\Dokumenti\FNL1.accdb'
conn = pyodbc.connect(conn_str)
cursor = conn.cursor()
print("Povezivanje s bazom podataka uspješno!")  # Provjera povezivanja

# Glavni URL sa svih utakmica
BASE_URL = "https://semafor.hns.family/natjecanja/92155304/fnl-2425/detaljno/"

# User-Agent header za izbjegavanje blokade botova
HEADERS = {'User-Agent': 'Mozilla/5.0'}

# Funkcija za dohvat svih linkova utakmica
def get_match_links():
    try:
        response = requests.get(BASE_URL, headers=HEADERS)

        if response.status_code != 200:
            print(f"Greška pri dohvaćanju stranice: {response.status_code}")
            return []

        soup = BeautifulSoup(response.content, 'html.parser')

        match_links = []
        for link in soup.find_all('a', href=True):
            if "/utakmice/" in link['href']:
                full_url = link['href'] if link['href'].startswith("https") else "https://semafor.hns.family" + link['href']
                match_links.append(full_url)

        return match_links

    except Exception as e:
        print(f"Greška pri dohvaćanju linkova: {e}")
        return []

# Scrape podataka za svaku utakmicu
def fetch_match_data(url):
    try:
        response = requests.get(url, headers=HEADERS)
        if response.status_code != 200:
            print(f"Greška pri dohvaćanju stranice {url}: {response.status_code}")
            return False

        soup = BeautifulSoup(response.content, 'html.parser')

        # Dohvat podataka s web stranice
        home_team = soup.find('li', class_='club1').find('div', class_='title').text.strip()
        away_team = soup.find('li', class_='club2').find('div', class_='title').text.strip()
        score = soup.find('div', class_='result').text.strip().replace('\n', '').replace('\t', '')
        round_info = soup.find('div', class_='competition-title').find('h2').text.strip()
        referees = soup.find('div', class_='referees').text.strip()

        # Kategorije događaja
        goals, yellow_cards, red_cards, substitutions_in, substitutions_out = [], [], [], [], []

        def clean_player_name(name):
            return name.replace('Vratar', '').replace('Igrač', '').strip()

        events = soup.find_all('li', class_='row match_lineup')
        for event in events:
            player_name = event.find('div', class_='playerName').text.strip()
            player_name = clean_player_name(player_name)
            event_info = event.find('div', class_='matchEvents')

            if event_info:
                for item in event_info.find_all('li'):
                    event_type = item.get('class')[0] if item.get('class') else ''
                    event_time = item.text.strip()

                    if 'goal' in event_type:
                        goals.append(f"{player_name} {event_time}")
                    elif 'yellow' in event_type:
                        yellow_cards.append(f"{player_name} {event_time}")
                    elif 'red' in event_type:
                        red_cards.append(f"{player_name} {event_time}")
                    elif 'substitutionOut' in event_type:
                        substitutions_out.append(f"{player_name} {event_time}")
                    elif 'substitutionIn' in event_type:
                        substitutions_in.append(f"{player_name} {event_time}")

        goals_text = "; ".join(goals)
        yellow_cards_text = "; ".join(yellow_cards)
        red_cards_text = "; ".join(red_cards)
        substitutions_in_text = "; ".join(substitutions_in)
        substitutions_out_text = "; ".join(substitutions_out)

        # Provjera postoji li već zapis za ovu utakmicu
        cursor.execute("SELECT COUNT(*) FROM Statistika WHERE Kolo = ? AND Suci = ? AND Golovi = ? AND zuti_kartoni = ? AND crveni_kartoni = ?",
                       (round_info, referees, goals_text, yellow_cards_text, red_cards_text))
        record_exists = cursor.fetchone()[0] > 0

        if record_exists:
            print(f"Postoji zapis za {round_info} i {referees}, ažuriram.")
            cursor.execute('''UPDATE Statistika
                              SET Golovi = ?, zuti_kartoni = ?, crveni_kartoni = ?, izlasci = ?, ulasci = ? 
                              WHERE Kolo = ? AND Suci = ? AND Golovi = ? AND zuti_kartoni = ? AND crveni_kartoni = ?''',
                           goals_text, yellow_cards_text, red_cards_text, substitutions_out_text, substitutions_in_text,
                           round_info, referees, goals_text, yellow_cards_text, red_cards_text)
            print(f"Ažurirani podaci za utakmicu.")
            conn.commit()
            return True  # Ova utakmica je uspješno ažurirana
        else:
            print(f"Ne postoji zapis za {round_info} i {referees}, unosim novi.")
            cursor.execute('''INSERT INTO Statistika (Kolo, Suci, Golovi, zuti_kartoni, crveni_kartoni, izlasci, ulasci) 
                              VALUES (?, ?, ?, ?, ?, ?, ?)''',
                           round_info, referees, goals_text, yellow_cards_text, red_cards_text, substitutions_out_text, substitutions_in_text)
            print(f"Podaci uneseni.")
            conn.commit()
            return True  # Ova utakmica je uspješno unesena

    except Exception as e:
        print(f"Greška pri obradi utakmice {url}: {e}")
        return False  # Ova utakmica nije unesena zbog greške

# Funkcija za glavni tijek
def main():
    match_links = get_match_links()  # Dohvat svih linkova utakmica
    if match_links:
        print(f"Pronađeno {len(match_links)} utakmica.")
        not_inserted = []  # Lista za pohranu utakmica koje nisu uspješno unesene

        for match_url in match_links:
            print(f"Procesiram: {match_url}")  # Ispisivanje svakog linka
            if not fetch_match_data(match_url):
                not_inserted.append(match_url)  # Ako utakmica nije unesena, dodajemo je u listu neuspješnih

            time.sleep(2)  # Pauza od 2 sekunde između svakog zahtjeva

        if not_inserted:
            print("\nUtakmice koje nisu unesene:")
            for url in not_inserted:
                print(f"- {url}")
        else:
            print("\nSve utakmice su uspješno unesene.")
    else:
        print("Nema utakmica za dohvat.")

# Pokreni program
if __name__ == "__main__":
    main()
