using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        GameAccount my1Account = new GameAccount("", 1, 0);//один гравець
        GameAccount my2Account = new GameAccount("", 1, 0);//інший
        GameAccount my3Account = new GameAccountLight("", 1, 0);//вдвічі менше знімає
        GameAccount my4Account = new GameAccountBonus("", 1, 0);//за серію ігор +2 бали
        GameAccount my5Account = new GameAccount("", 1, 0);//тренувальна гра

        //поїхав перший
        Random rnd = new Random();
        int amount = rnd.Next(1, 10); //визначаю кількість ігор
        string[] oppNames = new string[amount];
        string[] winOrLoses = new string[amount];
        int[] rates = new int[amount];
        int[] index = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            BaseGame game = new Game();
            my1Account.GamesCount++;
            Console.WriteLine("Гра№" + (i + 1));
            Console.WriteLine(Game.valueGamer + "//" + Game.valueOpponent); //виводить числа гравця і опонента
            string winOrLose;
            if (Game.valueGamer < Game.valueOpponent)
            {
                my1Account.LoseGame("AppleJack", Game.rat);
                my1Account.CurrentRating -= Game.rat; //зняло рейтинг
                if (my1Account.CurrentRating < 1)
                {
                    my1Account.CurrentRating = 1; //якщо менше одного, дорівнює один
                }
                winOrLose = "Lose";
            }
            else
            {
                my1Account.WinGame("AppleJack", Game.rat);
                my1Account.CurrentRating += Game.rat;
                winOrLose = "Win";
            }
            my1Account.GetStats(amount, i, "AppleJack", winOrLose, Game.rat, oppNames, winOrLoses, rates, index);
        }
        Console.WriteLine(my1Account.CurrentRating); //виводжу фінальний рейтинг

        //для другого гравця
        amount = rnd.Next(1, 10);
        oppNames = new string[amount];
        winOrLoses = new string[amount];
        rates = new int[amount];
        index = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            BaseGame game = new Game();
            my2Account.GamesCount++;
            Console.WriteLine("Гра№" + (i + 1));
            Console.WriteLine(Game.valueGamer + "//" + Game.valueOpponent);
            string winOrLose;
            if (Game.valueGamer < Game.valueOpponent)
            {
                my2Account.LoseGame("Bob", Game.rat);
                my2Account.CurrentRating -= Game.rat;
                if (my2Account.CurrentRating < 1)
                {
                    my2Account.CurrentRating = 1;
                }
                winOrLose = "Lose";
            }
            else
            {
                my2Account.WinGame("Bob", Game.rat);
                my2Account.CurrentRating += Game.rat;
                winOrLose = "Win";
            }
            my2Account.GetStats(amount, i, "Bob", winOrLose, Game.rat, oppNames, winOrLoses, rates, index);
        }
        Console.WriteLine(my2Account.CurrentRating);

        //для лайт аккаунта
        amount = rnd.Next(1, 10);
        oppNames = new string[amount];
        winOrLoses = new string[amount];
        rates = new int[amount];
        index = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            BaseGame game = new Game();
            my3Account.GamesCount++;
            Console.WriteLine("Гра№" + (i + 1));
            Console.WriteLine(Game.valueGamer + "//" + Game.valueOpponent);
            string winOrLose;
            if (Game.valueGamer < Game.valueOpponent)
            {
                my3Account.LoseGame("Potato", Game.rat);
                my3Account.CurrentRating -= Game.rat / 2; //знімає вдвічі менше
                if (my3Account.CurrentRating < 1)
                {
                    my3Account.CurrentRating = 1;
                }
                winOrLose = "Lose";
            }
            else
            {
                my3Account.WinGame("Potato", Game.rat);
                my3Account.CurrentRating += Game.rat;
                winOrLose = "Win";
            }
            my3Account.GetStats(amount, i, "Potato", winOrLose, Game.rat, oppNames, winOrLoses, rates, index);
        }
        Console.WriteLine(my3Account.CurrentRating);

        //для бонусного аккаунта
        amount = rnd.Next(1, 10);
        oppNames = new string[amount];
        winOrLoses = new string[amount];
        rates = new int[amount];
        index = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            BaseGame game = new Game();
            my4Account.GamesCount++;
            Console.WriteLine("Гра№" + (i + 1));
            Console.WriteLine(Game.valueGamer + "//" + Game.valueOpponent);
            string winOrLose;
            if (Game.valueGamer < Game.valueOpponent)
            {
                my4Account.LoseGame("Cucumber", Game.rat);
                my4Account.CurrentRating -= Game.rat;
                if (my4Account.CurrentRating < 1)
                {
                    my4Account.CurrentRating = 1;
                }
                winOrLose = "Lose";
            }
            else
            {
                my4Account.WinGame("Cucumber", Game.rat);
                my4Account.CurrentRating += Game.rat;
                winOrLose = "Win";
            }
            if ((winOrLoses[i]) == "Win" && (winOrLoses[i - 1]) == "Win")//якщо цей і попередній - перемога, додаємо два бали
            {
                my4Account.CurrentRating += 2;
            }
            my4Account.GetStats(amount, i, "Cucumber", winOrLose, Game.rat, oppNames, winOrLoses, rates, index);
        }
        //тренувальна гра
        amount = rnd.Next(1, 10);
        oppNames = new string[amount];
        winOrLoses = new string[amount];
        rates = new int[amount];
        index = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            BaseGame game = new TrainGame();
            my5Account.GamesCount++;
            Console.WriteLine("Гра№" + (i + 1));
            Console.WriteLine(Game.valueGamer + "//" + Game.valueOpponent);
            string winOrLose;
            if (Game.valueGamer < Game.valueOpponent)
            {
                my5Account.LoseGame("Onion", Game.rat);//рейтинг, на який грають = 0
                winOrLose = "Lose";
            }
            else
            {
                my5Account.WinGame("Onion", Game.rat);
                winOrLose = "Win";
            }
            my5Account.GetStats(amount, i, "Onion", winOrLose, 1, oppNames, winOrLoses, rates, index);
        }

        List<BaseGame> allGames = new List<BaseGame>(){
        new Game(), new TrainGame()
      };
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

public class GameAccountLight : GameAccount
{
    public GameAccountLight(string usrname, int currating, int gamcount) : base(usrname, currating, gamcount)
    {
        //вдвічі менше знімає
    }
}

public class GameAccountBonus : GameAccount
{
    public GameAccountBonus(string usrname, int currating, int gamcount) : base(usrname, currating, gamcount)
    {
        //+2 бали за серію

    }
}

public abstract class BaseGame
{
    public static Random rnd = new Random();
    public static int valueGamer = rnd.Next(10);
    public static int valueOpponent = rnd.Next(10);
    public static int rat = valueGamer - valueOpponent;
}

public class Game : BaseGame//стандартна
{
}

public class TrainGame : BaseGame//без рейтингу
{
    public static int rat = 0; //ось і рейтинг = 0
}
