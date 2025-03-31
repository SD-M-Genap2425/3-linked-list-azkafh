using System;

namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul { get; }
        public string Penulis { get; }
        public int Tahun { get; }

        public Buku(string judul, string penulis, int tahun)
        {
            this.Judul = judul;
            this.Penulis = penulis;
            this.Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data { get; }
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            this.Data = buku;
        }
    }

    public class KoleksiPerpustakaan
    {
        private BukuNode head;

        public void TambahBuku (Buku buku)
        {
            BukuNode newBukuNode = new BukuNode(buku);
            if(head == null)
            {
                head = newBukuNode;
                return;
            }

            BukuNode last = GetLastNode();
            last.Next = newBukuNode;
        }

        private BukuNode GetLastNode()
        {
            BukuNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public bool HapusBuku(string judul)
        {
            if(head == null)
            {
                return false;
            }

            if(head.Data.Judul == judul)
            {
                head = head.Next;
                return true;
            }

            BukuNode current = head;

            while (current.Next != null && current.Next.Data.Judul != judul)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                return false;
            }

            current.Next = current.Next.Next;
            return true;
        }

        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> ListBuku = new List<Buku>();
            BukuNode current = head;

            while(current != null)
            {
                if (current.Data.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                {
                    ListBuku.Add(current.Data);
                }
                current = current.Next;
            }
            return ListBuku.ToArray();
        }

        public string TampilkanKoleksi()
        {
            List<string> bukuList = new List<string>();
            BukuNode current = head;

            while (current != null)
            {
                bukuList.Add($"\"{current.Data.Judul}\"; {current.Data.Penulis}; {current.Data.Tahun}");
                current = current.Next;
            }

            return string.Join(Environment.NewLine, bukuList);
        }
    }
}
