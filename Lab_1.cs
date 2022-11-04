using System;

class Program
{

    public static void Main()
    {
        int b;
        Console.WriteLine("Введіть своє ім'я:");
        string name = Console.ReadLine();
        int currating = 100, gamecount = 0;
        GameAccount Person = new GameAccount(name, currating, gamecount);

        Console.WriteLine("Скільки ігр бажаєте зіграти?");
        b = Convert.ToInt32(Console.ReadLine());
        bool[] nums = new bool[b];
        string[] names = new string[b];
        int[] ratings = new int[b];
        for (int i = 0; i < b; i++)
        {
            Game Match = new Game();
            bool res = Match.Game1();
            string opponentName = Person.WinGame();
            int Rating = Person.LoseGame();
            if (res)
            {
                Console.WriteLine("Вітаємо!Ви вгадали");
                Console.WriteLine("Ви грали проти ігрока:" + opponentName);
                Console.WriteLine("На " + Rating + " балів рейтингу");
                Person.CurrentRating += 10;
                Person.WinGame();
            }
            else
            {
                Console.WriteLine("Таки не виграли(((");
                Console.WriteLine("Ви грали проти ігрока:" + opponentName);
                Console.WriteLine("На " + Rating + " балів рейтингу");
                if (Person.CurrentRating <= 10)
                {
                    Person.CurrentRating = 1;
                }
                else
                {
                    Person.CurrentRating -= 10;
                }
              Person.LoseGame();
            }

            Person.GamesCount++;
            nums[i] = res;
            names[i] = opponentName;
            ratings[i] = Rating;
            Console.WriteLine(Person.CurrentRating);
        }
        Person.GetStats(b, nums, names, ratings);

    }


    public class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public GameAccount(string name, int currating, int gamecount)
        {
            UserName = name;
            CurrentRating = currating;
            GamesCount = gamecount;
        }

        public string WinGame()
        {
            string opponentName = "Goga";
            int Rating = 10;
            return opponentName;
        }

        public int LoseGame()
        {
            string opponentName = "Goga";
            int Rating = 10;
            return Rating;
        }

        public void GetStats(int b, bool[] nums, string[] names, int[] ratings)
        {

            string[,] stat = new string[b, 4];
            for (int i = 0; i < b; i++)
            {
                if (nums[i])
                {
                    stat[i, 0] = "Перемога";
                }
                else
                {
                    stat[i, 0] = "Поразка";
                }
                stat[i, 1] = ratings[i].ToString();
                stat[i, 2] = names[i];
                stat[i, 3] = (i+1).ToString();
            }
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{stat[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
    public class Game
    {
        public bool Game1()
        {
            Console.WriteLine("Введіть ціле число від 0 до 10:");
            int a = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            int value = rnd.Next(0, 10);
            Console.WriteLine("Число суперника:" + value);
            if (a == value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
