namespace RnLottery
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Välkommen till lotteriet!");

            // Steg 1: Köpa lotter
            int[] userNumbers = GetUserNumbers();

            // Steg 2: Dra vinnande nummer
            int[] winningNumbers = DrawWinningNumbers();

            Console.WriteLine("\nVinnande nummer är:");
            for (int i = 0; i < winningNumbers.Length; i++)
            {
                Console.Write(winningNumbers[i] + " ");
            }

            // Steg 3: Kontrollera resultat
            int matchCount = CheckResults(userNumbers, winningNumbers);

            Console.WriteLine($"\nAntal rätt: {matchCount}");
        }

        // Användarinmatning - Mata in exakt 5 nummer mellan 1 och 50
        static int[] GetUserNumbers()
        {
            int[] userNumbers = new int[3];  // Array för användarens nummer
            int count = 0;

            while (count < userNumbers.Length)
            {
                Console.Write($"Ange nummer {count + 1} (1-50): ");
                if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 50 && Array.IndexOf(userNumbers, number) == -1)
                {
                    userNumbers[count] = number;
                    count++;
                }
                else
                {
                    Console.WriteLine("Ogiltigt nummer eller redan valt nummer. Försök igen.");
                }
            }

            return userNumbers;
        }

        // Generera tre slumpmässiga vinnande nummer
        static int[] DrawWinningNumbers()
        {
            Random random = new Random();
            int[] winningNumbers = new int[3];  // Array för vinnande nummer

            for (int i = 0; i < winningNumbers.Length; i++)
            {
                int number;
                do
                {
                    number = random.Next(1, 51); // Generera tal mellan 1 och 50
                } while (Array.IndexOf(winningNumbers, number) != -1);

                winningNumbers[i] = number;
            }

            return winningNumbers;
        }

        // Kontrollera hur många rätt användaren har
        static int CheckResults(int[] userNumbers, int[] winningNumbers)
        {
            int matchCount = 0;

            for (int i = 0; i < userNumbers.Length; i++)
            {
                if (Array.IndexOf(winningNumbers, userNumbers[i]) != -1)
                {
                    matchCount++;
                }
            }

            return matchCount;
        }
    }

}
