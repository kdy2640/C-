using System;

namespace TEXTRPG1
{
    static class TextRpg1
    {
        enum ClassType
        {
            None, Knight, Archer, Mage
        }
        enum MonsterType
        {
            None, Slime, Orc, Skeleton
        }
        struct Player
        {
            public int hp;
            public int attack;
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }
        static void Fight(ref Player _player, Monster _monster)
        {
            while(true)
            {

                _monster.hp -= _player.attack;

                Console.WriteLine("플레이어의 공격");

                if (_monster.hp <= 0)
                {
                    Console.WriteLine($"현재 몬스터의 체력은 0 입니다.");
                    Console.WriteLine("전투에서 승리하셨습니다.");
                    enterField(ref _player);
                    break;
                }
                Console.WriteLine($"현재 몬스터의 체력은 {_monster.hp}입니다.");

                _player.hp -= _monster.attack;

                Console.WriteLine("몬스터의 공격");
                if (_player.hp <= 0)
                {
                    Console.WriteLine($"현재 플레아어의 체력은 0 입니다.");
                    Console.WriteLine("전투에서 패배하셨습니다.");
                    break;
                }

                Console.WriteLine($"현재 플레아어의 체력은 {_player.hp}입니다.");
            }

        }
        static ClassType chooseClass()
        {
            ClassType choice = ClassType.None;
            Console.WriteLine("직업을 선택하여 주십시오.");
            Console.WriteLine("[1] 기사 | hp : 20 | attack : 10");
            Console.WriteLine("[2] 궁수 | hp : 15 | attack : 13");
            Console.WriteLine("[3] 법사 | hp : 10 | attack : 15");
            while (choice == ClassType.None)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        choice = ClassType.Knight;
                        break;
                    case "2":
                        choice = ClassType.Archer;
                        break;
                    case "3":
                        choice = ClassType.Mage;
                        break;
                    default:
                        break;
                }
            }
            return choice;
            

        }
        static void createPlayer(ClassType _choice, out Player _player)
        {
            switch (_choice)
            {
                case ClassType.Knight:
                    _player.hp = 200;
                    _player.attack = 10;
                    break;
                case ClassType.Archer:
                    _player.hp = 150;
                    _player.attack = 12;
                    break;
                case ClassType.Mage:
                    _player.hp = 100;
                    _player.attack = 15;
                    break;
                default:

                    _player.hp = 0;
                    _player.attack = 0;
                    break;
            }
        }
        static Monster createRandomMonster()
        {
            Random rand = new Random();
            Monster monster;
            int randValue = rand.Next(1, 3);
            switch(randValue)
            {
                case 1: //Slime
                    monster.hp = 10;
                    monster.attack = 5;
                    break;
                case 2: //ORc
                    monster.hp = 30;
                    monster.attack = 15;
                    break;
                case 3: //Skeleton
                    monster.hp = 5;
                    monster.attack = 7;
                    break;
                default:
                    monster.hp = 10;
                    monster.attack = 5;
                    break;
            }
            return monster;
        }
        static void enterField(ref Player _player)
        {
            Monster monster = createRandomMonster();
            Console.WriteLine("필드에 도착하였습니다.");
            Console.WriteLine("몬스터가 등장하였습니다.");
            Console.WriteLine("[1] 싸운다");
            Console.WriteLine("[2] 도망간다 (33%)");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("전투를 시작합니다."); 
                    Fight(ref _player, monster);

                    break;
                }
                else if (input == "2")
                {
                    Random rand = new Random();
                    int randValue = rand.Next(1, 3);
                    if (randValue == 1) { Console.WriteLine("성공적으로 도망쳤습니다."); enterGame(ref _player); }
                    else { Console.WriteLine("도주에 실패합니다. 전투를 시작합니다."); Fight(ref _player, monster); }

                    break;
                }
            }
        }
        static void enterGame(ref Player _player)
        {
            Console.WriteLine("어떤 행동을 하시겠습니까.");
            Console.WriteLine("[1] 필드에 간다");
            Console.WriteLine("[2] 게임종료");

            
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "1")
                {

                    Console.WriteLine("필드로 갑니다");
                    enterField(ref _player);
                    break;
                }
                else if (input == "2")
                {

                    Console.WriteLine("게임을 종료합니다.");
                    break;
                }
            }
        }
        static void Main()
        {
            ClassType choice = chooseClass();
            Player player;
            createPlayer(choice,out player);
            while(true)
            {
                enterGame(ref player);
                break;
            }
        }
    }


}