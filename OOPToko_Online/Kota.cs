using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPToko_Online
{
    internal class Kota
    {
        List<Kota> daftarKota = new List<Kota>();
        public string NamaKota { get; set; }
        public Kota(string inputNamaKota)
        {
            NamaKota = inputNamaKota;
        }
    }
}