using System;

class Program
{
    public static void Main()
    {
        GameAccount my1Account = new GameAccount("Alex", 1, 0);
        GameAccount my2Account = new GameAccount("Bob", 1, 0);


        Random rnd = new Random();
        int amount = rnd.Next(1, 10);
        string[] oppNames = new string[amount];
        string[] winOrLoses = new string[amount];
        int[] rates = new int[amount];
        int[] index = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            Game game = new Game();
            my1Account.GamesCount++;
            Console.WriteLine("Гра№" + (i + 1));
            Console.WriteLine(game.valueGamer + "//" + game.valueOpponent);
            int rat = Math.Abs(game.valueGamer - game.valueOpponent);
            string winOrLose;
            if (game.valueGamer < game.valueOpponent)
            {
                my1Account.LoseGame("AppleJack", rat);
                my1Account.CurrentRating -= rat;
                if (my1Account.CurrentRating < 1)
                {
                    my1Account.CurrentRating = 1;
                }
                winOrLose = "Lose";
            }
            else
            {
                my1Account.WinGame("AppleJack", rat);
                my1Account.CurrentRating += rat;
                winOrLose = "Win";
            }
            my1Account.GetStats(amount, i, "AppleJack", winOrLose, rat, oppNames, winOrLoses, rates, index);
        }
      //для наступного гравця

        amount = rnd.Next(1, 10);
        oppNames = new string[amount];
        winOrLoses = new string[amount];
        rates = new int[amount];
        index = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            Game game = new Game();
            my2Account.GamesCount++;
            Console.WriteLine("Гра№" + (i + 1));
            Console.WriteLine(game.valueGamer + "//" + game.valueOpponent);
            int rat = Math.Abs(game.valueGamer - game.valueOpponent);
            string winOrLose;
            if (game.valueGamer < game.valueOpponent)
            {
                my2Account.LoseGame("Bob", rat);
                my2Account.CurrentRating -= rat;
                if (my2Account.CurrentRating < 1)
                {
                    my2Account.CurrentRating = 1;
                }
                winOrLose = "Lose";
            }
            else
            {
                my2Account.WinGame("Bob", rat);
                my2Account.CurrentRating += rat;
                winOrLose = "Win";
            }
            my2Account.GetStats(amount, i, "Bob", winOrLose, rat, oppNames, winOrLoses, rates, index);
        }



    }

    public class GameAccount
    {
        public string UserName;
        public int CurrentRating;
        public int GamesCount;

        public GameAccount(string usrname, int currating, int gamcount)
        {
            UserName = usrname;
            CurrentRating = currating;
            GamesCount = gamcount;
        }

        public void WinGame(string oppName, int rating)
        {
            string opponentName = oppName;
            int Rating = rating;
        }

        public void LoseGame(string oppName, int rating)
        {
            string opponentName = oppName;
            int Rating = rating;
        }

        public void GetStats(int amount, int i, string oppName, string winOrLose, int rat, string[] oppNames, string[] winOrLoses, int[] rates, int[] index)
        {

            oppNames[i] = oppName;
            winOrLoses[i] = winOrLose;
            rates[i] = rat;
            index[i] = i;
            Console.WriteLine(oppNames[i] + "//" + winOrLoses[i] + "//" + rates[i] + "//" + index[i]);
            if (i == (amount - 1))
            {
                for (int j = 0; j < (amount); j++)
                {
                    Console.WriteLine(oppNames[j] + "//" + winOrLoses[j] + "//" + rates[j] + "//" + index[j]);
                }
            }
        }

    }
}

public class Game
{
    public static Random rnd = new Random();
    public int valueGamer = rnd.Next(10);
    public int valueOpponent = rnd.Next(10);
}
