using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Farmacie
    {
        string denumire;
        int nrPastile;
        public int TipPastile;
        private string _denumire;
        private int _nrPastile;

        public Farmacie()
        {
            denumire = _denumire;
            nrPastile = _nrPastile;
        }
        public Farmacie(string denumire, int nrPastile, int tipPastile)
        {
            _denumire = denumire;
            _nrPastile = nrPastile;
            TipPastile = tipPastile;
            
        }
    }

}
