using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    public class Klubovi
    {
        public string Ime { get; set; }
        public string Stadion { get; set; }
        public string Adresa { get; set; }
        public string Osnutak { get; set; }
        public string Grb { get; set; }
       



        public Klubovi(string ime,string stadion,string adresa,string datum_osnutka,string grb)
        {
            Ime = ime;
            Stadion = stadion;
            Adresa = adresa;
            Osnutak = datum_osnutka;
            Grb = grb;
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
