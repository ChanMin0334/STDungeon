using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon
{
    // 아이템의 기본 정보를 담는 구조체
    internal struct ItemInfo
    {
        public string Name;      // 아이템 이름
        public int Price;        // 아이템 가격
        public int StatBonus;    // 스탯 상승치

        public ItemInfo(string name, int price, int statBonus)
        {
            Name = name;
            Price = price;
            StatBonus = statBonus;
        }
    }

    internal class Item
    {
        public ItemInfo Info { get; private set; }

        public Item(string name, int price, int statBonus)
        {
            Info = new ItemInfo(name, price, statBonus);
        }
    }
}
