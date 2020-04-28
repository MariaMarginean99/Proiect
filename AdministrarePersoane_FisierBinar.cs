using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public class AdministrarePersoane_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrarePersoane_FisierBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddPersoane(Persoana p)
        {
            throw new Exception("Optiunea AddStudent nu este implementata");
        }

        public Persoana[] GetPersoane(out int nrPersoane)
        {
            throw new Exception("Optiunea GetStudenti nu este implementata");
        }
        public Persoana GetPersoana (string nume, string prenume)
        {
            throw new Exception("Optiunea GetStudent nu este implementata");
        }
    }
}
