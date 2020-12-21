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
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(genRand);
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("\nWould you like to enable hints? [Y/N]");
        string hints = Console.ReadLine().ToUpper();

        Console.WriteLine("\nGuess a number between 1 and 100");
        int num = Convert.ToInt32(Console.ReadLine());
        while (num > 100 || num <= 0)
        {
          Console.Clear();
          Console.WriteLine("\nInvalid entry, try again.");
          Console.WriteLine("\nGuess a number between 1 and 100");
          num = Convert.ToInt32(Console.ReadLine());
        }

        int count = 1;

        // Previous Error used to determine if most recent guess is closer than the last guess:
        string hint = "";
        int prevError = Math.Abs(genRand - num);
        // Console.WriteLine($"prevError: " + prevError);

        while (num != genRand)
        {
          // Ensure entry is valid number
          while (num > 100 || num <= 0)
          {
            Console.Clear();
            Console.WriteLine("\nInvalid entry, try again.");
            Console.WriteLine("\nGuess a number between 1 and 100");
            num = Convert.ToInt32(Console.ReadLine());
            count++;
          }

          Console.Clear();
          Console.WriteLine($"(" + count + ") You guessed " + num);
          int error = Math.Abs(genRand - num);
          // Console.WriteLine($"     error: " + error);
          // Console.WriteLine($" prevError: " + prevError);

          // determine hints
          if (prevError > error && count > 1 && hints == "Y")
          {
            hint = "  ...getting warmer, ";
          }
          else if (prevError < error && count > 1 && hints == "Y")
          {
            hint = "  ...colder, ";
          }
          else if (prevError == error && count > 1 && hints == "Y")
          {
            hint = "  ...split the difference!, ";
          }
          else
          {
            Console.WriteLine("no hints");
          }

          // Console.WriteLine($"     count: " + count);

          // Hint #1 + Validate answer
          if (num < genRand)
          {
            Console.WriteLine(hint + "guess higher...\n");
          }
          else if (num > genRand)
          {
            Console.WriteLine(hint + "guess lower...\n");
          }
          else
          {
            Console.WriteLine("\nYou hit the nail right on the head!");
          }


          // Hint #2
          if (hints == "Y" && count > 1)
          {
            if (prevError > error)
            {
              Console.WriteLine($"Your guess was warmer by: " + Math.Abs(prevError - error));
            }
            else if (prevError < error)
            {
              Console.WriteLine($"Your guess was colder by: " + Math.Abs(prevError - error));
            }
          }

          // Prepare next round
          num = Convert.ToInt32(Console.ReadLine());
          prevError = error;
          count++;
        }

        if (count < 2)
        {
          Console.WriteLine($"You are truly AMAZING!");
        }
        else
        {
          Console.Clear();
          Console.WriteLine($"You guessed {genRand} correctly using {count} guesses!");
        }

        Console.WriteLine("\nThanks for playing!");
        Console.WriteLine("\nWould you like to play again? [Y/N]");
        answer = Console.ReadLine().ToUpper();
      }
    }
  }
}
