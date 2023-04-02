using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Farmacie
    {
        public string nume;
        public List<Medicament> listaMedicamente = new List<Medicament>(); 

        public Farmacie(string nume_farmacie) { 
        
            this.nume = nume_farmacie;
        }

        public void AddMedicament(Medicament medicament)
        {
            this.listaMedicamente.Add(medicament);
        }

        public Medicament GetMedicament(string nune_medicament)
        {
            foreach (Medicament me in  this.listaMedicamente)
            {
                if (me == null) break;

                if (me.GetNume_medicament() == nune_medicament)
                    return me;

            }
            return null;
        }
    }
}
