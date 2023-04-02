using System;

namespace LibrarieModele
{
    public class Medicament
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int NUME_MEDICAMENT = 1;
        private const int NR_MEDICAMENTE = 2;

        private int idMedicamente; //identificator unic medicament
        private string nume_medicament;
        private string nr_medicamente;

        //contructor implicit
        public Medicament()
        {
            nume_medicament =  string.Empty;
          
            idMedicamente = 0;
            idMedicamente = ID;

        }

        //constructor cu parametri
        public Medicament(int idMedicamente, string nume_medicament, string nr_medicamente)
        {
            this.idMedicamente = idMedicamente;
            this.nume_medicament = nume_medicament;
            this.nr_medicamente = nr_medicamente;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Medicament(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idMedicamente = Convert.ToInt32(dateFisier[ID]);
            nume_medicament = dateFisier[NUME_MEDICAMENT];
            nr_medicamente = dateFisier[NR_MEDICAMENTE];
        }

        public string Info()
        {
            string info = string.Format("Id:{0} Nume:{1} Nr: {2}",
                ///interpolarea pentru formatarea șirului
                idMedicamente.ToString().PadLeft(5),
                nume_medicament ?? " NECUNOSCUT ",
                nr_medicamente ?? " NECUNOSCUT ");


            return info;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectMedicamentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idMedicamente.ToString(),
                (nume_medicament ?? " NECUNOSCUT "),
                (nr_medicamente ?? " NECUNOSCUT "));

            return obiectMedicamentPentruFisier;
        }

        public int GetIdMedicament()
        {
            return idMedicamente;
        }

        public string GetNume_medicament()
        {
            return nume_medicament;
        }

        public string GetNr_Medicamente()
        {
            return nr_medicamente;
        }
    }
}

