using LinkedList.Inventori;

namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        Perpustakaan.KoleksiPerpustakaan koleksi = new Perpustakaan.KoleksiPerpustakaan();

        koleksi.TambahBuku(new Perpustakaan.Buku("The Hobbit", "J.R.R. Tolkien", 1937));
        koleksi.TambahBuku(new Perpustakaan.Buku("Harry Potter and the Prisoner of Azkaban", "J. K. Rowling", 1999));

        Console.WriteLine("Daftar buku dalam koleksi:");
        koleksi.TampilkanKoleksi();

        Console.WriteLine("\nMencari buku dengan kata kunci 'Potter':");
        var cariBuku = koleksi.CariBuku("Potter");
        foreach (var buku in cariBuku)
        {
            Console.WriteLine($"\"{buku.Judul}\"; {buku.Penulis}; {buku.Tahun}");
        }

        Console.WriteLine("\nMenghapus buku 'The Hobbit':");
        bool hapusBuku = koleksi.HapusBuku("The Hobbit");
        Console.WriteLine(hapusBuku ? "Buku berhasil dihapus." : "Buku tidak ditemukan.");

        Console.WriteLine("\nDaftar buku setelah penghapusan:");
        koleksi.TampilkanKoleksi();


        ManajemenKaryawan.DaftarKaryawan daftar = new ManajemenKaryawan.DaftarKaryawan();

        daftar.TambahKaryawan(new ManajemenKaryawan.Karyawan("001", "Budi Haryono", "Manager"));
        daftar.TambahKaryawan(new ManajemenKaryawan.Karyawan("002", "Dinda Kusuma", "HR"));
        daftar.TambahKaryawan(new ManajemenKaryawan.Karyawan("003", "Arya Putra", "IT"));

        Console.WriteLine("Daftar karyawan:");
        daftar.TampilkanDaftar();

        Console.WriteLine("\nMencari karyawan dengan kata kunci 'IT':");
        var cariKaryawan = daftar.CariKaryawan("IT");
        foreach (var karyawan in cariKaryawan)
        {
            Console.WriteLine($"{karyawan.NomorKaryawan}; {karyawan.Nama}; {karyawan.Posisi}");
        }

        Console.WriteLine("\nMenghapus karyawan dengan nomor '002':");
        bool hapusKaryawan = daftar.HapusKaryawan("002");
        Console.WriteLine(hapusKaryawan ? "Karyawan berhasil dihapus." : "Karyawan tidak ditemukan.");

        Console.WriteLine("\nDaftar karyawan setelah penghapusan:");
        daftar.TampilkanDaftar();


        ManajemenInventori manajemenInventori = new ManajemenInventori();

        manajemenInventori.TambahItem(new Item("Apple", 50));
        manajemenInventori.TambahItem(new Item("Orange", 30));
        manajemenInventori.TambahItem(new Item("Banana", 20));

        Console.WriteLine("Daftar Inventori:");
        manajemenInventori.TampilkanInventori();

        Console.WriteLine("\nMenghapus item 'Orange':");
        bool berhasilHapus = manajemenInventori.HapusItem("Orange");
        Console.WriteLine(berhasilHapus ? "Item berhasil dihapus." : "Item tidak ditemukan.");

        Console.WriteLine("\nDaftar Inventori setelah penghapusan:");
        manajemenInventori.TampilkanInventori();

    }
}
