using System;

namespace LibrarieModele
{
    public enum Groups { Family, Friends, Work, TennisTeam };
    public class Persoana
    {

        enum Days { Luni, Marti, Miercuri, Joi, Vineri, Sambata, Duminica }


        public Groups groups;

        //preprietati auto-implemented 
        public static int IdUltimPersoana { get; set; } = 0;
        public string nume { get; set; }
        public string prenume { get; set; }
        public string numar { get; set; }
        public string mail { get; set; }
        public int IdPersoana { get; set; }

        //constructor implicit(Tema laborator2)
        public Persoana()
        {

        }
        //constructor care primeste ca parametru un sir(Tema laborator3)
        public Persoana(string sir)
        {
            string[] cuvinte = sir.Split(',');
            nume = cuvinte[0];
            prenume = cuvinte[1];
            numar = cuvinte[2];
            mail = cuvinte[3];
            IdUltimPersoana++;
            IdPersoana = IdUltimPersoana;
        }
        //constructor cu 3 parametrii(Tema laborator2)
        public Persoana(string _nume,string _prenume, string _numar, string _mail)
        {
            nume = _nume;
            prenume = _prenume;
            numar = _numar;
            mail = _mail;
            IdUltimPersoana++;
            IdPersoana = IdUltimPersoana;
        }
        //constructor cu 4 parametrii(Tema laborator5)
        public Persoana(string _nume,string _prenume, string _numar, string _mail, Groups _groups)
        {
            nume = _nume;
            prenume = _prenume;
            numar = _numar;
            mail = _mail;
            groups = _groups;
            IdUltimPersoana++;
            IdPersoana = IdUltimPersoana;
        }
        public int NameCompare(Persoana p1)
        {
            return nume.CompareTo(p1.nume);
        }
        //Afiseaza datele despre o persoana(Tema laborator 4)
        public string PrintGroup()
        {
            string sir1 = string.Format("{1} {2} face parte din grupul {0}", groups, nume,prenume);
            return sir1;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string sir1;
            if (nume == null || prenume == null || numar == null || mail == null) 
                sir1 = string.Format("Adaugati persoana in agenda prima data");
            else
                sir1 = string.Format("\nPersoana are numele: {0} {1}\nNumarul de telefon: {1}\nEmail-ul: {2}\nFace parte din grupul {3}", nume, numar, mail, groups);
            return sir1;
        }
        //Afisarea datelor despre o persoana plus grupul din care face parte
        public string ConversieLaSir()
        {
            string sir1;
            if (nume == null || prenume == null || numar == null || mail == null)
                sir1 = string.Format("Adaugati persoana in agenda prima data");
            else
                sir1 = string.Format("\nPersoana are numele: {0} {1}\nNumarul de telefon: {1}\nEmail-ul: {2}\nFace parte din grupul {3}", nume, numar, mail, groups);
            return sir1;
        }
        //afisare persoana(Tema laborator 2)
        public string Afisare()
        {
            if (nume == null || prenume == null || numar == null || mail == null)
                return string.Format("Adaugati persoana in agenda prima data");
            else
                return string.Format("\nPersoana are numele: {0} {1}\nNumarul de telefon: {1}\nEmail-ul: {2}", nume, numar, mail);
        }
    }
}
