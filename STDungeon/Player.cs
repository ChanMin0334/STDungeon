using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon
{
    // 플레이어 클래스: ICreture 인터페이스 구현
    internal class Player : ICreture
    {
        public string Name { get; set; }                // 플레이어 이름
        public int CurrentHP { get; set; }              // 현재 체력
        public StatStruct Stat { get; set; }            // 스탯
        public int Gold { get; set; }                   // 보유 골드
        public Inventory Inventory { get; set; }        // 인벤토리

        public Player(string name, StatStruct stat, int gold)
        {
            Name = name;
            Stat = stat;
            Gold = gold;
            CurrentHP = stat.MaxHP;
            Items = new List<Item>();
            Inventory = new Inventory();
        }
    }
}
