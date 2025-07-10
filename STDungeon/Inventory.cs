using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon
{
    // �κ��丮 Ŭ����: �������� ����
    internal class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        // ������ �߰�
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        // ������ ����
        public bool RemoveItem(Item item)
        {
            return items.Remove(item);
        }

        // ������ ��� ��ȯ (�б� ����)
        public IReadOnlyList<Item> GetItems()
        {
            return items.AsReadOnly();
        }

        // �κ��丮 �� ������ ����
        public int Count
        {
            get { return items.Count; }
        }
    }
}
