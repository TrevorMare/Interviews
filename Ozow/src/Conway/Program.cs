using System;

namespace Conway
{
    class Program
    {
        /*
            --- TASK
            Write a version of Conway’s Game of Life (http://en.wikipedia.org/wiki/Conway’s_Game_of_Life)
            that generates a random placement of cells as it’s initial state and iterates
            through generations displaying each state. Your program should allow for a
            configurable board size and number of generations.
        */

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the number of rows");
                int numberOfRows = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the number of columns");
                int numberOfColumns = int.Parse(Console.ReadLine());
                Console.WriteLine("Press enter to proceed to next generation");

                // Create a new board
                var conwayBoard = new ConwayBoard(numberOfRows, numberOfColumns);
                // Do the initial seed
                Helpers.ConwayBoardSeed.RandomSeedConwayBoard(conwayBoard);

                var outputBuilder = new System.Text.StringBuilder();
                outputBuilder.AppendLine("Initial Seed");
                outputBuilder.Append(conwayBoard.ToString());
                Console.WriteLine(outputBuilder.ToString());
                Console.WriteLine("Press enter to proceed to next generation");

                while (true)
                {
                    Console.ReadLine();
                    Helpers.ConwayBoardProgression.ProgressBoard(conwayBoard);

                    Console.Clear();
                    outputBuilder = new System.Text.StringBuilder();
                    outputBuilder.AppendLine($"Progression {conwayBoard.CurrentProgression}");
                    outputBuilder.Append(conwayBoard.ToString());
                    Console.WriteLine(outputBuilder.ToString());
                    Console.WriteLine("Press enter to proceed to next generation");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured {ex}");
            }


        }
    }
}
