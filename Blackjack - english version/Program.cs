using System;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string LatestWinner = "No one has won yet.";
            
            Console.WriteLine("Welcome to blackjack! (English version)");
            Console.WriteLine("Coded by Kloxate.");
            Console.WriteLine();

            string menu = "0";
            while (menu != "4")
            {
                //Main menu
                Console.WriteLine("Pick a option");
                Console.WriteLine("1. Play blackjack");
                Console.WriteLine("2. Show latest winner");
                Console.WriteLine("3. Game rules");
                Console.WriteLine("4. Stop playing");
                menu = Console.ReadLine();

                Console.WriteLine();

                switch (menu)
                {
                    //Play one round of blackjack
                    case "1":
                        //Set playerpoints and dealerpoints to 0
                        int dealerpoints = 0;
                        int playerpoints = 0;
                        Console.WriteLine("Now two cards will be given to the player and dealer");
                        dealerpoints += random.Next(1, 11);
                        dealerpoints += random.Next(1, 11);
                        playerpoints += random.Next(1, 11);
                        playerpoints += random.Next(1, 11);

                        //Let the player draw more cards
                        string card = "";
                        while (card != "n" && playerpoints <= 21)
                        {
                            Console.WriteLine($"Your points: {playerpoints}");
                            Console.WriteLine($"Dealer points: {dealerpoints}");
                            Console.WriteLine("Would you like another card? y/n");
                            card = Console.ReadLine();

                            switch (card)
                            {
                                case "y":
                                    int newpoints = random.Next(1, 11);
                                    playerpoints += newpoints;
                                    Console.WriteLine($"Your new card is worth {newpoints} points");
                                    Console.WriteLine($"You have a total of {playerpoints} points");
                                    break;

                                case "n":
                                    break;

                                default:
                                    Console.WriteLine("You did not pick a valid option");
                                    break;
                            }

                        }

                        //Go back to main menu if player has over 21 points
                        if (playerpoints > 21)
                        {
                            Console.WriteLine("You have more than 21 points, you lose :(");
                            break;
                        }

                        //Dealer draws cards until it wins or goes over 21
                        while (dealerpoints < playerpoints && dealerpoints <= 21)
                        {
                            int dealernewpoints = random.Next(1, 11);
                            dealerpoints += dealernewpoints;
                            Console.WriteLine($"Dealer drew one card worth {dealernewpoints}");
                        }
                        Console.WriteLine($"Your points: {playerpoints}");
                        Console.WriteLine($"Dealer points: {dealerpoints}");

                        //Calculate who won
                        if (dealerpoints > 21)
                        {
                            Console.WriteLine("You have won!");
                            Console.WriteLine("Please state your name");
                            LatestWinner = Console.ReadLine();
                        }
                        else if (dealerpoints == playerpoints)
                        {
                            Console.WriteLine("It's a draw, no one won!");
                        }
                        else
                        {
                            Console.WriteLine("The dealer has won!");
                            LatestWinner = "Dealer";
                        }

                        break;

                    case "2":
                        Console.WriteLine($"Latest winner: {LatestWinner}");
                        break;

                    case "3":
                        Console.WriteLine("Your goal is to force the dealer to get more than 21 points");
                        Console.WriteLine("You get more points by drawing cards, each card is worth 1-10 points.");
                        Console.WriteLine("If you get more than 21 points, you lose.");
                        Console.WriteLine("Both you and the dealer get 2 cards in the beginning");
                        Console.WriteLine("Draw more cards until you are satisfied, or you get 21 points");
                        Console.WriteLine("When you are done, the dealer will draw cards to his stack");
                        Console.WriteLine("You need to have more points than the dealer to win.");
                        break;

                    case "4":
                        break;

                    default:
                        Console.WriteLine("You did not pick a valid option");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}