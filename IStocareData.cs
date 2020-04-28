using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddPersoane(Persoana p);
        Persoana[] GetPersoane(out int nrPersoane);
        Persoana GetPersoana(string nume, string prenume);
    }
}
