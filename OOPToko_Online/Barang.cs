using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPToko_Online
{
    class Barang
    {
        public string NamaBarang { get; set; }
        public int HargaBarang { get; set; }

        public Barang(string inputNamaBarang, int inputHargaBarang)
        {
            NamaBarang = inputNamaBarang;
            HargaBarang = inputHargaBarang;
        }
    }
}