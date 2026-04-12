using FNL;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;

#pragma warning disable CS8981
public class funkcije
{
    public static string DbPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FNL1.accdb");
    public static string ConnectionString => $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DbPath};";

    public static List<Igraci> DohvatiIgrace()
    {
        List<Igraci> listaIgraca = new List<Igraci>();

        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            try
            {
                connection.Open();
              

                string query = "SELECT Slika,Grb, Ime, Prezime, DatumRodjenja, MjestoRodjenja,Klub, Nastupi, Zapoceo, UsaoSKlupe, Pogoci, ZutKartoni, CrvKartoni FROM Igraci";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Igraci igrac = new Igraci(
                            reader["Ime"].ToString(),
                            reader["Prezime"].ToString(),
                            reader["Klub"].ToString(),
                            reader["DatumRodjenja"].ToString(),
                            reader["MjestoRodjenja"].ToString(),
                            Convert.ToInt32(reader["Nastupi"]),
                            Convert.ToInt32(reader["Zapoceo"]),
                            Convert.ToInt32(reader["UsaoSKlupe"]),
                            Convert.ToInt32(reader["Pogoci"]),
                            Convert.ToInt32(reader["ZutKartoni"]),
                            Convert.ToInt32(reader["CrvKartoni"]),
                            reader["Slika"].ToString(),
                            reader["Grb"].ToString()
                        );

                        listaIgraca.Add(igrac);
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom dohvaćanja podataka: " + ex.Message);
            }

        }

        return listaIgraca;
    }
    public static List<Utakmica> Dohvati_utakmice()
    {
        List<Utakmica> listautakmica = new List<Utakmica>();
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                

                string query = "SELECT Domacin,Gost, Datum_utakmice, Kolo,Stadion, Golovi_domaci, Golovi_gosti, Slika_domaci , Slika_gost FROM Utakmice";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Utakmica utakmica = new Utakmica(
                            reader["Domacin"].ToString(),
                            reader["Gost"].ToString(),
                            reader["Datum_utakmice"].ToString(),
                            reader["Kolo"].ToString(),

                            Convert.ToInt32(reader["Golovi_domaci"]),
                            Convert.ToInt32(reader["Golovi_gosti"]),
                            reader["Stadion"].ToString(),
                            reader["Slika_domaci"].ToString(),
                            reader["Slika_gost"].ToString()

                        );

                        listautakmica.Add(utakmica);
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom dohvaćanja podataka: " + ex.Message);
            }

        }

        return listautakmica;
    }
    public static List<Zapisnik> Dohvati_zapisnike()
    {
        List<Zapisnik> listazapisnika = new List<Zapisnik>();
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                

                string query = "SELECT Domacin, Gost, Datum_utakmice, Kolo, Stadion, Golovi_domaci, Golovi_gosti, Slika_domaci, Slika_gost, " +
                               "Suci, Golovi, zuti_kartoni, crveni_kartoni, izlasci, ulasci FROM Query5";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Zapisnik zapisnik = new Zapisnik(
                            reader["Domacin"].ToString(),
                            reader["Gost"].ToString(),
                            reader["Datum_utakmice"].ToString(),
                            reader["Kolo"].ToString(),
                            Convert.ToInt32(reader["Golovi_domaci"]),
                            Convert.ToInt32(reader["Golovi_gosti"]),
                            reader["Stadion"].ToString(),
                            reader["Slika_domaci"].ToString(),
                            reader["Slika_gost"].ToString(),
                            reader["Suci"].ToString(),
                            reader["Golovi"].ToString(),
                            reader["zuti_kartoni"].ToString(),
                            reader["crveni_kartoni"].ToString(),
                            reader["izlasci"].ToString(),
                            reader["ulasci"].ToString()
                        );

                        listazapisnika.Add(zapisnik); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom dohvaćanja podataka: " + ex.Message);
            }
        }

        return listazapisnika;
    }


    public static List<Klubovi> Dohvati_klubove()
    {
        List<Klubovi> listaklubova = new List<Klubovi>();
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            try
            {
                connection.Open();


                string query = "SELECT Ime,Stadion,Adresa,DatumOsnutka,Grb FROM Klubovi";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Klubovi klub = new Klubovi(
                            reader["Ime"].ToString(),
                            reader["Stadion"].ToString(),
                            reader["Adresa"].ToString(),
                            reader["DatumOsnutka"].ToString(),
                            reader["Grb"].ToString()



                        );

                        listaklubova.Add(klub);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom dohvaćanja podataka: " + ex.Message);
            }
        }

        return listaklubova;
    }
    public static string OcistiNaziv(string naziv)
    {
      
        string pattern = @"\[\d+\]";  

     
        string rezultat = Regex.Replace(naziv, pattern, string.Empty);

        
        rezultat = rezultat.Trim();

        return rezultat;
    }

}
#pragma warning restore CS8981



