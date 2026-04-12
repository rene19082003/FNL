using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    public class Utakmica
    {
        public string Domacin { get; set; }
        public string Gost { get; set; }
        public string Datum { get; set; }
        public string Kolo { get; set; }
        public int Golovi_domaci { get; set; }
        public int  Golovi_gosti { get; set; }
        public string Stadion { get; set; }
        public string Slika_kluba_domacin { get; set; }
        public string Slika_kluba_gost { get; set; }
  

        public Utakmica(string domacin,string gost, string datum,string kolo,int gdomaci,int ggosti,string stadion,string slika_d,string slika_g)
        {
            Domacin = domacin;
            Gost = gost;
            Datum = datum;
            Kolo = kolo;
            Golovi_domaci = gdomaci;
            Golovi_gosti = ggosti;
            Stadion = stadion;
            Slika_kluba_domacin = slika_d;
            Slika_kluba_gost = slika_g;
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
