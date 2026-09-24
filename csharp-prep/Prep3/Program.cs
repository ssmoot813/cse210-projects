string playAgain = "yes";

while (playAgain == "yes")
{
    Random randomGenerator = new Random();
    int magicNumber = randomGenerator.Next(1, 101);

    int guess;
    int guessCount = 0;

    Console.Write("What is your guess? ");
    guess = int.Parse(Console.ReadLine());
    guessCount++;

    while (guess != magicNumber)
    {
        if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("Higher");
        }

        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());
        guessCount++;
    }

    Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");

    Console.Write("Do you want to play again? ");
    playAgain = Console.ReadLine();
}