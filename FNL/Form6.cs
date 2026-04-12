using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FNL
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private static string ImagePath(string fileName)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Slike", fileName);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            postavljanje_teksta();
            postavljanje_slika();
        }
        private void postavljanje_slika()
        {

            string pocetakPath = ImagePath("početak.jpg");
            string fnlPath = ImagePath("fnl1.jpeg");
            string kluboviPath = ImagePath("fnl.jpg");
            string zanimljivostiPath = ImagePath("Zanimljivosti.jpeg");

            if (System.IO.File.Exists(pocetakPath)) pocetno_pb.Image = Image.FromFile(pocetakPath);
            if (System.IO.File.Exists(fnlPath)) fnl_pb.Image = Image.FromFile(fnlPath);
            if (System.IO.File.Exists(kluboviPath)) klubovi_pb.Image = Image.FromFile(kluboviPath);
            if (System.IO.File.Exists(zanimljivostiPath)) zanimljivosti_pb.Image = Image.FromFile(zanimljivostiPath);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox pb)
                {
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.BackColor = Color.LightGray;

                }
            }
        }
        private void postavljanje_teksta()
        {
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is RichTextBox rich)
                {
                    rich.BackColor = Color.White;
                    rich.ForeColor = Color.Black;
                    rich.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    rich.BorderStyle = BorderStyle.FixedSingle;
                    rich.TabStop = false;
                    rich.Cursor = Cursors.Default;
                    rich.GotFocus += (s, e) => this.ActiveControl = null;
                    rich.MouseDown += (s, e) => this.ActiveControl = null;
                    rich.MouseMove += (s, e) => rich.SelectionLength = 0;
                    rich.KeyDown += (s, e) => e.SuppressKeyPress = true;
                    rich.ReadOnly = true;
                }
                else if (ctrl is Label label)
                {
                    label.ForeColor = Color.FromArgb(51, 51, 51);
                    label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.AutoSize = true;
                }
            }
            richTextBox1.Text = "Nogomet– najvažnija sporedna stvar na svijetu." +
           " Igra koju igraju milijuni ljudi diljem svijeta  je važan dio kulture i tradicije u brojnim zemljama. " +
           "Većina nogometnih klubova je osnovana tako što se grupa prijatelja okupila te odlučila formirati svoju momčad. " +
           "Neke momčadi su kroz godine rasle te su sada profesionalni klubovi koje prate milijuni." +
           " Na otoku Hvaru su osnovani brojni klubovi, ali niti jedan nije profesionalan.\r\n\r\n" +
           "Unatoč tome, Hvar ima predivnu nogometnu tradiciju staru čak 110 godina koja prikazuje sve one razloge zbog kojih volimo ovaj sport." +
          "Stari Grad je 1913.bio prvo mjesto na otoku koje je osnovalo nogometne klubove.Časnici austrougarske mornarice su po Starom Gradu igrali i trenirali nogomet.Igru su zvali „balun“ i „fuzbal“ te su joj kasnije dali lokalni naziv „cababin“." +
          " Ovo je potaklo lokalno stanovništvo da osnuju svoje klubove te je 1913.u Starom Gradu postojao klub Balkan te NOIS(Nogometni odjel Hrvatskog Sokola).Prve utakmice u Starom Gradu su se igrale na igralištu Martinovca na kojem su sjedišta za publiku bila napravljena od bačvi i dasaka." +
          "Dvije godine kasnije, autonomaš Vinko Novak je donio prvu nogometnu loptu u Hvar te se ljubav prema nogometu lagano počela širiti po cijelom otoku." +
          "Broj klubova je rastao te su oni većinom međusobno igrali prijateljske utakmice. 18.lipnja 1939.godine je osnovana Hrvatska sportska zajednica otoka Hvara koja je imala 6 klubova.Predsjednik HSZ otoka Hvara je bio ljekarnik iz Starog Grada imena Antun Karlovac." +
          "Cilj je bio da se organizira prvenstvo otoka, što je i realizirano.Prvi prvak otoka Hvara bila je momčad Jelse koja je pobijedila ispred favorizirane momčadi HSK Vala." +
          " Iako je tijekom Drugog svjetskog rata nogomet bio u drugom planu, ljubav stanovnika otoka prema ovom sportu je i dalje bila vidljiva. " +
          "1944.u zbjegu u El Shattu(Egipat) su izbjeglice s Hvara osnovale klub Udarnik koji je čak odigrao utakmicu protiv engleske vojske.";
            richTextBox2.Text = "Nakon Drugog svjetskog rata, na otoku se nastavlja s aktivnim igranjem nogometa." +
                    " Prvenstvo Hvara bi se većinom igralo tako da su klubovi bili podijeljeni u nekoliko skupina te bi najbolja momčad iz svake skupine ostala u igri za titulu prvaka otoka. " +
                    "1960. godine je održan i prvi Kup otoka Hvara, natjecanje koje postoji i dan danas. " +
                    "Veliki problem u ovo vrijeme je bila loša prometna i sportska infrastruktura koja je onemogućavala da svi klubovi na otoku budu uključeni u natjecanje." +
                    " 1969. godine je asfaltirana cesta od Hvara do Sućurja te se stvaraju  preduvjeti za osnivanje Hvarske (Forske) nogometne lige.\r\n\r\n" +
                    "Hvarska nogometna liga (lokalno stanovništvo je zove Forska nogometna liga) je osnovana 1972. godine." +
                    " Postojale su prva i druga liga te se natjecanje igralo ljeti." +
                    " U prvoj sezoni su u prvoj ligi igrale 4 ekipe dok  se u drugoj ligi natjecalo 5 klubova." +
                    " Prvak druge lige bi izborio plasman u prvu ligu dok bi posljednja momčad prvog ranga ispala u nižu ligu. " +
                    "1979. godine je kreiran format lige 10 koja se igra dvokružno te nema ispadanja u niži rang." +
                    " Zbog toga se po otoku u šali govorilo da je Hvarska nogometna liga kao NBA – nitko ne ulazi u nju, nitko ne ispada iz nje." +
                    " Također se promijenio termin igranja prvenstva; umjesto ljeti, posljednje 44 godine Forska liga počinje završetkom jematve (berbe grožđa, krajem rujna) te traje do početka turističke sezone." +
                    " Iste godine je napravljen i novi stadion u Stari Gradu te je liga igrana svake godine. " +
                    "Jedini prekid natjecanja je bio za vrijeme velikosrpske agresije na Hrvatsku (1991. – 1995.).";
            richTextBox3.Text = "U infrastrukturu i klubove se iz godine u godinu sve više ulaže. " +
                "Nevjerojatno je da jedan mali otok koji jedva ima deset tisuća stanovnika ima jedinstvenu ligu s 10 klubova koji igraju svoje utakmice na 5 različitih stadiona. Klubovi su redom:" +
                " Hvar (Hvar), Jadran (Stari Grad), Jelsa (Jelsa), Levanda (Velo Grablje, Hvar), Mladost (Sućuraj), Sloga (Dol, Stari Grad), SOŠK (Svirče, Jelsa), Varbonj (Vrbanj, Stari Grad), Vatra (Poljica, Jelsa) i Vrisnik (Vrisnik, Jelsa)." +
                " Najstariji nogometni klub na otoku koji i danas igra u Hvarskoj nogometnoj ligi je Jelsa. Osnovana je 1921. godine pod imenom Radnik, 1928. mijenja ime u Hajduk, a od 1932. do danas zove se Jelsa." +
                " Varbonj nastaje 1933. pod imenom VŠK, a od 1946. do kraja 80-tih zvao se Partizan. Godine 1936. nastaje Jadran, Sloga (spajanjem DOŠK-a i Zrinskog) i Vatra (gasi se sredinom 60-ih, a obnavlja 1997.). " +
                "Godinu poslije, 1937., nastaju SOŠK i Vrisnik. Vrisnik se prvo zvao Vjetar, a od 1947. Udarnik. NK Hvar osnovan je 1939. pod imenom OŠK Rapid. Klub prestaje s radom početkom Drugog svjetskog rata, a obnavlja se 1958. " +
                "U Hvarskoj nogometnoj ligi je igrao od samih početaka, a nakon što je krajem 90-ih godina 20. st. i početkom 21. st. u dva navrata po nekoliko godina igrao u županijskoj ligi, 2009. ponovo se vratio u FNL. " +
                "Dalje redom nastaju: Mladost iz Sućurja 1948. te Levanda 1971." +
                "Stadioni se nalaze u Starom Gradu (Dolci), Hvaru (Križna Luka), Jelsi (Pelinje), Sućurju (Emil Slavić- Lenko) i Vrbanju (Gorica) te svaki od njih je poseban na svoj način. " +
                "Od stadiona u Hvaru koji uz Križnu luku čini vizuru za brojne razglednice do terena u Sućurju na kojemu golovi nisu u ravnini te je teren često masakriran od strane divljih svinja." +
                " Osim Forske lige, na otoku se van turističke sezone održavaju i brojnu malonogometni turniri i natjecanja „na male branke“. ";
            richTextBox4.Text = "Kroz posljednjih 110 godina nogometa na otoku, desilo se nebrojeno zanimljivih situacija." +
                " Na jednoj utakmici Jadrana u Starom Gradu nije bilo suca, te je odlučeno da Vice Sokol bude djelitelj pravde." +
                " Nesretni Vice nije mogao hodati pa su ga stavili na magarca i dali mu zviždaljku u ruke da sudi." +
                " Vice i magarac su tako na terenu dijelili pravdu, ali igrači ih iz nekog razloga nisu baš slušali." +
                " Na otoku postoje i brojni nadimci, a najzanimljiviji imaju stanovnici Dola." +
                " Zbog sprječavanja nereda od strane komunista za vrijeme izbora 1940. godine, stanovnici ovog malog mjesta su dobili nadimak „Marokanci“" +
                " (referenca na Marokance za vrijeme Španjolskog građanskog rata 1936.-1939.) ." +
                " Doljanima ovaj nadimak nije smetao te su ga objeručke prihvatili. " +
                "Osim što se na utakmicama Sloge znala vidjeti zastava Maroka, jedini kafić u mjestu, u kojem se redovito okupljaju igrači, upravo nosi ime ove afričke države." +
                "Od utakmice u kojoj je sudac „dijelio pravdu“ na magarcu, do 3 igrača Jadrana koja su završili u Hajduku, nogomet na Hvaru skriva brojne priče koje bi se danima mogle prepričavati. " +
                "Veliki broj obitelji na otoku ima po 3 generacije muškaraca koje su igrale Forsku ligu te će u budućnosti taj broj samo rasti. Sada otok vrvi turistima pa je sport trenutno u drugom planu." +
                " Međutim, kada se u devetom mjesecu spusti roleta na još jednu uspješnu turističku sezonu te berba grožđa bude gotova, stanovnici najsunčanijeg otoka u Hrvatskoj će se vikendima opet okupljati na terenima diljem Hvara. " +
                "Rijetko koje mjesto na svijetu gaji ovakvu ljubav prema sportu kao ovaj omaleni otok od 10 tisuća stanovnika. Daleko od plesa milijardi u Premier ligi, stanovnici otoka Hvara ponosno Forsku ligu nazivaju „Drugom najjačom otočkom ligom na svijetu“.";

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
