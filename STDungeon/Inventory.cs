using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon
{
    // 인벤토리 클래스: 아이템을 관리
    internal class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        // 아이템 추가
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        // 아이템 제거
        public bool RemoveItem(Item item)
        {
            return items.Remove(item);
        }

        // 아이템 목록 반환 (읽기 전용)
        public IReadOnlyList<Item> GetItems()
        {
            return items.AsReadOnly();
        }

        // 인벤토리 내 아이템 개수
        public int Count
        {
            get { return items.Count; }
        }
    }
}
