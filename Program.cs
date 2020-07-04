using System;

namespace numberGuessingGame
{
  class Program
  {
    static void Main(string[] args)
    {
      string answer = "Y";
      while (answer == "Y")
      {

        Random r = new Random();
        int genRand = r.Next(1, 101);
        Console.Clear();
        Console.Write(genRand);

        Console.WriteLine("\nGuess a number between 1 and 100");
        int num = Convert.ToInt32(Console.ReadLine());
        int count = 1;
        while (num != genRand)
        {
          Console.Clear();
          Console.WriteLine($"You guessed " + num);
          if (num < genRand)
          {
            Console.WriteLine("Guess higher...\n");
          }
          else
          {
            Console.WriteLine("Guess lower...");
          }
          num = Convert.ToInt32(Console.ReadLine());
          count++;
        }
        if (count < 2)
        {
          Console.WriteLine($"You are truly AMAZING!");
        }
        else
        {
          Console.WriteLine($"You guessed {genRand} correctly using {count} guesses!");
        }
        Console.WriteLine("\nThanks for playing!");

        Console.WriteLine("\nWould you like to play again? [Y/N]");
        answer = Console.ReadLine().ToUpper();
      }
    }
  }
}
