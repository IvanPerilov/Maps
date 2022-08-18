using System;


namespace Maps
{
    class Program
    {
        int XPothition = 1;
        int YPothition = 1;
        string Hiro = "0";
        string[] MainMap;
        string[] GameMap;
        static string[] MapCube =
            {
                "+-------------------+",
                "|...................|",
                "|...................|",
                "|...................|",
                "|...................|",
                "|...................|",
                "|...................|",
                "|...................|",
                "|...................|",
                "+-------------------+"
            };
        void CreatMainMap (string[] map)
        {
            MainMap = new string[map.Length];
            for (int i = 0; i < map.Length; i++)
            {
                MainMap[i] = map[i];
            }
            CreateGameMap();
        }
        void ChangeMainMap (string[] map)
        {
            Array.Clear(MainMap, 0, MainMap.Length);
            CreatMainMap(map);
        }

        void CreateGameMap()
        {
            GameMap = new string[MainMap.Length];
            RestorGameMap();
        }
        void RestorGameMap(int y)
        {
            GameMap[y] = MainMap[y];
        }
        void RestorGameMap()
        {
            for (int i = 0; i < MainMap.Length; i++)
                GameMap[i] = MainMap[i];
        }
        bool CheckPothition(int x, int y)
        {
            if ((MainMap[y][x] != '+') && (MainMap[y][x] != ' ') && (MainMap[y][x] != '-') && (MainMap[y][x] != '|'))
                return true;
            else
                return false;
        }
        void ChoosHiroPothition(int x, int y)
         {
            if ((XPothition > 0 && XPothition < GameMap[0].Length) && (YPothition > 0 && YPothition < GameMap.Length))
            {
                if (CheckPothition( XPothition,  YPothition))
                {
                    XPothition = x;
                    YPothition = y;
                }
                else
                {
                    Console.WriteLine("Ошибка. Недопустимое положение героя: здесь есть мешающий объект");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Недопустимое положение героя: место находится вне карты");
            }
        }
        void GenerateHiro()
        {
            string str = "";
            for (int i = 0; i < GameMap[YPothition].Length; i++)
                if (i != XPothition)
                {
                    str += GameMap[YPothition][i];
                }
                else
                {
                    str += Hiro;
                }
            GameMap[YPothition] = str;
        }
        void ChangYHiroPothition(int y)
        {
            GameMap[YPothition] = MainMap[YPothition];
            GameMap[y] = "";
            int i = 0;
            while (i != XPothition)
            {
                GameMap[y] += MainMap[y][i];
                i++;
            }
            GameMap[y] += Hiro;
            i++;
            while (i < MainMap[y].Length)
            {
                GameMap[y] += MainMap[y][i];
                i++;
            }
            YPothition = y;
        }
        void ChangXHiroPothition (int x)
        {
                GameMap[YPothition] = "";
                int i = 0;
                while (i != x)
                {
                    GameMap[YPothition] += MainMap[YPothition][i];
                    i++;
                }
                GameMap[YPothition] += Hiro;
                i++;
                while (i < MainMap[YPothition].Length)
                { 
                    GameMap[YPothition] += MainMap[YPothition][i];
                    i++;
                }
                XPothition = x;   
        }
        void ShowGameMap ()
        {
            for (int i = 0; i < GameMap.Length; i++)
            {
                Console.WriteLine(GameMap[i]);
            }
        }
        void Move (char key)
        {
            if (key == 'w')
            {
                if (CheckPothition(XPothition, YPothition - 1))
                {
                    ChangYHiroPothition(YPothition - 1);
                    Console.Clear();
                    ShowGameMap();
                    return;
                }
                else return;
            }
            if (key == 's')
            {
                if (CheckPothition(XPothition, YPothition + 1))
                {
                    ChangYHiroPothition(YPothition + 1);
                    Console.Clear();
                    ShowGameMap();
                    return;
                }
                else return;
            }
            if (key == 'a')
            {
                if (CheckPothition(XPothition - 1, YPothition))
                {
                    ChangXHiroPothition(XPothition - 1);
                    Console.Clear();
                    ShowGameMap();
                    return;
                }
                else return;
            }
            if (key == 'd')
            {
                if (CheckPothition(XPothition + 1, YPothition))
                {
                    ChangXHiroPothition(XPothition + 1);
                    Console.Clear();
                    ShowGameMap();
                    return;
                }
                else return;
            }
        }
        static void Main(string[] args)
        {
            var MyProgramm = new Program();
            MyProgramm.CreatMainMap(MapCube);
            MyProgramm.ChoosHiroPothition(1, 1);
            MyProgramm.GenerateHiro();
            MyProgramm.ShowGameMap();
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                    MyProgramm.Move(keyInfo.KeyChar);
            }
            while (true);
        }
    }
}
