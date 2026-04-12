import requests
from bs4 import BeautifulSoup
import pyodbc
import time
import re

# Postavi konekciju na MS Access bazu
DB_PATH = r'C:\Users\Acer\OneDrive\Desktop\FNL\FNL1.accdb'
conn = pyodbc.connect(rf'DRIVER={{Microsoft Access Driver (*.mdb, *.accdb)}};DBQ={DB_PATH}')
cursor = conn.cursor()

# Funkcija za dohvat podataka o igračima sa stranice kluba
def fetch_players_from_club(club_url, processed_players):
    response = requests.get(club_url, headers={"User-Agent": "Mozilla/5.0"})
    if response.status_code == 200:
        soup = BeautifulSoup(response.text, 'html.parser')

        # Naći sve linkove na profile igrača
        player_links = []
        for link in soup.find_all("a", href=True):
            if link['href'].startswith("https://semafor.hns.family/igraci"):
                player_links.append(link['href'])

        for player_link in player_links:
            if player_link in processed_players:
                continue

            fetch_player_data(player_link)
            processed_players.add(player_link)
            time.sleep(2)  # Pauza između dohvaćanja podataka za igrače

    else:
        print(f"❌ Greška pri dohvaćanju stranice kluba: {club_url}")

# Funkcija za dohvat podataka za jednog igrača
def fetch_player_data(player_url):
    response = requests.get(player_url, headers={"User-Agent": "Mozilla/5.0"})
    if response.status_code == 200:
        soup = BeautifulSoup(response.text, 'html.parser')

        # Dohvati ime i prezime
        first_name = soup.find("span", class_="name")
        last_name = soup.find("span", class_="surname")
        first_name = first_name.get_text(strip=True) if first_name else "Nepoznato"
        last_name = last_name.get_text(strip=True) if last_name else "Nepoznato"

        # Dohvati trenutni klub
        club_tag = soup.find("li", class_="club")
        club_name = club_tag.find("h4").get_text(strip=True) if club_tag else "Nepoznato"

        # Dohvati datum rođenja
        dob_tag = soup.find("li", class_="dob")
        date_of_birth = dob_tag.find("h4").get_text(strip=True).split(" (")[0] if dob_tag else "Nepoznato"

        # Dohvati mjesto rođenja
        pob_tag = soup.find("li", class_="pob")
        place_of_birth = pob_tag.find("h4").get_text(strip=True) if pob_tag else "Nepoznato"

        # Dohvati URL slike igrača
        img_tag = soup.find("div", class_="photo").find("img") if soup.find("div", class_="photo") else None
        player_image_url = img_tag["src"] if img_tag and "src" in img_tag.attrs else None

        # Dohvati statistiku igrača za sezonu 2024/2025
        stats = fetch_player_stats_2024_25(soup)

        # Provjeri postoji li igrač već u bazi
        cursor.execute("SELECT COUNT(*) FROM Igraci WHERE Ime = ? AND Prezime = ? AND Klub = ?", (first_name, last_name, club_name))
        player_exists = cursor.fetchone()[0]

        if player_exists > 0:
            update_query = """
                UPDATE Igraci
                SET DatumRodjenja = ?, MjestoRodjenja = ?, Nastupi = ?, Zapoceo = ?, UsaoSKlupe = ?,
                    Pogoci = ?, ZutKartoni = ?, CrvKartoni = ?, Slika = ?
                WHERE Ime = ? AND Prezime = ? AND Klub = ?
            """
            cursor.execute(update_query, (date_of_birth, place_of_birth, stats['apps'], stats['starter'],
                                          stats['sub'], stats['goals'], stats['yellows'], stats['reds'],
                                          player_image_url, first_name, last_name, club_name))
        else:
            insert_query = """
                INSERT INTO Igraci (Slika, Ime, Prezime, Klub, DatumRodjenja, MjestoRodjenja, 
                                    Nastupi, Zapoceo, UsaoSKlupe, Pogoci, ZutKartoni, CrvKartoni)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            """
            cursor.execute(insert_query, (player_image_url, first_name, last_name, club_name, date_of_birth, place_of_birth,
                                          stats['apps'], stats['starter'], stats['sub'],
                                          stats['goals'], stats['yellows'], stats['reds']))

        conn.commit()
    else:
        print(f"❌ Greška pri dohvaćanju podataka sa stranice: {player_url}")

# Funkcija za dohvat statistike za sezonu 2024/2025
def fetch_player_stats_2024_25(soup):
    stats = {"apps": 0, "starter": 0, "sub": 0, "goals": 0, "yellows": 0, "reds": 0}

    # Pronađi sve redove sa statistikom
    rows = soup.find_all("li", class_="row")
    for row in rows:
        # Ako sezona u title-u sadrži "Prvenstvo otoka Hvara 2024/2025"
        title_tag = row.find("div", class_="title")
        if title_tag and "Prvenstvo otoka Hvara 2024/2025" in title_tag.get_text():
            # Provjeriti postoji li vrijednost prije nego što pristupimo get_text
            apps = row.find("div", class_="apps")
            starter = row.find("div", class_="starter")
            sub = row.find("div", class_="sub")
            goals = row.find("div", class_="goals")
            yellows = row.find("div", class_="yellows")
            reds = row.find("div", class_="reds")

            stats["apps"] = int(apps.get_text(strip=True) if apps else 0)
            stats["starter"] = int(starter.get_text(strip=True) if starter else 0)
            stats["sub"] = int(sub.get_text(strip=True) if sub else 0)
            stats["goals"] = int(goals.get_text(strip=True) if goals else 0)
            stats["yellows"] = int(yellows.get_text(strip=True) if yellows else 0)
            stats["reds"] = int(reds.get_text(strip=True) if reds else 0)
            break  # Pronašao smo željenu sezonu, izlazimo iz petlje

    return stats

# Lista URL-ova klubova
club_urls = ["https://semafor.hns.family/klubovi/544/hnk-jadran-sg/",

"https://semafor.hns.family/klubovi/555/nk-jelsa/",
"https://semafor.hns.family/klubovi/535/nk-sosk-svirce/",
"https://semafor.hns.family/klubovi/513/hnk-vatra/",
"https://semafor.hns.family/klubovi/541/nk-vrisnik/",
"https://semafor.hns.family/klubovi/512/nk-varbonj/",
"https://semafor.hns.family/klubovi/506/nk-levanda/",
"https://semafor.hns.family/klubovi/534/nk-sloga-dol-na-hvaru/",
"https://semafor.hns.family/klubovi/525/nk-mladost-sucuraj/"]
# Set za praćenje već obrađenih igrača
processed_players = set()

# Prolazimo kroz sve URL-ove kluba
for club_url in club_urls:
    fetch_players_from_club(club_url, processed_players)

# Zatvori konekciju
cursor.close()
conn.close()
