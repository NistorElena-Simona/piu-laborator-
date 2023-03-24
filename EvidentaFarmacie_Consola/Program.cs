using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;

namespace EvidentaFarmacie_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Farmacie farmacie = new Farmacie("Catena");
            


            string numeFisier= ConfigurationManager.AppSettings ["NumeFisier"];
            AdministrareMedicamente_FisierText adminMedicament = new AdministrareMedicamente_FisierText(numeFisier);
            Medicament[] lista_medicamente_fisier = adminMedicament.GetmedicamentedinFisier(numeFisier);
            foreach (Medicament med in lista_medicamente_fisier)
            {
                farmacie.AddMedicament(med);
            }




            int nr_medicamente = 0;
            adminMedicament.CautaMedicamenteDupaNrPastile(out nr_medicamente);
            string optiune;
            do
            {
                Console.WriteLine("I. Adaugare medicament");
                Console.WriteLine("A. Afisare medicamente");
                Console.WriteLine("F. Afisare medicamente din fisier");
                Console.WriteLine("S. Salvare medicament in fisier");
                Console.WriteLine("L. Cauta medicament dupa nume");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "I":
                        int idMedicament = nr_medicamente + 1;

                        Console.Write("Introdu numele medicamentului : ");
                        string nume_medicament = Console.ReadLine();
                        Console.Write("Introdu  cate cutii  : ");
                        string  nr_cutii = Console.ReadLine();
                        Medicament medicament = new Medicament(idMedicament, nume_medicament, nr_cutii);
                        ///ADAUGARE STUDENT IN FISIER
                        adminMedicament.AddMedicament( medicament );
                        nr_medicamente++;
                        idMedicament++;
                        break;
                    case "A":
                        foreach (Medicament med in farmacie.listaMedicamente)
                        {
                            if (med == null) break;

                            Console.WriteLine($"Medicamentul {med.Info()}");

                        }

                        break;
                    case "F":
                        //AfisareMedicamente( nume_medicament, nr_medicamente);

                        break;
                    case "S":
                        int idMedicamente = nr_medicamente + 1;
                        nr_medicamente++;
                        Medicament medicament1 = new Medicament (idMedicamente, "Ibuprofen", "200");
                        //adaugare student in fisier
                        adminMedicament.AddMedicament(medicament1);

                        break;
                    case "L":

                        Console.WriteLine("INTRODUCETI NUMELE Medicamentului:");
                        string nume_cautat = Console.ReadLine();

                        Medicament medicament_gasit = farmacie.GetMedicament(nume_cautat);
                        if (medicament_gasit == null)
                        {
                            Console.WriteLine("Nu exista acest medicament");
                            break;
                        }
                        Console.WriteLine($"Medicament gasit: {medicament_gasit.Info()}");
                        break;

                    case "X":

                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");

                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        //public static void AfisareMedicamente(Medicament[] n, int nr_medicamente)
        //{
            //Console.WriteLine("Studentii sunt:");
            //for (int contor = 0; contor < nr_medicamente; contor++)
            //{
                //string infoStudent = string.Format("Studentul cu id-ul #{0} are numele: {1} {2}",
                   //studenti[contor].GetIdStudent(),
                   //studenti[contor].GetNume() ?? " NECUNOSCUT ",
                   //studenti[contor].GetPrenume() ?? " NECUNOSCUT ");

                //Console.WriteLine(infoMedicament);
           // }
        //}

    
     }
}
