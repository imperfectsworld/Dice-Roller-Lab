
using System.Numerics;

int diceNum = 2;
int side1;
int side2;
int total;
int counter = 0;
bool goAgain = true;
string response ="";

Console.WriteLine("Welcome to the Grand Circus Casino");
Console.WriteLine("How many sides on the dice would you like? Min:2 sides");

while (int.TryParse(Console.ReadLine(), out diceNum) == false || (diceNum <= 1 || diceNum > int.MaxValue))
{
    Console.WriteLine("Invalid Input, Try again");
}
diceNum += 1;
while (goAgain == true)
{
    counter++;
    Console.WriteLine($"Roll {counter}");
    Console.WriteLine($"You are using a {diceNum-1} sided dice");

    side1 = RandomGen(diceNum);
    side2 = RandomGen(diceNum);
    total = side1 + side2;
    Console.WriteLine($"You rolled a {side1} and a {side2} ({total} total)");
    if (diceNum == 7)
    {
        Console.WriteLine(AceSnakeBox(side1, side2));
        Console.WriteLine(CrapsWin(side1, side2));
    }
    else if (diceNum == 8) 
    {
        Console.WriteLine(SevenWin(side1, side2));
        Console.WriteLine(LuckySeven(side1, side2));
    }
    else
    {

    }

    while (true)
    {
        try
        {
            Console.Write("\nRoll Again (y/n?): ");
            response = Console.ReadLine().ToLower();
            if (response == "n" || response == "y")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    if (response == "y")
    {
        continue;
    }
    else
    {
        goAgain = false;
    }


}

static int RandomGen(int diceNum)
{
    Random rnd = new Random();
    int randomNumber = rnd.Next(1, diceNum);
    return randomNumber;
}

static string AceSnakeBox(int side1, int side2)
{
    if (side1 == 1 && side1  == side2)
    {
        return "Snake eyes!";
    }
    else if (side1 == 6 && side1 == side2)
    {
        return "Box Cars!";
    }
    else if ((side1 == 1 && side2 == 2) || (side1 == 2 && side2 == 1))
    {
        return "Ace Deuce!";
    }
    else
    {
        return "";
    }
}


static string CrapsWin(int side1, int side2)
{
    if ((side1 + side2) >= 7)
    {
        return "Win!";
    }
    else if ((side1 + side2) == 2 || (side1 + side2) == 3 || (side1 + side2) == 12)
    {
        return "Craps!";
    }
    else
    {
        return "";
    }
}

//ExtraCredit

static string LuckySeven(int side1, int side2)
{
    if (side1 == 7 && side2 == 7)
    {
        return "\n************You are luck personified! All hail the chosen one!************\n";
    }
    else
    {
        return "";
    }
}

static string SevenWin(int side1, int side2)
{
    if((side1 + side2) >= 7)
        {
        return "Win!";
        }
    else
    {
        return "";
    }
}
