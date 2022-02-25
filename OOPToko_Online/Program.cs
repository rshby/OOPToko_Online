using System;

namespace OOPToko_Online
{
    class Program
    { 
     static void Main(string[] args)
        {
            Controller controller = new Controller();

            controller.CreateKota("Jakarta");
            controller.CreateKota("Bandung");
            controller.CreateKota("Yogyakarta");

            controller.CreateBarang("Kemeja Batik", 100000);
            controller.CreateBarang("Celana Levis", 750000);
            controller.CreateBarang("Jaket Hoodie", 350000);
            
            // Main Program
            bool sedangBelanja = true;
            while (sedangBelanja == true)
            {
                Console.WriteLine($"============================");
                Console.WriteLine($"====== SELAMAT DATANG ======");
                Console.WriteLine($"============================");
                Console.WriteLine($" 1. Login As User");
                Console.WriteLine($" 2. Login As Admin");
                Console.WriteLine($" 3. Keluar");
                Console.Write($" Masukkan Menu : "); int pilihMenu = int.Parse(Console.ReadLine());
                switch (pilihMenu)
                {
                    case 1:
                        bool sedangUser = true;
                        while (sedangUser == true)
                        {
                            Console.Clear();
                            Console.WriteLine($" ===============================");
                            Console.WriteLine($" === Anda Login Sebagai User ===");
                            Console.WriteLine($" ===============================");
                            Console.WriteLine($" 1. Lihat Barang");
                            Console.WriteLine($" 2. Lihat Keranjang");
                            Console.WriteLine($" 3. Proses Pembelian");
                            Console.WriteLine($" 4. Kembali");
                            //
                            Console.Write($"  Masukkan Pilihan : "); int pilihUser = int.Parse(Console.ReadLine());
                            switch (pilihUser)
                            {
                                case 1:
                                    bool userLihat = true;
                                    while (userLihat == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(" ==== Daftar Barang di Toko Kami ====");
                                        controller.LihatBarang();
                                        Console.Write($"  Pilih Barang dan Masukkan ke keranjang : "); int pilihanBarang = int.Parse(Console.ReadLine());
                                        controller.CreateDataKeranjang(controller.LihatBarangById(pilihanBarang));
                                        Console.Write($"  Pilih Barang Lagi? (y/n) : "); char jawabanPilihBarang = char.Parse(Console.ReadLine());
                                        if (jawabanPilihBarang == 'y')
                                        {
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            userLihat = false;
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                case 2:
                                    bool userLihatKeranjang = true;
                                    while (userLihatKeranjang == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($" ==== Keranjang Anda ===");
                                        controller.LihatDataKeranjang();
                                        Console.Write($"  Kembali? (y/n) : "); char jawbanLihatKeranjang = char.Parse(Console.ReadLine());
                                        if (jawbanLihatKeranjang == 'y')
                                        {
                                            userLihatKeranjang = false;
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                case 3:
                                    bool userPembelian = true;
                                    while (userPembelian == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($" === Proses Pembelian ===");
                                        Console.WriteLine($" Daftar Keranjang Anda :");
                                        controller.LihatDataKeranjang();
                                        Console.Write($"  Lanjutkan Proses Pembelian? (y/n) : "); char jawabanPembelian = char.Parse(Console.ReadLine());
                                        if (jawabanPembelian == 'y')
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n");
                                            Console.WriteLine($"  === Konfirmasi Proses Pembelian ==");
                                            Console.WriteLine($"  Total Belanja Anda Adalah : Rp.{controller.TotalKeranjang()}");
                                            Console.Write($"  Masukkan Uang Anda : "); int uangMasuk = int.Parse(Console.ReadLine());
                                            while (uangMasuk < controller.TotalKeranjang())
                                            {
                                                Console.Write($"  Uang Anda Kurang, Masukkan Uang lagi"); uangMasuk = int.Parse(Console.ReadLine());
                                            }
                                            Console.Clear();
                                            controller.CekKembalian(uangMasuk);
                                            Console.WriteLine($"  Pilih Kota Anda : ");
                                            controller.LihatKota(); // Lihat Daftar Kota
                                            Console.Write($"  Masukkan Kota : "); int pilihKota = int.Parse(Console.ReadLine());
                                            Console.Clear();
                                            controller.RecipeBarang(uangMasuk, pilihKota);
                                            Console.Write($"  Kembali Ke Menu? (y/n) : "); char jawabanKembaliMenu = char.Parse(Console.ReadLine());
                                            if (jawabanKembaliMenu == 'y')
                                            {
                                                userPembelian = false;
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                            }
                                        }
                                        else
                                        {
                                            userPembelian = false;
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                case 4:
                                    Console.Write($"  Kembali? (y/n) : "); char jawabKembali = char.Parse(Console.ReadLine());
                                    if (jawabKembali == 'y')
                                    {
                                        sedangUser = false;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                    }
                                    break;

                            }
                        }
                        break;
                    case 2:
                        bool sedangAdmin = true;
                        while (sedangAdmin == true)
                        {
                            Console.Clear();
                            Console.WriteLine($" ==================================");
                            Console.WriteLine($" ==== Anda Login Sebagai Admin ====");
                            Console.WriteLine($" ==================================");
                            Console.WriteLine($"  1. Lihat Barang");
                            Console.WriteLine($"  2. Tambah Barang");
                            Console.WriteLine($"  3. Update Barang");
                            Console.WriteLine($"  4. Hapus Barang");
                            Console.WriteLine($"  5. Kembali");
                            Console.Write($"   Masukkan Menu : "); int pilihMenuAdmin = int.Parse(Console.ReadLine());
                            switch (pilihMenuAdmin)
                            {
                                case 1:
                                    bool lihatBarang = true;
                                    while (lihatBarang == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($" ===============================");
                                        Console.WriteLine($" ==== Stock Barang Yang Ada ====");
                                        Console.WriteLine($" ===============================");
                                        controller.LihatBarang();
                                        Console.Write($" kembali? (y/n) : "); char KembaliKeAdmin = char.Parse(Console.ReadLine());
                                        if (KembaliKeAdmin == 'y')
                                        {
                                            lihatBarang = false;
                                        }
                                    }
                                    break;
                                case 2:
                                    bool createBarang = true;
                                    while (createBarang == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($" === Proses Input Barang ===");
                                        Console.Write($"  Masukkan Nama Barang : "); string namaBarang = Console.ReadLine();
                                        Console.Write($"  Masukkan Harga Barang : "); int hargaBarang = int.Parse(Console.ReadLine());
                                        controller.CreateBarang(namaBarang, hargaBarang);
                                        Console.WriteLine($"  Barang {namaBarang} sudah berhasil diinput");
                                        Console.Write($"  Masukkan Barang Lagi? (y/n) : "); char jawabanCreateBarang = char.Parse(Console.ReadLine());
                                        if (jawabanCreateBarang == 'n')
                                        {
                                            createBarang = false;
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                case 3:
                                    bool updateBarang = true;
                                    while (updateBarang == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"  === Update Barang Yang Ada ===");
                                        controller.LihatBarang();
                                        Console.Write($"  Pilih Barang : "); int pilihanBarang = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                        Console.WriteLine($"  Barang {controller.LihatBarangById(pilihanBarang).NamaBarang} akan diupdate");
                                        Console.Write($"  Masukkan Nama Barang : "); string namaBarangBaru = Console.ReadLine();
                                        Console.Write($"  Masukkan Harga Barang : "); int hargaBarangBaru = int.Parse(Console.ReadLine());
                                        controller.UpdateBarang(pilihanBarang, namaBarangBaru, hargaBarangBaru);
                                        Console.WriteLine("  Barang Berhasil diupdate");
                                        Console.Write($"  Update Barang Lagi?(y/n) : "); char jawabanUpdateBarang = char.Parse(Console.ReadLine());
                                        if (jawabanUpdateBarang == 'y')
                                        {
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            updateBarang = false;
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                case 4:
                                    bool hapusBarang = true;
                                    while (hapusBarang == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"  === Pilih Barang yang Akan Dihapus ===");
                                        controller.LihatBarang();
                                        Console.Write($"  Pilih Barang : "); int pilihanHapus = int.Parse(Console.ReadLine());
                                        controller.DeleteBarang(pilihanHapus);
                                        Console.WriteLine($"  Barang Sudah dihapus");
                                        Console.Write($"  Apakah Ingin Menghapus Barang Lagi? (y/n) : "); char jawabanHapus = char.Parse(Console.ReadLine());
                                        if (jawabanHapus == 'y')
                                        {
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            hapusBarang = false;
                                            Console.Clear();
                                        }
                                    }
                                    break;
                                case 5:
                                    Console.Write($" kembali? (y/n) : "); char KembaliKeMenu = char.Parse(Console.ReadLine());
                                    if (KembaliKeMenu == 'y')
                                    {
                                        sedangAdmin = false;
                                        Console.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.Write($" Yakin ingin Keluar Aplikasi? (y/n) : "); char jawabanKeluar = char.Parse(Console.ReadLine());
                        if (jawabanKeluar == 'y')
                        {
                            sedangBelanja = false;
                        }
                        else
                        {
                            Console.Clear();
                        }
                        break;
                }
            }
            // End Main Program
        }
    }
}