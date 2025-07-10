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

            Console.WriteLine("직업을 선택하세요:");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");

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
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                }
            }

            Player = new Player(name, selectedJob.BaseStat, 1500);
            Console.WriteLine($"{name}님, {(selectedJob is WarriorJob ? "전사" : "도적")}로 시작합니다!");
        }

        // 게임 시작
        public void StartGame()
        {
            Console.WriteLine("게임을 시작합니다!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("무엇을 하시겠습니까?");
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("0. 게임 종료");
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
                        Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                        break;
                }
            }
        }

        // 상점 출력 (예시)
        public void ShowShop()
        {
            Console.WriteLine("상점 기능은 추후 구현 예정입니다.");
        }


        // 플레이어 상태 출력
        public void ShowPlayerStatus()
        {
            Console.WriteLine($"이름: {Player.Name}");
            Console.WriteLine($"체력: {Player.CurrentHP} / {Player.Stat.MaxHP}");
            Console.WriteLine($"마나: {Player.CurrentMP} / {Player.Stat.MaxMP}");
            Console.WriteLine($"공격력: {Player.Stat.Attack}");
            Console.WriteLine($"방어력: {Player.Stat.Defense}");
            Console.WriteLine($"골드: {Player.Gold}");
        }

        // 인벤토리 출력
        public void ShowInventory()
        {
            Console.WriteLine("인벤토리:");
            var items = Player.Inventory.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("  (비어 있음)");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"  {item.Info.Name} (가격: {item.Info.Price}, 스탯 상승: {item.Info.StatBonus})");
                }
            }
        }

        // 전투 시작 (예시)
        public void StartBattle()
        {
            Console.WriteLine("전투가 시작됩니다! (전투 로직은 추후 구현)");
        }

        // 아이템 사용 (예시)
        public void UseItem()
        {
            Console.WriteLine("사용할 아이템 번호를 입력하세요:");
            var items = Player.Inventory.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Info.Name}");
            }
            // 실제 사용 로직은 추후 구현
        }

        // 게임 종료
        public void EndGame()
        {
            Console.WriteLine("게임을 종료합니다.");
        }

        // 저장 기능 (예시)
        public void SaveGame()
        {
            Console.WriteLine("게임 저장 기능은 추후 구현 예정입니다.");
        }

        // 불러오기 기능 (예시)
        public void LoadGame()
        {
            Console.WriteLine("게임 불러오기 기능은 추후 구현 예정입니다.");
        }
    }
}
