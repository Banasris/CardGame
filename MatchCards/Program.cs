using MatchCards;
using MatchCards.Models;

int packSize;
int matchCondition;
string matchConditionStr;

Console.WriteLine("How many packs of card you want to use for the deck? (Please enter an integer between 1 and 100)\n"); 

// Read the input from the console as a string
string inputPackSize = Console.ReadLine();


// Loop through until the user inputs a valid number
while (!int.TryParse(inputPackSize, out packSize) || !(packSize >= 1 & packSize <= 100))
{
    Console.WriteLine("Invalid input. Please enter a valid integer between 1 and 100. Try again.\n");

    inputPackSize = Console.ReadLine();
}

Console.WriteLine($"You entered pack size: {packSize} \n");

Console.WriteLine("Which match condition do you want to use? Choose option 1 or 2 or 3 by typing the number from the list below:") ;

Console.WriteLine(
    "(1) MatchSuits\n" +
    "(2) MatchValues\n" +
    "(3) MatchSuitsAndValues\n");

// Read the input from the console as a string
string inputMatchCondition = Console.ReadLine();

// Display the entered number
if (int.TryParse(inputMatchCondition, out matchCondition) && matchCondition is 1 or 2 or 3)
{
    Console.WriteLine($"You entered match condition number: {matchCondition} \n");
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid match condition number (1 or 2 or 3) \n");
}

Console.WriteLine(("").PadRight(70, '-'));

// Convert match condition integer to match condition string
switch (matchCondition)
{
    case 1:
        matchConditionStr = nameof(ENUMS.MatchCondition.MatchSuits);
        break;
    case 2:
        matchConditionStr = nameof(ENUMS.MatchCondition.MatchValues);
        break;
    case 3:
        matchConditionStr = nameof(ENUMS.MatchCondition.MatchSuitsAndValues);
        break;
    default:
        matchConditionStr = nameof(ENUMS.MatchCondition.MatchNotValid);
        break;
}

try
{
    //Game cannot be started if the match condition is invalid or pack size is not between 1 and 100 
    if (matchConditionStr == nameof(ENUMS.MatchCondition.MatchNotValid) || !(packSize >= 1 & packSize <= 100))
    {
        Console.WriteLine("Sorry, due to invalid input the game could not be started\n");
        Console.WriteLine(("").PadRight(70, '-'));
    }
    else
    {
        var gameSimulator = new GameSimulator(packSize, matchConditionStr);
        gameSimulator.ProcessGame();
    }
}
catch (Exception)
{
    Console.WriteLine("An unexpected error occurred");
}
