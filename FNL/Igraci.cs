using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FNL
{
    public class Igraci
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Klub { get; set; }
        public string DatumRodjenja { get; set; }
        public string MjestoRodjenja { get; set; }
        public int Nastupi { get; set; }
        public int Zapoceo { get; set; }
        public int UsaoSKlupe { get; set; }
        public int Pogoci { get; set; }
        public int ZutKartoni { get; set; }
        public int CrvKartoni { get; set; }
        public string Slika { get; set; }
        public string GrbKluba { get; set; }

        public Igraci(string ime, string prezime, string klub, string datumRodjenja, string mjestoRodjenja,
                      int nastupi, int zapoceo, int usaoSKlupe, int pogoci, int zutKartoni, int crvKartoni,
                      string slika, string grbKluba)
        {
            Ime = ime;
            Prezime = prezime;
            Klub = klub;
            DatumRodjenja = datumRodjenja;
            MjestoRodjenja = mjestoRodjenja;
            Nastupi = nastupi;
            Zapoceo = zapoceo;
            UsaoSKlupe = usaoSKlupe;
            Pogoci = pogoci;
            ZutKartoni = zutKartoni;
            CrvKartoni = crvKartoni;
            Slika = slika;
            GrbKluba = grbKluba;
        }
        private static readonly HttpClient httpClient = new HttpClient();

        public static Image LoadImageFromUrl(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    return null;

                byte[] imageData = httpClient.GetByteArrayAsync(url).Result;

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom učitavanja slike: " + ex.Message);
                return null;
            }
        }
      

    }
}
