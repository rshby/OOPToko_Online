using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPToko_Online
{
    class Controller
    {
        public List<Kota> daftarKota = new List<Kota>();
        public List<Barang> daftarBarang = new List<Barang>();
        public List<Barang> daftarKeranjang = new List<Barang>();

        // Method untuk Barang
        public void LihatBarang()
        {
            for (int i = 0; i < daftarBarang.Count; i++)
            {
                Console.WriteLine($"  {i+1}. {daftarBarang[i].NamaBarang} - Rp.{daftarBarang[i].HargaBarang}");
            }
        }

        public Barang LihatBarangById(int i)
        {
            return daftarBarang[i - 1];
        }

        public void CreateBarang(string inputNamaBarang, int inputHargaBarang)
        {
            Barang newBarang = new Barang(inputNamaBarang, inputHargaBarang);
            daftarBarang.Add(newBarang);
        }

        public void UpdateBarang(int i, string namaBarangBaru, int hargaBarangBaru)
        {
            daftarBarang[i - 1].NamaBarang = namaBarangBaru;
            daftarBarang[i - 1].HargaBarang = hargaBarangBaru;
        }

        public void DeleteBarang(int i)
        {
            daftarBarang.RemoveAt(i - 1);
        }

        // Method untuk Keranjang
        public void CreateDataKeranjang(Barang objBarang)
        {
            daftarKeranjang.Add(objBarang);
        }

        public void LihatDataKeranjang()
        {
            for (int i = 0; i < daftarKeranjang.Count; i++)
            {
                Console.WriteLine($"  {i+1}. {daftarKeranjang[i].NamaBarang} - Rp.{daftarKeranjang[i].HargaBarang}");
            }
        }

        public int TotalKeranjang()
        {
            int total = 0;
            for (int i = 0; i < daftarKeranjang.Count; i++)
            {
                total += daftarKeranjang[i].HargaBarang;
            }
            return total;
        }

        public int HitungKembalian(int inputUangMasuk)
        {
            int kembalian = 0;
            kembalian = inputUangMasuk - TotalKeranjang();
            return kembalian;
        }

        public void CekKembalian(int inputUangMasuk)
        {
            if (inputUangMasuk == TotalKeranjang())
            {
                Console.WriteLine($"  Uang Anda Pas");
            }
            else if (inputUangMasuk > TotalKeranjang())
            {
                Console.WriteLine($"  Anda Mendapatkan Kembalian Rp.{HitungKembalian(inputUangMasuk)}");
            }
        }

        // Method untuk Kota
        public void LihatKota()
        {
            for (int i = 0; i < daftarKota.Count; i++)
            {
                Console.WriteLine($"  {i+1}. {daftarKota[i].NamaKota}");
            }
        }

        public string LihatKotaById(int i)
        {
            string kota = daftarKota[i - 1].NamaKota;
            return kota;
        }

        public void CreateKota(string inputNamaKota)
        {
            Kota newKota = new Kota(inputNamaKota);
            daftarKota.Add(newKota);
        }

        static string TanggalHariIni()
        {
            DateTime tanggalHariIni = DateTime.Now;
            return tanggalHariIni.ToString("dd/MM/yyyy");
        }

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public string Invoice()
        {
            DayOfWeek hariIni = DateTime.Now.DayOfWeek;
            string tahunTanggal = TanggalHariIni().Substring(6) + TanggalHariIni().Substring(3, 2);
            string tanggalRomawi = ToRoman(int.Parse(TanggalHariIni().ToString().Substring(0, 2)));
            string tahunRomawi = ToRoman(int.Parse(TanggalHariIni().ToString().Substring(8)));
            string finalInvoice = $"INV/{tahunTanggal}/{hariIni.ToString().Substring(0, 2).ToUpper()}/{tanggalRomawi}/{tahunRomawi}/1";
            return finalInvoice;
        }

        public void RecipeBarang(int uangMasuk, int kotaTerpilih)
        {
            Console.WriteLine($"  ==== Terimakasih Telah Melakukan Pembelian ====");
            Console.WriteLine($"  {Invoice()}");
            Console.WriteLine($"  Barang : ");
            LihatDataKeranjang();
            Console.WriteLine($"  Total Harga : {TotalKeranjang()}");
            Console.WriteLine($"  Uang : {uangMasuk}");
            Console.WriteLine($"  Dikirim ke : {LihatKotaById(kotaTerpilih)}");
            Console.WriteLine($"  ==============================================");
        }
    }
}