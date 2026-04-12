using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    public class Zapisnik:Utakmica
    {

        public string Suci { get; set; }
        public string Golovi { get; set; }
        public string Zuti { get; set; }
        public string Crveni { get; set; }
        public string Izlasci { get; set; }
        public string Ulasci { get; set; }
     


        public Zapisnik(string domacin, string gost, string datum, string kolo, int gdomaci, int ggosti, string stadion, string slika_d, string slika_g,
            string suci , string golovi, string zuti, string crveni, string izlasci, string ulasci) 
            : base(domacin, gost, datum, kolo, gdomaci, ggosti, stadion, slika_d, slika_g)
        {
            Suci = suci;
            Golovi = golovi;
            Zuti = zuti;
            Crveni = crveni;
            Izlasci = izlasci;
            Ulasci = ulasci;
        }
        public static string pretvori_u_redove(string niz)
        {
            string novi = niz.Replace(";", "\n");
            return novi;
            
        }
        private static readonly HttpClient httpClient = new HttpClient();

        public new static Image LoadImageFromUrl(string url)
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
