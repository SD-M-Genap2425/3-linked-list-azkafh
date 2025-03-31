using System;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; }
        public string Nama { get; }
        public string Posisi { get; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            this.NomorKaryawan = nomorKaryawan;
            this.Nama = nama;
            this.Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan { get; }
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            this.Karyawan = karyawan;
            Next = null;
            Prev = null;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head;
        private KaryawanNode tail;

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newKaryawanNode = new KaryawanNode(karyawan);
            newKaryawanNode.Next = null;
            newKaryawanNode.Prev = tail;

            if (tail != null)
            {
                tail.Next = newKaryawanNode;
            }

            tail = newKaryawanNode;

            if (head == null)
            {
                head = newKaryawanNode;
            }
        }

        public bool HapusKaryawan(string nomorKaryawan)
        {
            KaryawanNode current = head;

            while (current != null)
            {
                if (current.Karyawan.NomorKaryawan == nomorKaryawan)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        tail = current.Prev;
                    }
                    return true;
                }
                current = current.Next;
            }
            return false;

        }

        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> ListKaryawan = new List<Karyawan>();
            KaryawanNode current = head;

            while (current != null)
            {
                if (current.Karyawan.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) || current.Karyawan.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                {
                    ListKaryawan.Add(current.Karyawan);
                }
                current = current.Next;
            }
            return ListKaryawan.ToArray();
        }

        public string TampilkanDaftar()
        {
            List<string> karyawanList = new List<string>();
            KaryawanNode current = tail;

            while (current != null)
            {
                karyawanList.Add($"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}");
                current = current.Prev;
            }

            return string.Join(Environment.NewLine, karyawanList);
        }
    }
}
