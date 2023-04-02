using LibrarieModele;

using System.IO;

namespace NivelStocareDate
{
    public class AdministrareMedicamente_FisierText
    {
        private const int NR_MAX_Medicamente = 50;
        private string numeFisier;

        public AdministrareMedicamente_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddMedicament(Medicament medicament)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(medicament.ConversieLaSir_PentruFisier());
            }
        }

        public Medicament[] CautaMedicamenteDupaNrPastile(out int nr_pastile)
        {
            Medicament[] medicament = new Medicament[NR_MAX_Medicamente];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nr_pastile = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    medicament[nr_pastile++] = new Medicament(linieFisier);
                }

            }return medicament;
        }
            
            public Medicament[] GetmedicamentedinFisier(string numeFisier)
        {
            Medicament[] medicamente = new Medicament[NR_MAX_Medicamente];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                int index_medicament = 0;


                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    medicamente[index_medicament++] = new Medicament(linieFisier);
                }
                return medicamente;
            }   
        }///implementare functie la pct 5
        public Medicament GetMedicament(string nume_medicament, string nr_medicamente)
        {
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                ////
                ///
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Medicament medicament = new Medicament(linieFisier);
                    if (medicament.GetNume_medicament() == nume_medicament && medicament.GetNr_Medicamente() == nr_medicamente)
                    {
                        return medicament;
                    }
                }
            }
            return new Medicament();
        }
    }
}
