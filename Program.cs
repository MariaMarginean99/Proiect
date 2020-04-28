using System;
using LibrarieModele;
using NivelAccesDate;

namespace EvidentaStudenti
{
    class Program
    {
        static void Main(string[] args)
        {
            Persoana[] persoane;
            IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();
            int nrPersoane;
            persoane = adminPersoane.GetPersoane(out nrPersoane);
            Persoana.IdUltimPersoana = nrPersoane;
            int i;
            Console.WriteLine("A. Adaugare persoane in agenda\n" +
                 "P. Afiseaza agenda\n" +
                 "C. Citirea unei persoane de la tastatura\n" +
                 "F. Cautare persoane\n"+
                 "N. Compararea a doua persoane dupa nume si afisarea alfabetic\n" +
                 "E. Afisarea grupului din care face parte persoana\n" +
                 "L. Citirea din linia de comanda si afisarea sub forma de matrice alfabetica");
            string optiune;
            bool ok = true;
            do
            {
                Console.WriteLine("\nAlegeti o optiune: ");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "A":
                        persoane[nrPersoane] = new Persoana("Gumina","Sebastian", "0751702564", "sebastian.gumina@student.usv.ro", Groups.Family);
                        adminPersoane.AddPersoane(persoane[nrPersoane]);
                        nrPersoane++;
                        persoane[nrPersoane] = new Persoana("Marginean","Maria", "0742765664", "maria.marginean@student.usv.ro", Groups.TennisTeam);
                        adminPersoane.AddPersoane(persoane[nrPersoane]);
                        nrPersoane++;
                        break;
                    case "P":
                        AfisarePersoana(persoane, nrPersoane);
                        break;
                    case "C":
                        persoane[nrPersoane] = CitirePersoanaTastatura();
                        adminPersoane.AddPersoane(persoane[nrPersoane]);
                        nrPersoane++;
                        break;
                    case "F":
                        Console.WriteLine("Introduceti nume persoana cautata:");
                        string nume_temporar = Console.ReadLine();
                        Console.WriteLine("Introduceti prenume persoana cautata:");
                        string prenume_temporar = Console.ReadLine();
                        Persoana pers_cautat = adminPersoane.GetPersoana(nume_temporar, prenume_temporar);
                        if (pers_cautat != null)
                        {
                            Console.WriteLine("Persoana cautata este: {0}", pers_cautat.ConversieLaSir());
                        }
                        break;
                    case "N":
                        int compare = persoane[0].NameCompare(persoane[1]);
                        if (compare == 1)
                            Console.WriteLine("{1}\n{0}", persoane[0].nume, persoane[1].nume);
                        else
                            if (compare == -1)
                            Console.WriteLine("{0}\n{1}", persoane[0].nume, persoane[1].nume);
                        else
                            Console.WriteLine("Numele este identic {0}", persoane[0].nume);
                        break;
                    case "E":

                        for (i = 0; i < nrPersoane; i++)
                        {
                            Console.WriteLine("Persoana {0}", persoane[i].PrintGroup());
                        }
                        break;
                    case "L":

                        string[,] matLiniaComanda = new string[26, 26];
                        int[] aparitii = new int[26];
                        for (int k = 0; k <= 25; k++)
                            aparitii[k] = 0;
                        if (args.Length == 0)
                            Console.WriteLine("Linia de comanda nu contine argumente");
                        else
                        {
                            Console.WriteLine("Linia de comanda contine :");
                            foreach (string param in args)
                            {
                                string sir = param;
                                string[] cuvinte = sir.Split(' ');
                                foreach (string val in cuvinte)
                                {
                                    if (val[0] >= 'a' && val[0] <= 'z')
                                    {
                                        i = (int)val[0] - 'a';
                                        matLiniaComanda[i, aparitii[i]] = val;
                                        aparitii[i]++;
                                    }
                                    else
                                        if (val[0] >= 'A' && val[0] <= 'Z')
                                    {
                                        i = (int)val[0] - 'A';
                                        matLiniaComanda[i, aparitii[i]] = val;
                                        aparitii[i]++;
                                    }
                                }
                                bool success;
                                for (int row = 0; row <= 25; row++)
                                {
                                    success = false;
                                    for (int col = 0; col < aparitii[row]; col++)
                                    {
                                        Console.Write(matLiniaComanda[row, col] + " ");
                                        success = true;
                                    }
                                    if (success)
                                        Console.WriteLine();
                                }
                            }

                        }
                        break;
                    case "X":
                        ok = false;
                        break;
                    default:
                        Console.WriteLine("Optiune invalida");
                        break;
                }
            } while (ok == true);

            Console.ReadKey();
        }
        //citirea de la tastatura
        public static Persoana CitirePersoanaTastatura()
        {
            Console.WriteLine("Introduceti numele persoanei: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele persoanei: ");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de telefon: ");
            string numar = Console.ReadLine();

            Console.WriteLine("Introduceti mail-ul: ");
            string mail = Console.ReadLine();
            Persoana p = new Persoana(nume,prenume, numar, mail);
            return p;
        }
        //afisarea persoanelor din agenda
        public static void AfisarePersoana(Persoana[] persoane, int nrPersoane)
        {
            Console.WriteLine("Persoanele din agenda sunt: ");
            for (int i = 0; i < nrPersoane; i++)
            {
                Console.WriteLine(persoane[i].ConversieLaSir());
            }
        }

    }

}
