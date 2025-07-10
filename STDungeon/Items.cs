using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon.Structs
{
    // 아이템 목록 클래스
    internal static class Items
    {
        public static readonly ItemInfo[] ItemList =
        {
            new ItemInfo("수련자 갑옷",    900, "수련에 도움을 주는 갑옷입니다.", 0, 5),
            new ItemInfo("무쇠갑옷",       1000,    "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9),
            new ItemInfo("스파르타의 갑옷", 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15),
            new ItemInfo("낡은 검",        600,  "쉽게 볼 수 있는 낡은 검 입니다.", 2, 0),
            new ItemInfo("청동 도끼",      1500, "어디선가 사용됐던거 같은 도끼입니다.", 5, 0),
            new ItemInfo("스파르타의 창",   1600,    "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0)
        };
    }
}
