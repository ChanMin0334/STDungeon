using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STDungeon.Structs;

namespace STDungeon
{
    internal class Shop
    {
        private List<ItemInfo> itemsForSale;

        public Shop()
        {
            // 판매 가능한 아이템 목록 초기화 (구매완료 아이템은 제외)
            itemsForSale = Items.ItemList.Where(item => item.Price > 0).ToList();
        }

        // 상점 아이템 목록 출력
        public void ShowShopItems(Player player)
        {
            RenderConsole.WriteLine("상점 목록:");
            for (int i = 0; i < itemsForSale.Count; i++)
            {
                var item = itemsForSale[i];
                string statText = item.AttackBonus > 0
                    ? $"공격력 +{item.AttackBonus}"
                    : item.DefenseBonus > 0
                        ? $"방어력 +{item.DefenseBonus}"
                        : "";

                // 인벤토리에 이미 있는지 확인
                bool alreadyOwned = player.Inventory.GetItems().Any(invItem => invItem.Name == item.Name);

                string ownText = alreadyOwned ? " (이미 보유)" : "";
                RenderConsole.WriteLine($"{i + 1}. {item.Name} | {statText} | {item.Description} | {item.Price} G{ownText}");
            }
        }

        // 아이템 구매
        public void BuyItem(Player player, int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= itemsForSale.Count)
            {
                RenderConsole.WriteLine("잘못된 번호입니다.");
                return;
            }

            var item = itemsForSale[itemIndex];

            // 인벤토리에 이미 있는지 확인
            if (player.Inventory.GetItems().Any(invItem => invItem.Name == item.Name))
            {
                RenderConsole.WriteLine("이미 보유한 아이템입니다.");
                return;
            }

            if (player.Gold < item.Price)
            {
                RenderConsole.WriteLine("골드가 부족합니다.");
                return;
            }

            player.Gold -= item.Price;
            player.Inventory.AddItem(item);
            RenderConsole.WriteLine($"{item.Name}을(를) 구매하였습니다!");
        }
    }
}
