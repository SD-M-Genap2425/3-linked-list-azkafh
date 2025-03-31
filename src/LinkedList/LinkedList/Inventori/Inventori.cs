using System;

namespace LinkedList.Inventori
{
    public class Item
    {
        public string Nama { get; }
        public int Kuantitas { get; }

        public Item(string nama, int kuantitas)
        {
            this.Nama = nama;
            this.Kuantitas = kuantitas;
        }
    }

    public class ManajemenInventori
    {
        private  LinkedList<Item> inventori;

        public ManajemenInventori()
        {
            inventori = new LinkedList<Item>();
        }

        public void TambahItem(Item item)
        {
            inventori.AddLast(item);
        }

        public bool HapusItem(string nama)
        {
            var current = inventori.First;

            while (current != null)
            {
                if(current.Value.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase))
                {
                    inventori.Remove(current);
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public string TampilkanInventori()
        {
            List<string> itemList = new List<string>();

            foreach (var item in inventori)
            {
                itemList.Add($"{item.Nama}; {item.Kuantitas}");
            }
            return string.Join(Environment.NewLine, itemList);
        }

    }
}
