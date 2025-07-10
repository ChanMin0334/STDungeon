using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon
{
    internal class GameManager
    {
        public Player Player { get; private set; }

        // 게임 초기화
        public void InitializeGame()
        {
            Console.Write("플레이어 이름을 입력하세요: ");
            string name = Console.ReadLine();

            RenderConsole.WriteLine("직업을 선택하세요:");
            RenderConsole.WriteLine("1. 전사");
            RenderConsole.WriteLine("   - 공격력: 10, 방어력: 5, 체력: 100, 마나: 30");
            RenderConsole.WriteLine("   - 설명: 튼튼한 방어와 무난한 공격력을 가진 근접 전투 전문가");
            RenderConsole.WriteLine("   - 초기 장비: 없음");
            RenderConsole.WriteLine("2. 도적");
            RenderConsole.WriteLine("   - 공격력: 14, 방어력: 3, 체력: 100, 마나: 40");
            RenderConsole.WriteLine("   - 설명: 빠른 공격과 높은 기동성을 가진 치명적인 암살자");
            RenderConsole.WriteLine("   - 초기 장비: 없음");

            IJob selectedJob = null;
            while (selectedJob == null)
            {
                Console.Write("번호를 입력하세요 (1 또는 2): ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    selectedJob = new WarriorJob();
                }
                else if (input == "2")
                {
                    selectedJob = new ThiefJob();
                }
                else
                {
                    RenderConsole.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                }
            }

            Player = new Player(name, 1500, selectedJob);
            RenderConsole.WriteLine($"{name}님, {(selectedJob is WarriorJob ? "전사" : "도적")}로 시작합니다!");
        }


        // 게임 시작
        public void StartGame()
        {
            RenderConsole.WriteLine("게임을 시작합니다!");

            while (true)
            {
                RenderConsole.WriteEmptyLine();
                RenderConsole.WriteLine("무엇을 하시겠습니까?");
                RenderConsole.WriteLine("1. 상태보기");
                RenderConsole.WriteLine("2. 인벤토리");
                RenderConsole.WriteLine("3. 상점");
                RenderConsole.WriteLine("0. 게임 종료");
                Console.Write("선택: ");
                string input = Console.ReadLine();

                Console.Clear(); // 선택 후 콘솔 전체 지우기

                switch (input)
                {
                    case "1":
                        ShowPlayerStatus();
                        break;
                    case "2":
                        ShowInventory();
                        break;
                    case "3":
                        ShowShop();
                        break;
                    case "0":
                        EndGame();
                        return;
                    default:
                        RenderConsole.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                        break;
                }
            }
        }

        // 상점 출력 및 구매 기능
        public void ShowShop()
        {
            Shop shop = new Shop();

            while (true)
            {
                Console.Clear();
                shop.ShowShopItems(Player);
                RenderConsole.WriteLine($"보유 골드: {Player.Gold}");
                RenderConsole.WriteLine("구매할 아이템 번호를 입력하세요. (0 입력 시 상점 나가기)");
                Console.Write("선택: ");
                string input = Console.ReadLine();

                if (input == "0")
                    break;

                int itemIndex;
                if (int.TryParse(input, out itemIndex))
                {
                    itemIndex -= 1; // 배열 인덱스 보정
                    shop.BuyItem(Player, itemIndex);
                }
                else
                {
                    RenderConsole.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                }

                RenderConsole.WriteLine("계속하려면 Enter를 누르세요...");
                Console.ReadLine();
            }
            Console.Clear();
        }



        // 플레이어 상태 출력
        public void ShowPlayerStatus()
        {
            RenderConsole.WriteLine($"이름: {Player.Name}");
            RenderConsole.WriteLine($"체력: {Player.CurrentHP} / {Player.Stat.MaxHP}");
            RenderConsole.WriteLine($"마나: {Player.CurrentMP} / {Player.Stat.MaxMP}");

            // 아이템 추가 공격력/방어력이 있을 때만 괄호로 표시
            string attackText = Player.ItemAttackBonus > 0
                ? $" +({Player.ItemAttackBonus})"
                : "";
            string defenseText = Player.ItemDefenseBonus > 0
                ? $" +({Player.ItemDefenseBonus})"
                : "";

            RenderConsole.WriteLine($"공격력: {Player.Stat.Attack + Player.ItemAttackBonus}{attackText}");
            RenderConsole.WriteLine($"방어력: {Player.Stat.Defense + Player.ItemDefenseBonus}{defenseText}");
            RenderConsole.WriteLine($"골드: {Player.Gold}");

            if (Player != null && Player.Job != null)
            {
                RenderConsole.WriteLine("스킬 목록:");
                RenderConsole.WriteLine($"  1. {Player.Job.Skill1.Name} - {Player.Job.Skill1.Effect} (배수: {Player.Job.Skill1.Multiplier}, 마나 소모: {Player.Job.Skill1.ManaCost})");
                RenderConsole.WriteLine($"  2. {Player.Job.Skill2.Name} - {Player.Job.Skill2.Effect} (배수: {Player.Job.Skill2.Multiplier}, 마나 소모: {Player.Job.Skill2.ManaCost})");
            }
        }


        // 인벤토리 출력 및 장착/해제
        public void ShowInventory()
        {
            Player.Inventory.ShowAndEquip(Player);

            // 장착된 아이템의 보너스를 괄호로 표시
            var (equippedAttack, equippedDefense) = Player.Inventory.GetEquippedBonus();
            string attackText = equippedAttack > 0
                ? $" (추가 +{equippedAttack})"
                : "";
            string defenseText = equippedDefense > 0
                ? $" (추가 +{equippedDefense})"
                : "";

            RenderConsole.WriteLine($"공격력: {Player.Stat.Attack}{attackText}");
            RenderConsole.WriteLine($"방어력: {Player.Stat.Defense}{defenseText}");
        }

        // 전투 시작 (예시)
        public void StartBattle()
        {
            RenderConsole.WriteLine("전투가 시작됩니다! (전투 로직은 추후 구현)");
        }

        // 아이템 사용 (예시)
        public void UseItem()
        {
            RenderConsole.WriteLine("사용할 아이템 번호를 입력하세요:");
            var items = Player.Inventory.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                RenderConsole.WriteLine($"{i + 1}. {items[i].Name}");
            }
            // 실제 사용 로직은 추후 구현
        }

        // 게임 종료
        public void EndGame()
        {
            RenderConsole.WriteLine("게임을 종료합니다.");
        }

        // 저장 기능 (예시)
        public void SaveGame()
        {
            RenderConsole.WriteLine("게임 저장 기능은 추후 구현 예정입니다.");
        }

        // 불러오기 기능 (예시)
        public void LoadGame()
        {
            RenderConsole.WriteLine("게임 불러오기 기능은 추후 구현 예정입니다.");
        }
    }
}
